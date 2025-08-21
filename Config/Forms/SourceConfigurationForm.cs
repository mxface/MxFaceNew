using Neurotec.Devices;
using Neurotec.Media;
using Neurotec.Samples.Code;
using Neurotec.Samples.Config.Forms.Tools;
using Neurotec.Surveillance;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms
{
	public partial class SourceConfigurationForm : Form
	{
		#region Private types

		private enum ConfigType
		{
			Triggers = 1,
			SearchArea = 3,
			General = 5,
		}

		private class Config
		{
			#region Public constructors

			public Config(int columns, int rows)
			{
				Rows = rows;
				Columns = columns;
			}

			public Config(SourceConfiguration config)
			{
				IsGrid = config.IsGrid;
				Columns = config.Columns;
				Rows = config.Rows;
				CheckSearchAreaByObjectCenter = config.CheckSearchAreaByObjectCenter;

				foreach (var trigger in config.Triggers)
				{
					Triggers.Add(ToolData.Create(trigger));
				}
				foreach (var area in config.Areas)
				{
					Areas.Add(ToolData.Create(area));
				}
			}

			#endregion

			#region Public properties

			// Triggers
			public ObservableCollection<ToolData> Triggers { get; } = new ObservableCollection<ToolData>();

			// Search Area
			public ObservableCollection<ToolData> Areas { get; } = new ObservableCollection<ToolData>();
			public bool IsGrid { get; set; } = true;
			public int Rows { get; set; }
			public int Columns { get; set; }
			public bool CheckSearchAreaByObjectCenter { get; set; } = true;

			#endregion
		}

		#endregion

		#region Private fields

		private Thread _thread = null;
		private bool _continue = true;
		private Tool _activeTool = null;
		private UndoStack _undoStack = new UndoStack();
		private Bitmap _image = null;
		private NMediaFormat _format = null;

		private Config _workingConfig;

		#endregion

		#region Public constructor

		public SourceConfigurationForm()
		{
			InitializeComponent();
			cbOrigin.Items.Add(NBoxOrigin.TopCenter);
			cbOrigin.Items.Add(NBoxOrigin.Center);
			cbOrigin.Items.Add(NBoxOrigin.BottomCenter);
			cbOrigin.SelectedIndex = 1;
		}

		#endregion

		#region Public properties

		public SourceController SourceState { get; set; }
		public SourceConfiguration SourceConfig { get; set; }

		#endregion

		#region Private methods

		private void SetHint(string text) => lblHint.Text = text;

		private void OnImageCaptured(Bitmap image)
		{
			_image?.Dispose();
			_image = image;
			panelImage.Invalidate();
		}

		private void CaptureThread()
		{
			NCamera camera = SourceState.Source.Camera;
			NMediaReader reader = null;
			bool stop = false;

			try
			{
				if (camera == null)
				{
					var path = SourceState.Source.GetProperty<string>("FullPath");
					reader = new NMediaReader(path, NMediaType.Video, true);
				}

				if (camera != null)
				{
					camera.StartCapturing();
					try
					{
						using (var format = SourceState.Source.GetCurrentFormat())
						{
							if (format != null)
								camera.SetCurrentFormat(format);
						}
					}
					catch
					{
					}
				}
				else
					reader.Start();
				stop = true;

				while (_continue)
				{
					if (_format != null && camera != null)
					{
						camera.SetCurrentFormat(_format);
						_format = null;
					}

					using (var image = camera != null ? camera.GetFrame() : reader.ReadVideoSample())
					{
						if (image != null)
						{
							BeginInvoke(new Action<Bitmap>(OnImageCaptured), image.ToBitmap());
						}
						else
							break;
					}
				}
			}
			catch (Exception ex)
			{
				BeginInvoke(new Action<string>(SetHint), $"Capture failed: {ex.Message}");
			}
			finally
			{
				if (stop)
				{
					if (camera != null)
						camera.StopCapturing();
					else
						reader.Stop();
				}
				reader?.Dispose();
			}
		}

		private bool GetDimensions(out int w, out int h, out float scale, out float dx, out float dy)
		{
			w = h = 0;
			dx = dy = scale = float.NaN;

			const int Padding = 20;
			var image = _image;
			if (image != null)
			{
				w = image.Width;
				h = image.Height;
				var scalex = (float)(panelImage.Width - Padding * 2) / w;
				var scaley = (float)(panelImage.Height - Padding * 2) / h;
				scale = Math.Min(scalex, scaley);
				dx = (panelImage.Width - w * scale) / 2.0f;
				dy = (panelImage.Height - h * scale) / 2.0f;
				return true;
			}

			return false;
		}

		private ToolType GetSearchAreaToolType()
		{
			if (rbGridTool.Checked)
				return ToolType.Grid;
			else if (tsbIncludeRect.Checked)
				return ToolType.IncludeRect;
			else if (tsbExcludeRect.Checked)
				return ToolType.ExcludeRect;
			else if (tsbExcludePolygon.Checked)
				return ToolType.ExcludePolygon;
			else if (tsbIncludePolygon.Checked)
				return ToolType.IncludePolygon;

			return ToolType.Grid;
		}

		private void UndoChange()
		{
			var pop = _undoStack.Pop();
			if (pop != null)
			{
				SubscribeToToolEvents(_activeTool, pop);
				pop.CurrentPosition = _activeTool.CurrentPosition;
				_activeTool = pop;

				SetHint(_activeTool.Hint);
				panelImage.Invalidate();
				Invalidate();
			}
		}

		private void SelectTool(ToolType value, Tool tool = null)
		{
			var previousTool = _activeTool;

			_activeTool = tool;
			if (previousTool?.IsSearchAreaTool == true)
			{
				_workingConfig.Areas.Clear();
				foreach (var area in previousTool.Grid)
				{
					_workingConfig.Areas.Add(area);
				}
			}

			if (tool == null)
			{
				if (value >= ToolType.Tripwire)
				{
					var triggerTool = new TriggerSelectionTool(value, _workingConfig.Triggers);
					_activeTool = triggerTool;
					if (TryGetTrigger(out var trigger))
					{
						triggerTool.SelectedValue = trigger;
					}
				}
				else if (value != ToolType.None)
				{
					if (_workingConfig.IsGrid != (value == ToolType.Grid) ||
						(value == ToolType.Grid && (nudRows.Value * nudColumns.Value != _workingConfig.Areas.Count)))
					{
						_workingConfig.Rows = Convert.ToInt32(nudRows.Value);
						_workingConfig.Columns = Convert.ToInt32(nudColumns.Value);
						_workingConfig.Areas.Clear();
					}

					_activeTool = value == ToolType.Grid ?
						(Tool)new GridTool(_undoStack, Convert.ToInt32(nudRows.Value), Convert.ToInt32(nudColumns.Value), _workingConfig.Areas) :
						new PolygonSelectionTool(_undoStack, value, _workingConfig.Areas);
				}
				else
				{
					_activeTool = null;
				}
			}
			SubscribeToToolEvents(previousTool, _activeTool);

			_undoStack.Clear();

			bool isGrid = value == ToolType.Grid;
			nudRows.Enabled = nudColumns.Enabled = isGrid;
			if (isGrid)
			{
				nudRows.Value = _workingConfig.Rows;
				nudColumns.Value = _workingConfig.Columns;
			}
			if (value < ToolType.Tripwire && value != ToolType.None)
			{
				rbGridTool.Checked = isGrid;
				rbToolRegions.Checked = !isGrid;
			}
			tsbIncludeRect.Enabled = tsbExcludeRect.Enabled = tsbIncludePolygon.Enabled = tsbExcludePolygon.Enabled = !isGrid;
			SetHint(_activeTool?.Hint ?? "Select source preset & media format");
			PersistSearchArea(tool);

			panelImage.Invalidate();
			Invalidate();
		}

		private void PersistSearchArea(Tool tool)
		{
			if (tool is GridTool gridTool)
			{
				_workingConfig.Rows = Convert.ToInt32(nudRows.Value);
				_workingConfig.Columns = Convert.ToInt32(nudColumns.Value);
				_workingConfig.IsGrid = true;
				_workingConfig.Areas.Clear();
				foreach (var e in gridTool.Grid)
				{
					_workingConfig.Areas.Add(e);
				}
			}
			else if (tool is PolygonSelectionTool polygonTool)
			{
				_workingConfig.IsGrid = false;
				_workingConfig.Areas.Clear();
				foreach (var e in polygonTool.Grid)
				{
					_workingConfig.Areas.Add(e);
				}
			}
		}

		private void OnToolPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Hint")
			{
				SetHint(_activeTool.Hint);
			}
		}

		private void SubscribeToToolEvents(Tool previousTool, Tool newTool)
		{
			if (previousTool != null)
				previousTool.PropertyChanged -= OnToolPropertyChanged;
			if (newTool != null)
				newTool.PropertyChanged += OnToolPropertyChanged;
		}

		private SourceConfiguration SaveConfig()
		{
			var area = _workingConfig.Areas.Select(x => x.ToArea()).ToList();
			if (_workingConfig.IsGrid && area.All(x => x.Type == NSearchAreaType.Include))
			{
				area.Clear();
			}

			return new SourceConfiguration
			{
				CheckSearchAreaByObjectCenter = _workingConfig.CheckSearchAreaByObjectCenter,
				Columns = _workingConfig.Columns,
				Rows = _workingConfig.Rows,
				IsGrid = _workingConfig.IsGrid,
				Areas = area,
				Triggers = _workingConfig.Triggers.Select(x => x.ToTrigger()).ToList(),
				SourceId = SourceState.Id,
				SettingsPreset = cbPreset.SelectedItem is Preset preset ? preset.PresetGUID : null,
			};
		}

		#endregion

		#region Private methods

		private void SelectRegionOfInterestFormShown(object sender, EventArgs e)
		{
			if (SourceState == null) throw new ArgumentNullException(nameof(SourceState));
			SetHint("Starting capture, please wait ...");

			cbPreset.Items.Add("Default");
			cbPreset.SelectedIndex = 0;
			foreach (var preset in SurveillanceConfig.Presets)
			{
				cbPreset.Items.Add(preset.Value);
				if (preset.Key == SourceState.SelectedPreset)
				{
					cbPreset.SelectedItem = preset.Value;
				}
			}

			cbFormats.Items.Clear();
			if (SourceState.Formats != null)
			{
				cbFormats.Items.AddRange(SourceState.Formats);
				cbFormats.SelectedItem = SourceState.SelectedFormat;
			}

			_undoStack.StackIsEmptyChanged += (_, __) => btnUndo.Enabled = !_undoStack.IsEmpty;

			btnSelectColor.BackColor = TripwireTriggerType.DefaultColor;
			_workingConfig = SourceConfig != null ?
				new Config(SourceConfig)
				: new Config(Convert.ToInt32(nudColumns.Value), Convert.ToInt32(nudRows.Value));
			_workingConfig.Triggers.CollectionChanged += OnTriggersCollectionChanged;
			foreach (var trigger in _workingConfig.Triggers)
			{
				AddTrigger(trigger, false);
			}

			if (_workingConfig.Triggers.Any() || _workingConfig.Areas.Any() == false)
			{
				ShowConfig(ConfigType.Triggers);
				SelectTool(ToolType.Tripwire);
			}
			else
			{
				ShowConfig(ConfigType.SearchArea);
				SelectTool(_workingConfig.IsGrid ? ToolType.Grid : ToolType.IncludeRect);
			}
			chbAreaByCenter.Checked = _workingConfig.CheckSearchAreaByObjectCenter;

			_thread = new Thread(CaptureThread);
			_thread.Start();
		}

		private void SelectRegionOfInterestFormClosing(object sender, FormClosingEventArgs e)
		{
			_continue = false;
			if (_thread != null)
			{
				_thread.Join();
			}
			_image?.Dispose();
			SubscribeToToolEvents(_activeTool, null);
			if (_workingConfig != null)
				_workingConfig.Triggers.CollectionChanged -= OnTriggersCollectionChanged;
		}

		private ListViewItem AddTrigger(ToolData trigger, bool byUser)
		{
			bool isTripwire = trigger.Polygon.Count == 2;
			if (byUser)
				trigger.Color = btnSelectColor.BackColor;
			lvTriggers.SuspendLayout();
			var lvi = new ListViewItem(new[] { string.Empty, trigger.Name, string.Empty })
			{
				ImageIndex = isTripwire ? 0 : 1,
			};
			lvi.UseItemStyleForSubItems = false;
			lvi.SubItems[2].BackColor = trigger.Color;

			lvTriggers.Items.Add(lvi);
			lvi.Selected = byUser;
			lvTriggers.ResumeLayout();
			return lvi;
		}

		private void OnTriggersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				if (_activeTool is TriggerSelectionTool tool)
				{
					AddTrigger((ToolData)e.NewItems[0], true);
					tbName.Focus();
				}
			}
		}

		private void BtnResetClick(object sender, EventArgs e)
		{
			_undoStack.Clear();
			var toolType = _activeTool.ToolType;
			_activeTool = null;
			_workingConfig.Areas.Clear();
			SelectTool(toolType);
			panelImage.Invalidate();
			Invalidate();
		}

		private void PanelImagePaint(object sender, PaintEventArgs e)
		{
			if (_image != null)
			{
				GetDimensions(out var w, out var h, out var scale, out var dx, out var dy);
				if (scale == 0)
					return;

				var g = e.Graphics;
				g.TranslateTransform(dx, dy);
				g.ScaleTransform(scale, scale);
				g.DrawImage(_image, 0, 0);
				_activeTool?.Paint(g, w, h, scale, ModifierKeys);
			}
		}

		private void PanelImageMouseMove(object sender, MouseEventArgs e)
		{
			if (GetDimensions(out var w, out var h, out var scale, out var dx, out var dy) && _activeTool != null)
			{
				var imagePosition = Tool.ToImagePosition(e.Location, dx, dy, scale);
				if (_activeTool.OnMouseMove(imagePosition, w, h, ModifierKeys, MouseButtons))
				{
					panelImage.Invalidate();
				}
			}
		}

		private void PanelImageMouseUp(object sender, MouseEventArgs e)
		{
			if (GetDimensions(out var w, out var h, out var scale, out var dx, out var dy) && _activeTool != null)
			{
				var imagePosition = Tool.ToImagePosition(e.Location, dx, dy, scale);
				if (e.Button == MouseButtons.Left && _activeTool.OnMouseLeftUp(imagePosition, w, h))
				{
					panelImage.Invalidate();
				}
			}
		}

		private void PanelImageMouseDown(object sender, MouseEventArgs e)
		{
			if (GetDimensions(out var w, out var h, out var scale, out var dx, out var dy) && _activeTool != null)
			{
				var imagePosition = Tool.ToImagePosition(e.Location, dx, dy, scale);
				if (e.Button == MouseButtons.Left && _activeTool.OnMouseLeftDown(imagePosition, w, h, ModifierKeys, e.Clicks))
				{
					panelImage.Invalidate();
				}
				panelImage.Focus();
			}
		}

		private void RadioBoxSelectionToolCheckedChanged(object sender, EventArgs e)
		{
			SelectTool(GetSearchAreaToolType());
		}

		private void NudGridValueChanged(object sender, EventArgs e)
		{
			SelectTool(ToolType.Grid);
		}

		private void ToolStripButtonClick(object sender, EventArgs e)
		{
			var target = (ToolStripButton)sender;
			if (target.Checked)
				return;

			tsbExcludeRect.Checked = tsbExcludePolygon.Checked = tsbIncludeRect.Checked = tsbIncludePolygon.Checked = false;
			target.Checked = true;
			if (_activeTool is PolygonSelectionTool tool)
			{
				tool.Mode = GetSearchAreaToolType();
				SetHint(tool.Hint);
			}
		}

		private void BtnUndoClick(object sender, EventArgs e)
		{
			UndoChange();
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			PersistSearchArea(_activeTool);
			SourceConfig = SaveConfig();

			var selectedFormat = cbFormats.SelectedItem as NMediaFormat;
			if (selectedFormat != null)
			{
				SourceState.SelectedFormat = selectedFormat;
				SourceState.OnChangeFormat(selectedFormat);
			}
			SourceConfig.PreferedFormat = selectedFormat?.ToString();
			DialogResult = DialogResult.OK;
		}

		private void PanelImageSizeChanged(object sender, EventArgs e)
		{
			panelImage.Invalidate();
		}

		private void TsbTriggerClick(object sender, EventArgs e)
		{
			var target = (ToolStripButton)sender;
			if (target.Checked)
				return;

			tsbNewRegionRect.Checked = tsbNewTripwire.Checked = tsbNewRegion.Checked = false;
			target.Checked = true;
			var type = ToolType.Tripwire;
			if (target == tsbNewRegion)
				type = ToolType.RegionTrigger;
			else if (target == tsbNewRegionRect)
				type = ToolType.RegionTriggerRect;
			SelectTool(type);
		}

		private void ShowConfigHeader(bool show, string text, Button btn, TableLayoutPanel panel)
		{
			btn.Text = show ? text : text + " ?";
			btn.BackColor = show ? SystemColors.Highlight : SystemColors.ActiveCaption;
			panel.Visible = show;
		}

		private void ShowConfig(ConfigType value)
		{
			tlpTools.SuspendLayout();

			ShowConfigHeader(value == ConfigType.Triggers, "Analytic Triggers", btnTriggers, tlpTriggers);
			ShowConfigHeader(value == ConfigType.SearchArea, "Search Areas", btnSearchAreas, tlpAreas);
			ShowConfigHeader(value == ConfigType.General, "General", btnGeneral, tlpGeneral);

			tlpTools.RowStyles[1].Height = 0;
			tlpTools.RowStyles[3].Height = 0;
			tlpTools.RowStyles[5].Height = 0;
			tlpTools.RowStyles[(int)value].Height = 100;

			tlpTools.ResumeLayout();

			if (value == ConfigType.SearchArea)
			{
				SelectTool(_workingConfig.IsGrid ? ToolType.Grid : ToolType.IncludeRect);
			}
			else if (value == ConfigType.Triggers)
			{
				SelectTool(ToolType.Tripwire);
			}
			else
			{
				SelectTool(ToolType.None);
			}

			Refresh();
		}

		private void BtnGeneralClick(object sender, EventArgs e)
		{
			ShowConfig(ConfigType.General);
		}

		private void BtnSearchAreasClick(object sender, EventArgs e)
		{
			ShowConfig(ConfigType.SearchArea);
		}

		private void BtnTriggersClick(object sender, EventArgs e)
		{
			ShowConfig(ConfigType.Triggers);
		}

		private void BtnSelectColorClick(object sender, EventArgs e)
		{
			var color = btnSelectColor.BackColor;
			var rgb = color.B << 16 | color.G << 8 | color.R;
			using (var dialog = new ColorDialog()
			{
				AnyColor = true,
				Color = btnSelectColor.BackColor,
				CustomColors = new[] { rgb }
			})
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					btnSelectColor.BackColor = dialog.Color;
					if (TryGetTrigger(out var sa, out var index))
					{
						var lvi = lvTriggers.Items[index].SubItems[2].BackColor = dialog.Color;
						sa.Color = dialog.Color;
						panelImage.Invalidate();
					}
				}
			}
		}

		private bool TryGetTrigger(out ToolData trigger, out int index)
		{
			index = -1;
			trigger = null;

			if (_activeTool == null)
				return false;

			var selection = lvTriggers.SelectedIndices.Count > 0 ? lvTriggers.SelectedIndices[0] : -1;
			if (selection != -1)
			{
				trigger = _activeTool.Grid[selection];
				index = selection;
				return true;
			}
			return false;
		}

		private bool TryGetTrigger(out ToolData trigger)
		{
			return TryGetTrigger(out trigger, out var _);
		}

		private void LvTriggersSelectedIndexChanged(object sender, EventArgs e)
		{
			void Enable(bool value, params Control[] controls)
				=> Array.ForEach(controls, c => c.Enabled = value);

			void Show(bool value, params Control[] controls)
				=> Array.ForEach(controls, c => c.Visible = value);

			if (TryGetTrigger(out var sa))
			{
				btnSelectColor.BackColor = sa.Color;
				tbName.Enabled = true;
				tbName.Text = sa.Name;
				cbOrigin.Enabled = true;
				cbOrigin.SelectedItem = sa.Origin;
				btnDeleteTrigger.Enabled = true;

				bool isTripwire = sa.IsTriggerTripwire();
				btnInvertTripwire.Visible = isTripwire;
				Show(!isTripwire, chbEventAppeared, chbEventDisappeared, chbEventTimer, lblEventMinDuration, nudEventMinumDuration, lblEventDuration, nudEventDuration);

				chbEventAppeared.Checked = sa.EventFilter.HasFlag(NAnalyticEventType.AppearedIn);
				chbEventDisappeared.Checked = sa.EventFilter.HasFlag(NAnalyticEventType.DisappearedIn);
				chbEventIn.Checked = sa.EventFilter.HasFlag(NAnalyticEventType.CrossedIn);
				chbEventOut.Checked = sa.EventFilter.HasFlag(NAnalyticEventType.CrossedOut);
				chbEventTimer.Checked = sa.EventFilter.HasFlag(NAnalyticEventType.Timer);
				nudEventMinumDuration.Value = Convert.ToDecimal(sa.EventTimerMinDuration);
				nudEventDuration.Value = Convert.ToDecimal(sa.EventTimerDuration);

				Enable(true, btnInvertTripwire, chbEventAppeared, chbEventDisappeared, chbEventIn, chbEventOut, chbEventTimer,
					lblEventDuration, nudEventMinumDuration, lblEventMinDuration, nudEventDuration, lblEventDuration);
			}
			else
			{
				btnSelectColor.BackColor = TripwireTriggerType.DefaultColor;
				tbName.Enabled = false;
				tbName.Text = string.Empty;
				cbOrigin.Enabled = false;
				cbOrigin.SelectedItem = NBoxOrigin.Center;
				btnDeleteTrigger.Enabled = false;

				Enable(false, btnInvertTripwire, chbEventAppeared, chbEventDisappeared, chbEventIn, chbEventOut, chbEventTimer,
					lblEventDuration, nudEventMinumDuration, lblEventMinDuration, nudEventDuration);
				Show(true, chbEventAppeared, btnInvertTripwire, chbEventDisappeared, chbEventIn, chbEventOut, chbEventTimer, lblEventMinDuration, nudEventMinumDuration, lblEventDuration, nudEventDuration);
			}

			if (_activeTool is TriggerSelectionTool tool)
			{
				tool.SelectedValue = sa;
			}
			lvTriggers.Invalidate();
			panelImage.Invalidate();
		}

		private void CbOriginSelectedIndexChanged(object sender, EventArgs e)
		{
			var origin = (NBoxOrigin)cbOrigin.SelectedItem;
			if (TryGetTrigger(out var trigger))
			{
				trigger.Origin = origin;
			}
		}

		private void TbNameTextChanged(object sender, EventArgs e)
		{
			var text = tbName.Text;
			if (TryGetTrigger(out var trigger, out var index))
			{
				trigger.Name = text;
				lvTriggers.Items[index].SubItems[1].Text = text;
			}
		}

		private void DeleteTrigger()
		{
			if (TryGetTrigger(out var trigger, out var index))
			{
				if (MessageBox.Show(this, $"Delete trigger '{trigger.Name}' ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					_workingConfig.Triggers.RemoveAt(index);
					lvTriggers.Items.RemoveAt(index);
					if (_activeTool is TriggerSelectionTool tool)
					{
						tool.Grid.RemoveAt(index);
					}
				}
			}
		}

		private void BtnInvertTripwireClick(object sender, EventArgs e)
		{
			if (TryGetTrigger(out var sa))
			{
				var tmp = sa.Polygon[0];
				sa.Polygon[0] = sa.Polygon[1];
				sa.Polygon[1] = tmp;
				panelImage.Invalidate();
			}
		}

		private void BtnDeleteTriggerClick(object sender, EventArgs e)
		{
			DeleteTrigger();
		}

		private void CbFormatsSelectedIndexChanged(object sender, EventArgs e)
		{
			_format = cbFormats.SelectedItem as NMediaFormat;
			panelImage.Invalidate();
		}

		#endregion

		#region Protected methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			const int Mask = 0x0FFFF;

			if (keyData.HasFlag(Keys.Z) && keyData.HasFlag(Keys.Control))
			{
				UndoChange();
				return true;
			}

			if (keyData.HasFlag(Keys.Delete))
			{
				if (!tbName.Focused && _activeTool is TriggerSelectionTool triggerTool && !triggerTool.Modifying)
				{
					DeleteTrigger();
					return true;
				}
			}

			bool escape = ((int)keyData & Mask) == (int)Keys.Escape;
			bool enter = ((int)keyData & Mask) == (int)Keys.Enter;
			if (enter || escape)
			{
				if (_activeTool is ICompleableTool tool && GetDimensions(out var w, out var h, out var _, out var __, out var ___))
				{
					tool.CompleteModification(w, h, enter);
					return true;
				}
				return false;
			}

			if (rbToolRegions.Checked)
			{
				var key = (Keys)((int)keyData & Mask);
				switch (key)
				{
					case Keys.D1:
					case Keys.NumPad1:
						tsbIncludeRect.PerformClick();
						break;
					case Keys.D2:
					case Keys.NumPad2:
						tsbExcludeRect.PerformClick();
						break;
					case Keys.D3:
					case Keys.NumPad3:
						tsbIncludePolygon.PerformClick();
						break;
					case Keys.D4:
					case Keys.NumPad4:
						tsbExcludePolygon.PerformClick();
						break;
					default:
						break;
				};
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion

		private bool OnEventTypeCheckedChanged(NAnalyticEventType type, bool value)
		{
			if (TryGetTrigger(out var sa))
			{
				bool isTripwire = sa.IsTriggerTripwire();
				if (isTripwire && !(type == NAnalyticEventType.CrossedIn || type == NAnalyticEventType.CrossedOut))
					return true;

				int EventsMask = isTripwire ?
						(int)(NAnalyticEventType.CrossedIn | NAnalyticEventType.CrossedOut) :
						(int)(NAnalyticEventType.AppearedIn | NAnalyticEventType.DisappearedIn | NAnalyticEventType.Timer | NAnalyticEventType.TimerStop | NAnalyticEventType.TimerStart | NAnalyticEventType.CrossedIn | NAnalyticEventType.CrossedOut);

				if (value)
				{
					sa.EventFilter |= type;
					if (!isTripwire && sa.EventFilter == (NAnalyticEventType)EventsMask)
					{
						sa.EventFilter = NAnalyticEventType.All;
					}
				}
				else
				{
					var newValue = (NAnalyticEventType)((~(int)type) & (int)sa.EventFilter & EventsMask);
					if (newValue == NAnalyticEventType.None)
					{
						SystemSounds.Beep.Play();
						return false;
					}

					sa.EventFilter = newValue;
				}
			}

			return true;
		}

		private void NudEventMinumDurationValueChanged(object sender, EventArgs e)
		{
			if (TryGetTrigger(out var sa) && !sa.IsTriggerTripwire())
			{
				sa.EventTimerMinDuration = Convert.ToDouble(nudEventMinumDuration.Value);
			}
		}

		private void NudEventDurationValueChanged(object sender, EventArgs e)
		{
			if (TryGetTrigger(out var sa) && !sa.IsTriggerTripwire())
			{
				sa.EventTimerDuration = Convert.ToDouble(nudEventDuration.Value);
			}
		}

		private void ChbEventAppearedCheckedChanged(object sender, EventArgs e)
		{
			if (!OnEventTypeCheckedChanged(NAnalyticEventType.AppearedIn, chbEventAppeared.Checked))
				chbEventAppeared.Checked = true;
		}

		private void ChbEventInCheckedChanged(object sender, EventArgs e)
		{
			if (!OnEventTypeCheckedChanged(NAnalyticEventType.CrossedIn, chbEventIn.Checked))
				chbEventIn.Checked = true;
		}

		private void ChbEventOutCheckedChanged(object sender, EventArgs e)
		{
			if (!OnEventTypeCheckedChanged(NAnalyticEventType.CrossedOut, chbEventOut.Checked))
				chbEventOut.Checked = true;
		}

		private void ChbEventDisappearedCheckedChanged(object sender, EventArgs e)
		{
			if (!OnEventTypeCheckedChanged(NAnalyticEventType.DisappearedIn, chbEventDisappeared.Checked))
				chbEventDisappeared.Checked = true;
		}

		private void ChbEventTimerCheckedChanged(object sender, EventArgs e)
		{
			if (!OnEventTypeCheckedChanged(NAnalyticEventType.Timer | NAnalyticEventType.TimerStart | NAnalyticEventType.TimerStop, chbEventTimer.Checked))
				chbEventTimer.Checked = true;
		}
	}
}
