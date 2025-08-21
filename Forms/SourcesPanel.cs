using Neurotec.Samples.Code;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Neurotec.Samples.Forms
{
	public partial class SourcesPanel : Panel
	{
		#region Private types

		private class CustomLayoutEngine : LayoutEngine
		{
			#region Public methods

			public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
			{
				var parent = (Control)container;
				var parentDisplayRectangle = parent.DisplayRectangle;
				int y = parentDisplayRectangle.Location.Y;
				int x = 0;

				var w = parentDisplayRectangle.Width;

				foreach (Control c in parent.Controls)
				{
					x = c.Margin.Left;
					y += c.Margin.Top;
					c.Location = new Point(x, y);
					c.Width = w - c.Margin.Left - c.Margin.Right;
					y += c.Height + c.Margin.Bottom;
				}

				if (y >= parentDisplayRectangle.Height)
				{
					foreach (Control c in parent.Controls)
					{
						c.Width -= SystemInformation.VerticalScrollBarWidth;
					}
				}

				return false;
			}

			#endregion
		}

		#endregion

		#region Public constructor

		public SourcesPanel()
		{
			DoubleBuffered = true;
			AutoScroll = true;
		}

		#endregion

		#region Public properties

		public override LayoutEngine LayoutEngine => new CustomLayoutEngine();

		#endregion

		#region Public methods

		public void AddSource(SourceController state)
		{
			var control = new SourceControl { State = state };
			Controls.Add(control);
		}

		public void RemoveSource(SourceController state)
		{
			var control = Controls.Cast<SourceControl>().FirstOrDefault(x => object.Equals(state, x.State));
			if (control != null)
			{
				control.State = null;
				Controls.Remove(control);
			}
		}

		public void ClearSources()
		{
			foreach (SourceControl control in Controls)
			{
				control.State = null;
			}
			Controls.Clear();
		}

		public void ScrollIntoView(SourceController state)
		{
			var control = Controls.Cast<SourceControl>().FirstOrDefault(x => object.Equals(state, x.State));
			if (control != null)
			{
				ScrollControlIntoView(control);
			}
		}

		#endregion
	}
}
