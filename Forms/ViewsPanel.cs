using Neurotec.Samples.Code;
using Neurotec.Samples.Properties;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using static Neurotec.Samples.Forms.LayoutDefinition;

namespace Neurotec.Samples.Forms
{

	public class ViewsPanel : Panel, INotifyPropertyChanged
	{
		#region Private types

		private class CustomLayoutEngine : LayoutEngine
		{
			#region Public methods

			public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
			{
				var parent = (ViewsPanel)container;
				var parentDisplayRectangle = parent.DisplayRectangle;

				var width = parentDisplayRectangle.Width;
				var height = parentDisplayRectangle.Height;

				foreach (var pair in parent._active)
				{
					var c = (Control)pair.View;
					var info = pair.Info;

					var rect = GetRectangle(info, width, height);
					c.Location = new Point(rect.X + c.Margin.Left, rect.Y + c.Margin.Top);
					c.Size = new Size(rect.Width - c.Margin.Horizontal, rect.Height - c.Margin.Vertical);
				}

				return false;
			}

			#endregion
		}

		private class ActiveEntry
		{
			public SourceController State { get; set; }
			public SurveillanceView View { get; set; }
			public ViewInfo Info { get; set; }
		}

		#endregion

		#region Public constructor

		public ViewsPanel()
		{
			InitializeComponent();

			DoubleBuffered = true;
			AllowDrop = true;
			_layoutDefinition = LayoutDefinition.GetLayouts().FirstOrDefault();
			_layoutEngine = new CustomLayoutEngine();
		}

		#endregion

		#region Private fields

		private List<ActiveEntry> _active = new List<ActiveEntry>();
		private Layout _layoutDefinition;
		private CustomLayoutEngine _layoutEngine;
		private List<SourceController> _states = new List<SourceController>();
		#endregion

		#region Public properties

		public override LayoutEngine LayoutEngine => _layoutEngine;

		public Layout ViewsLayout
		{
			get
			{
				return _layoutDefinition;
			}
			set
			{
				if (_layoutDefinition != value)
				{
					_layoutDefinition = value;
					if (value != null)
					{
						var active = _active.OrderBy(x => x.Info.Index).ToArray();

						// First reassign views into available positions
						int index = 0;
						foreach (var entry in active.Take(value.Count))
						{
							entry.Info = value.Positions[index++];
						}

						// Remove all views that does not fit anymore
						var remaining = active.Skip(value.Count).ToArray();
						foreach (var entry in remaining)
						{
							HideSourceEntry(entry);
						}

						if (remaining.Any() || active.Length == value.Count)
						{
							MarkNotShownAsNonShowable();
						}
						else
						{
							MarkNotShownAsShowable();
						}

						PerformLayout();
						Invalidate();
					}
					else
					{
						Clear();
					}
				}
			}
		}

		#endregion

		#region Public methods

		public void AddState(SourceController state)
		{
			state.Hide += OnSourceHide;
			state.Show += OnSourceShow;
			state.PropertyChanged += OnStatePropertyChanged;
			state.CanShow = _active.Count < _layoutDefinition.Count;
			_states.Add(state);
		}

		public SurveillanceView GetView(NSurveillanceSource source)
		{
			return _active.FirstOrDefault(x => object.Equals(x.State.Source, source))?.View;
		}

		private void OnStatePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsSelected")
			{
				BeginInvoke(new Action(Invalidate));
			}
		}

		public void RemoveState(SourceController state)
		{
			state.Show -= OnSourceShow;
			state.OnHide();
			state.Hide -= OnSourceHide;
			state.PropertyChanged -= OnStatePropertyChanged;
			_states.Remove(state);
		}

		public void Clear()
		{
			foreach (var state in _states)
			{
				RemoveState(state);
			}
			PerformLayout();
			Invalidate();
		}

		#endregion

		#region Protected methods

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_layoutDefinition != null)
			{
				foreach (var info in _layoutDefinition.Positions)
				{
					var rect = GetRectangle(info, Width, Height);
					e.Graphics.FillRectangle(Brushes.White, rect);
					ActiveEntry active = null;
					if (TryGetActive(info, out active) && active.State.IsSelected)
					{
						e.Graphics.DrawRectangle(SystemPens.HotTrack, rect);
					}
				}
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			Invalidate();
		}

		#endregion

		#region Private methods

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ViewsPanel
			// 
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ViewsPanelDragDrop);
			this.DragOver += new System.Windows.Forms.DragEventHandler(this.ViewsPanelDragOver);
			this.ResumeLayout(false);

		}

		private void MarkNotShownAsNonShowable()
		{
			// there are no available place in layout
			foreach (var state in GetNotActive())
			{
				state.CanShow = false;
			}
		}

		private void MarkNotShownAsShowable()
		{
			// new spaces in layout available
			foreach (var state in GetNotActive())
			{
				state.CanShow = true;
			}
		}

		private bool TryGetActive(ViewInfo info, out ActiveEntry value)
		{
			value = _active.FirstOrDefault(x => info == x.Info);
			return value != null;
		}

		private bool TryGetActive(SourceController state, out ActiveEntry value)
		{
			value = _active.FirstOrDefault(x => x.State == state);
			return value != null;
		}

		private IEnumerable<SourceController> GetNotActive()
		{
			return _states.Except(_active.Select(x => x.State));
		}

		private void OnSourceShow(object sender, EventArgs e)
		{
			var state = sender as SourceController;
			var slot = _layoutDefinition.Positions.Except(_active.Select(x => x.Info)).FirstOrDefault();
			if (slot != null)
			{
				ShowStateOnEmpty(slot, state);
				state.CanShow = false;
				state.CanHide = true;

				if (_active.Count >= _layoutDefinition.Count)
				{
					MarkNotShownAsNonShowable();
				}
			}
		}

		private void HideSourceEntry(ActiveEntry entry)
		{
			MainForm main = (MainForm)this.FindForm();
			var first = main.splitContainerViewAndDetails.Panel1.Controls[0].Controls.OfType<SurveillanceView>().FirstOrDefault();

			if (first != null && first == entry.View)
			{
				main.expandPanel.ClientSizeChanged -= ExpandPanelClientSizeChanged;
				main.splitContainerViewAndDetails.Panel2Collapsed = false;
				main.splitContainerViewAndDetails.Panel1Collapsed = true;
				if (first != null)
					Controls.Add(first);
				main.toolLayout.Enabled = true;
				main.splitContainerViewAndDetails.Panel2.Invalidate();
			}

			_active.Remove(entry);
			entry.View.State = null;
			Controls.Remove((Control)entry.View);
			(entry.View as IDisposable)?.Dispose();
			entry.State.CanHide = false;
			entry.State.CanShow = true;
			if (entry.State.IsSelected)
			{
				Invalidate();
			}
		}

		private void OnSourceHide(object sender, EventArgs e)
		{
			var state = sender as SourceController;
			ActiveEntry entry = null;
			if (TryGetActive(state, out entry))
			{
				HideSourceEntry(entry);
				MarkNotShownAsShowable();
			}
		}

		private ViewInfo HitView(Point p)
		{
			return _layoutDefinition.Positions.FirstOrDefault(info =>
			{
				var rect = GetRectangle(info, Width, Height);
				return rect.X <= p.X && p.X <= rect.Right && rect.Y <= p.Y && p.Y <= rect.Bottom;
			});
		}

		private void ViewsPanelDragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(SourceController)) &&
				((e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link))
			{
				var info = HitView(PointToClient(new Point(e.X, e.Y)));
				if (info != null)
				{
					ActiveEntry entry = null;
					TryGetActive(info, out entry);
					var state = (SourceController)e.Data.GetData(typeof(SourceController));
					if (entry?.State != state)
					{
						e.Effect = DragDropEffects.Link;
					}
				}
			}
		}

		private void ViewsPanelDragDrop(object sender, DragEventArgs e)
		{
			var state = (SourceController)e.Data.GetData(typeof(SourceController));
			ActiveEntry from = null;
			ActiveEntry to = null;
			if (TryGetActive(state, out from))
			{
				var info = HitView(PointToClient(new Point(e.X, e.Y)));
				if (info == null) return;
				if (TryGetActive(info, out to))
				{
					// switch places
					to.Info = from.Info;
					from.Info = info;
				}
				else
				{
					// Move view
					from.Info = info;
				}
				PerformLayout();
			}
			else
			{
				var info = HitView(PointToClient(new Point(e.X, e.Y)));
				if (info == null) return;
				if (TryGetActive(info, out to))
				{
					HideSourceEntry(to);
				}

				ShowStateOnEmpty(info, state);
				if (_active.Count >= _layoutDefinition.Count)
				{
					MarkNotShownAsNonShowable();
				}
			}
			Invalidate();
		}

		private void ShowStateOnEmpty(ViewInfo target, SourceController state)
		{
			var view = new SurveillanceView { State = state };
			var entry = new ActiveEntry { Info = target, State = state, View = view };

			view.MouseDoubleClick += ViewDoubleClick;
			Controls.Add(view as Control);
			_active.Add(entry);

			state.CanShow = false;
			state.CanHide = true;

			PerformLayout();
			Invalidate();
		}

		private void ViewDoubleClick(object sender, EventArgs e)
		{
			SurveillanceView view = (SurveillanceView)sender;
			MainForm main = (MainForm)this.FindForm();
			if (!_layoutDefinition.Name.Equals("1 view: 1 x 1"))
			{
				if (!main.splitContainerViewAndDetails.Panel2Collapsed)
				{
					main.splitContainerViewAndDetails.Panel2Collapsed = true;
					main.splitContainerViewAndDetails.Panel1Collapsed = false;
					main.expandPanel.Controls.Add(view);
					view.SendToBack();
					view.Dock = DockStyle.Fill;
					view.ClientSize = main.splitContainerViewAndDetails.Panel1.ClientSize;
					view.Location = new Point(0, 0);
					main.splitContainerViewAndDetails.Refresh();
					main.toolLayout.Enabled = false;
					main.expandPanel.ClientSizeChanged += ExpandPanelClientSizeChanged;
				}
				else
				{
					main.expandPanel.ClientSizeChanged -= ExpandPanelClientSizeChanged;
					main.splitContainerViewAndDetails.Panel2Collapsed = false;
					main.splitContainerViewAndDetails.Panel1Collapsed = true;
					Controls.Add(view);
					main.toolLayout.Enabled = true;
					main.splitContainerViewAndDetails.Panel2.Invalidate();
				}
			}
		}

		public void ExpandPanelClientSizeChanged(object sender, EventArgs e)
		{
			Panel panel = (Panel)sender;
			SurveillanceView view = (SurveillanceView)((Panel)sender).Controls.OfType<SurveillanceView>().First();
			view.ClientSize = panel.ClientSize;
		}

		#endregion

		#region Private static methods

		private static Rectangle GetRectangle(ViewInfo info, int width, int height)
		{
			return new Rectangle(
				(int)(width * info.X + 1),
				(int)(height * info.Y + 1),
				(int)(width * info.Width - 2),
				(int)(height * info.Height - 2));
		}

		#endregion

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		private bool SetProperty<T>(ref T value, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!object.Equals(value, newValue))
			{
				value = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}

			return false;
		}

		#endregion
	}

	public class LayoutDefinition
	{
		#region Private constants

		private const float OneThird = 1f / 3f;
		private const float TwoThirds = 2f / 3f;

		#endregion

		#region Private constructor

		private LayoutDefinition()
		{
		}

		#endregion

		#region Nested types

		public class ViewInfo
		{
			#region Public constructor

			public ViewInfo(float x, float y, float width, float height)
			{
				this.X = x;
				this.Y = y;
				this.Width = width;
				this.Height = height;
			}

			#endregion

			#region Public properties

			public float X { get; set; }
			public float Y { get; set; }
			public float Width { get; set; }
			public float Height { get; set; }
			public int Index { get; set; }

			#endregion
		}

		public class Layout
		{
			#region Public constructor

			public Layout(string name, Image icon, params ViewInfo[] positions)
			{
				this.Name = name;
				this.Count = positions.Length;
				this.Icon = icon;
				this.Positions = positions;

				int index = 0;
				foreach (var pos in this.Positions)
				{
					pos.Index = index++;
				}
			}

			#endregion

			#region Public properties

			public int Count { get; set; }
			public ViewInfo[] Positions { get; set; }
			public string Name { get; set; }
			public Image Icon { get; set; }

			#endregion
		}

		#endregion

		#region Private static fields

		private static List<Layout> _definitions = new List<Layout>();

		#endregion

		#region Private static methods

		private static IEnumerable<Layout> ListLayouts()
		{
			// Single view
			ViewInfo[] positions = { new ViewInfo(0.00f, 0.00f, 1.00f, 1.00f) };
			yield return new Layout("1 view: 1 x 1", Resources.Layout1_1x1, positions);

			// 2 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 0.50f, 1.00f),
				new ViewInfo(0.50f, 0.00f, 0.50f, 1.00f)
			};
			yield return new Layout("2 views: 2 x 1", Resources.Layout2_2x1, positions);

			positions = new[] { new ViewInfo(0.00f, 0.00f, 1.00f, 0.50f), new ViewInfo(0.00f, 0.50f, 1.00f, 0.50f) };
			yield return new Layout("2 views: 1 x 2", Resources.Layout2_1x2, positions);

			// 3 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 1.00f, 0.50f),
				new ViewInfo(0.00f, 0.50f, 0.50f, 0.50f), new ViewInfo(0.50f, 0.50f, 0.50f, 0.50f)
				};
			yield return new Layout("3 views: 1 + 2 x 1", Resources.Layout3_1_2x1, positions);

			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 1.00f, OneThird),
				new ViewInfo(0.00f, OneThird, 1.00f, OneThird),
				new ViewInfo(0.00f, TwoThirds, 1.00f, OneThird)
			};
			yield return new Layout("3 views: 1 x 3", Resources.Layout3_1x3, positions);

			positions = new[] { new ViewInfo(0.00f, 0.00f, OneThird, 1.00f), new ViewInfo(OneThird, 0.00f, OneThird, 1.00f), new ViewInfo(TwoThirds, 0.00f, OneThird, 1.00f) };
			yield return new Layout("3 views: 3 x 1", Resources.Layout3_3x1, positions);

			// 4 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 0.50f, 0.50f), new ViewInfo(0.50f, 0.00f, 0.50f, 0.50f),
				new ViewInfo(0.00f, 0.50f, 0.50f, 0.50f), new ViewInfo(0.50f, 0.50f, 0.50f, 0.50f)
			};
			yield return new Layout("4 views: 2 x 2", Resources.Layout4_2x2, positions);

			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 1.00f, TwoThirds),
				new ViewInfo(0.00f, TwoThirds, OneThird, OneThird), new ViewInfo(OneThird, TwoThirds, OneThird, OneThird), new ViewInfo(TwoThirds, TwoThirds, OneThird, OneThird)
			};
			yield return new Layout("4 views: 1 + 3 x 1", Resources.Layout4_1_3x1, positions);

			positions = new[]
			{
				new ViewInfo(0.00f, 0.00f, TwoThirds, 1.00f), // column 1
				new ViewInfo(TwoThirds, 0.00f, OneThird, OneThird), new ViewInfo(TwoThirds, OneThird, OneThird, OneThird), new ViewInfo(TwoThirds, TwoThirds, OneThird, OneThird) // column 2
			};
			yield return new Layout("4 views: 1 + 1 x 3", Resources.Layout4_1_1x3, positions);

			// 5 views
			positions = new[]{
				new ViewInfo(0.00f, 0.00f, 0.50f, TwoThirds), new ViewInfo(0.50f, 0.00f, 0.50f, TwoThirds),
				new ViewInfo(0.00f, TwoThirds, OneThird, OneThird), new ViewInfo(OneThird, TwoThirds, OneThird, OneThird), new ViewInfo(TwoThirds, TwoThirds, OneThird, OneThird),
			};
			yield return new Layout("5 views: 2 x 1 + 3 x 1", Resources.Layout5_2x1_3x1, positions);

			// 6 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, OneThird, 0.50f), new ViewInfo(OneThird, 0.00f, OneThird, 0.50f), new ViewInfo(TwoThirds, 0.00f, OneThird, 0.50f),
				new ViewInfo(0.00f, 0.50f, OneThird, 0.50f), new ViewInfo(OneThird, 0.50f, OneThird, 0.50f), new ViewInfo(TwoThirds, 0.50f, OneThird, 0.50f)
			};
			yield return new Layout("6 views: 3 x 2", Resources.Layout6_3x2, positions);

			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 0.50f, OneThird), new ViewInfo(0.50f, 0.00f, 0.50f, OneThird),
				new ViewInfo(0.00f, OneThird, 0.50f, OneThird), new ViewInfo(0.50f, OneThird, 0.50f, OneThird),
				new ViewInfo(0.00f, TwoThirds, 0.50f, OneThird), new ViewInfo(0.50f, TwoThirds, 0.50f, OneThird),
			};
			yield return new Layout("6 views: 2 x 3", Resources.Layout6_2x3, positions);

			positions = new[] {
				new ViewInfo(0.00f, 0.00f, TwoThirds, TwoThirds), // Big one
				new ViewInfo(0.00f, TwoThirds, OneThird, OneThird), new ViewInfo(OneThird, TwoThirds, OneThird, OneThird), // Row 2 Without corner
				new ViewInfo(TwoThirds, 0.00f, OneThird, OneThird), new ViewInfo(TwoThirds, OneThird, OneThird, OneThird), // Column 2 without corner
				new ViewInfo(TwoThirds, TwoThirds, OneThird, OneThird), // Right bottom corner
			};
			yield return new Layout("6 views: 1 + 5", Resources.Layout6_1_5, positions);

			// 8 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 0.50f, 0.40f), new ViewInfo(0.50f, 0.00f, 0.50f, 0.40f), // Big 2x2
				new ViewInfo(0.00f, 0.40f, 0.50f, 0.40f), new ViewInfo(0.50f, 0.40f, 0.50f, 0.40f),
				new ViewInfo(0.00f, 0.80f, 0.25f, 0.20f), new ViewInfo(0.25f, 0.80f, 0.25f, 0.20f), new ViewInfo(0.50f, 0.80f, 0.25f, 0.20f), new ViewInfo(0.75f, 0.80f, 0.25f, 0.20f) // Row 2
			};
			yield return new Layout("8 views: 2 x 2 + 4 x 1", Resources.Layout8_2x2_4x1, positions);

			// 9 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, OneThird, OneThird), new ViewInfo(OneThird, 0.00f, OneThird, OneThird), new ViewInfo(TwoThirds, 0.00f, OneThird, OneThird),
				new ViewInfo(0.00f, OneThird, OneThird, OneThird), new ViewInfo(OneThird, OneThird, OneThird, OneThird), new ViewInfo(TwoThirds, OneThird, OneThird, OneThird),
				new ViewInfo(0.00f, TwoThirds, OneThird, OneThird), new ViewInfo(OneThird, TwoThirds, OneThird, OneThird), new ViewInfo(TwoThirds, TwoThirds, OneThird, OneThird),
			};
			yield return new Layout("9 views: 3 x 3", Resources.Layout9_3x3, positions);

			// 10 views
			positions = new[] {
				new ViewInfo(0.00f, 0.00f, 0.50f, 0.50f), new ViewInfo(0.50f, 0.00f, 0.50f, 0.50f),
				new ViewInfo(0.00f, 0.50f, 0.25f, 0.25f), new ViewInfo(0.25f, 0.50f, 0.25f, 0.25f), new ViewInfo(0.50f, 0.50f, 0.25f, 0.25f), new ViewInfo(0.75f, 0.50f, 0.25f, 0.25f),
				new ViewInfo(0.00f, 0.75f, 0.25f, 0.25f), new ViewInfo(0.25f, 0.75f, 0.25f, 0.25f), new ViewInfo(0.50f, 0.75f, 0.25f, 0.25f), new ViewInfo(0.75f, 0.75f, 0.25f, 0.25f)
			};
			yield return new Layout("10 views: 2 x 1 + 4 x 2", Resources.Layout10_2x1_4x2, positions);
		}

		#endregion

		#region Public static methods

		public static void Setup(int maxCameraCount)
		{
			if (_definitions.Any())
				throw new InvalidOperationException();

			_definitions.AddRange(ListLayouts().TakeWhile(x => x.Count <= maxCameraCount));
		}

		public static IEnumerable<Layout> GetLayouts()
		{
			return _definitions;
		}

		#endregion
	}
}
