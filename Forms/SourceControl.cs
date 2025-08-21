using Neurotec.Media;
using Neurotec.Samples.Code;
using Neurotec.Samples.Config;
using Neurotec.Samples.Config.Forms;
using Neurotec.Samples.Properties;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class SourceControl : UserControl
	{
		#region Private fields

		private SourceController _state;
		private Color _borderColor = Color.Black;
		private ToolTip _warningTip = new ToolTip();

		#endregion

		#region Public constructor

		public SourceControl()
		{
			InitializeComponent();

			EnableControls();
		}

		#endregion

		#region Public properties

		public SourceController State
		{
			get { return _state; }
			set { OnStateChanged(value); }
		}

		#endregion

		#region Public methods

		public void UpdatePresetLabel()
		{
			Dictionary<string, Preset> presets = SurveillanceConfig.Presets;
			if (State.SelectedPreset != null && presets.TryGetValue(State.SelectedPreset, out Preset preset))
			{
				lblPreset.Text = $"Preset: {preset.Name}";
			}
			else
			{
				lblPreset.Text = "Preset: Default";
			}
		}

		#endregion

		#region Private methods

		public static bool IsMoreThanOneFlagSet(NSurveillanceModalityType value)
		{
			return (value & (value - 1)) != 0;
		}

		private async void OnStateChanged(SourceController value)
		{
			if (_state != null)
			{
				_state.PropertyChanged -= OnStatePropertyChanged;
				_state.Source.PropertyChanged -= OnSourcePropertyChanged;
			}

			_state = value;
			if (_state != null)
			{
				lblName.Text = _state.ToString();
				_state.PropertyChanged += OnStatePropertyChanged;
				tsbReplay.Text = _state.Source.Video != null ? "Replay" : "Retry";
				tsbObjects.Checked = _state.ModalityType.HasFlag(NSurveillanceModalityType.VehiclesAndHumans);
				tsbLpr.Checked = _state.ModalityType.HasFlag(NSurveillanceModalityType.LicensePlateRecognition);
				tsbFaces.Checked = _state.ModalityType.HasFlag(NSurveillanceModalityType.Faces);
				if (IsMoreThanOneFlagSet(_state.SupportedModalities))
				{
					toolStripModalities.Enabled = true;
					tsbLpr.Visible = _state.SupportedModalities.HasFlag(NSurveillanceModalityType.LicensePlateRecognition);
					tsbObjects.Visible = _state.SupportedModalities.HasFlag(NSurveillanceModalityType.VehiclesAndHumans);
					tsbFaces.Visible = _state.SupportedModalities.HasFlag(NSurveillanceModalityType.Faces);
				}
				else
				{
					toolStripModalities.Enabled = false;
				}
				tsbChangePassword.Visible = _state.CanChangePassword;
				UpdatePresetLabel();
				EnableControls();

				try
				{
					var formats = await Task.Run(() => GetAvailableFormats(value.Source));
					if (formats.Any())
					{
						_state.Formats = formats;
						_state.SelectedFormat = formats[0];

						if (SurveillanceConfig.SourceConfig.TryGetValue(_state.Id, out var config) && config.PreferedFormat != null)
						{
							foreach (var f in formats)
							{
								if (f.ToString() == config.PreferedFormat)
								{
									_state.SelectedFormat = f;
									_state.OnChangeFormat(f);
								}
							}
						}
					}
				}
				catch
				{
				}

				_state.Source.PropertyChanged += OnSourcePropertyChanged;
			}
			else
			{
				lblName.Text = "SourceName";
				lblPreset.Text = "Preset: Default";
			}
		}

		private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CurrentFormat" && _state.Formats != null && _state.Formats.Length == 0)
			{
				BeginInvoke(new Action(() =>
				{
					if (IsHandleCreated)
					{
						NMediaFormat[] formats = new NMediaFormat[1];
						formats[0] = _state.Source.GetCurrentFormat();
						_state.Formats = formats;
						_state.SelectedFormat = formats[0];
					}
				}));
			}

			if (e.PropertyName == "Warning")
			{
				BeginInvoke(new Action(() =>
				{
					if (_state.Source.Warning != null)
					{
						pbWarning.Visible = true;
						_warningTip.SetToolTip(pbWarning, State.Source.Warning);
					}
					else
					{
						pbWarning.Visible = false;
					}
				}));
			}
		}

		private void OnStatePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (this.IsHandleCreated)
			{
				if (e.PropertyName == "IsSelected")
				{
					BeginInvoke(new Action(Invalidate));
				}
				else if (e.PropertyName == "Replay" || e.PropertyName == "ReplayTimeout")
				{
					BeginInvoke(new Action(OnReplayOrTimeoutChanged));
				}
				else if (e.PropertyName == "TrackingType")
				{
					BeginInvoke(new Action(() =>
					{
						tsbLpr.Checked = State.ModalityType.HasFlag(NSurveillanceModalityType.LicensePlateRecognition);
						tsbObjects.Checked = State.ModalityType.HasFlag( NSurveillanceModalityType.VehiclesAndHumans);
						tsbFaces.Checked = State.ModalityType.HasFlag(NSurveillanceModalityType.Faces);
					}));
				}
				else if (e.PropertyName == "SelectedPreset")
				{
					BeginInvoke(new Action(() =>
					{
						UpdatePresetLabel();
					}));
				}
				else
				{
					BeginInvoke(new Action(EnableControls));
				}
			}
		}

		private void OnReplayOrTimeoutChanged()
		{
			bool isVideo = _state.Source.Video != null;
			if (isVideo)
			{
				tsbReplay.Text = "Replay";
			}
			else
			{
				if (_state.ReplayTimeout != -1)
				{
					tsbReplay.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					tsbReplay.Text = _state.ReplayTimeout != 0 ? $"Retry (in {_state.ReplayTimeout}s)" : "Retrying";
				}
				else
				{
					tsbReplay.DisplayStyle = ToolStripItemDisplayStyle.Image;
					tsbReplay.Text = "Retry";
				}
			}
		}

		private void EnableControls()
		{
			if (_state != null)
			{
				tsbStart.Enabled = _state.CanStart;
				tsbStop.Enabled = _state.CanStop;
				tsbShow.Enabled = _state.CanHide || _state.CanShow;
				tsbFaces.Enabled = _state.CanStart;
				tsbObjects.Enabled = _state.CanStart;
				tsbLpr.Enabled = _state.CanStart;
				tsbChangePassword.Enabled = _state.CanStart;
				tsbSettings.Enabled = _state.CanStart;

				if (!_state.CanHide)
				{
					tsbShow.Image = Resources.Eye;
					tsbShow.ToolTipText = "Show";
				}
				else
				{
					tsbShow.Image = Resources.CrosedEye;
					tsbShow.ToolTipText = "Hide";
				}
			}
			else
			{
				tsbStart.Enabled = false;
				tsbStop.Enabled = false;
				tsbShow.Enabled = false;
				tsbObjects.Enabled = false;
				tsbLpr.Enabled = false;
				tsbSettings.Enabled = false;
			}
		}

		private NMediaFormat[] GetAvailableFormats(NSurveillanceSource source)
		{
			var formats = source.GetFormats().ToList();
			var currentFormat = source.GetCurrentFormat();
			if (currentFormat != null)
			{
				int index = formats.IndexOf(currentFormat);
				if (index != -1)
				{
					formats.RemoveAt(index);
				}
				formats.Insert(0, currentFormat);
			}
			return formats.ToArray();
		}

		private void SourceControlMouseDown(object sender, MouseEventArgs e)
		{
			if (State != null)
			{
				DoDragDrop(State, DragDropEffects.Move | DragDropEffects.Link);
				State.SelectSource();
			}
		}

		private void TsbStartClick(object sender, EventArgs e)
		{
			State.SelectSource();
			State.OnStart();
		}

		private void TsbStopClick(object sender, EventArgs e)
		{
			State.SelectSource();
			State.OnStop();
		}

		private void TsbShowClick(object sender, EventArgs e)
		{
			State.SelectSource();
			if (State.CanShow)
				State.OnShow();
			else
				State.OnHide();
		}

		private async void TsbReplayClick(object sender, EventArgs e)
		{
			bool value = !tsbReplay.Checked;
			State.Replay = value;
			State.SelectSource();
			tsbReplay.Checked = value;
			if (State.RetryTask != null)
			{
				State.CancellationSource.Cancel();
				await State.RetryTask;
				State.CancellationSource = null;
				State.RetryTask = null;
				State.ReplayTimeout = -1;
			}
		}

		private void TsbSettingsClick(object sender, EventArgs e)
		{
			SurveillanceConfig.SourceConfig.TryGetValue(_state.Id, out var sourceConfig);
			using (var form = new SourceConfigurationForm() { SourceState = _state, SourceConfig = sourceConfig })
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					State.OnChangeSearchArea(form.SourceConfig);
				}
			}
		}

		private void OnModalityCheckChanged(bool check, NSurveillanceModalityType modality)
		{
			var value = State.ModalityType;
			if (check)
				value |= modality;
			else
				value &= ~modality;

			if (value == NSurveillanceModalityType.None)
			{
				bool SetIfSupported(NSurveillanceModalityType t, ToolStripButton tsb)
				{
					if (modality != t && State.SupportedModalities.HasFlag(t))
					{
						tsb.Checked = true;
						value |= t;
						return true;
					}
					return false;
				}

				if (!SetIfSupported(NSurveillanceModalityType.Faces, tsbFaces))
				{
					if (!SetIfSupported(NSurveillanceModalityType.VehiclesAndHumans, tsbObjects))
						SetIfSupported(NSurveillanceModalityType.LicensePlateRecognition, tsbLpr);
				}
			}

			State.ModalityType = value;
		}

		private void TsbObjectsClick(object sender, EventArgs e)
		{
			State.SelectSource();
			OnModalityCheckChanged(tsbObjects.Checked, NSurveillanceModalityType.VehiclesAndHumans);
		}

		private void TsbLprClick(object sender, EventArgs e)
		{
			State.SelectSource();
			OnModalityCheckChanged(tsbLpr.Checked, NSurveillanceModalityType.LicensePlateRecognition);
		}

		private void TsbFacesClick(object sender, EventArgs e)
		{
			State.SelectSource();
			OnModalityCheckChanged(tsbFaces.Checked, NSurveillanceModalityType.Faces);
		}

		private void TsbChangePasswordClick(object sender, EventArgs e)
		{
			State.SelectSource();
			using (var dialog = new OnvifConfigDialog() { Camera = _state.Source.Camera })
			{
				dialog.ShowDialog();
			}
		}

		#endregion

		#region Protected methods

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			var g = e.Graphics;
			bool isSelected = State?.IsSelected == true;
			using (var pen = new Pen(isSelected ? SystemColors.HotTrack : Color.Black, isSelected ? 2 : 1))
			{
				g.DrawRectangle(pen, ClientRectangle.X + 1, ClientRectangle.Y + 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
			}
		}
		#endregion
	}
}
