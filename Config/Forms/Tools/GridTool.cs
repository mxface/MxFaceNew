using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms.Tools
{
	public class GridTool : Tool
	{
		#region Public constructor

		public GridTool(UndoStack undoStack, int rows, int columns)
			: this(undoStack, rows, columns, CreateGrid(rows, columns))
		{
		}

		public GridTool(UndoStack undoStack, int rows, int columns, IEnumerable<ToolData> areas)
		: base(undoStack)
		{
			Grid = areas?.Any() == true ? areas.ToList() : CreateGrid(rows, columns).ToList();
		}

		#endregion

		#region Private constructor

		private GridTool(UndoStack undoStack)
			: base(undoStack)
		{
		}

		#endregion

		#region Public properties

		public ToolData CurrentRegion { get; set; }
		public override bool IsValid => Grid.Any(x => !x.Include);
		public override string Hint
		{
			get => "Click on rectangles to change if you want to search in specified area\n" +
			"Click while holding CTRL key to split rectangle into smaller pieces.";
			protected set => throw new NotSupportedException();
		}
		public override ToolType ToolType => ToolType.Grid;

		#endregion

		#region Private static methods

		private static IEnumerable<ToolData> CreateGrid(int rows, int columns)
		{
			var w = 1.0f / columns;
			var h = 1.0f / rows;

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					var rect = new RectangleF
					{
						X = column * w,
						Y = row * h,
						Width = w,
						Height = h
					};
					yield return new ToolData { Rect = rect, Include = true };
				}
			}
		}

		#endregion

		#region Private methods

		private void SplitCurrentReqion(int w, int h)
		{
			if (CurrentRegion != null)
			{
				Undo.Push(Clone());
				Grid.Remove(CurrentRegion);
				Grid.AddRange(SplitCurrentRegionInternal(w, h));
			}
		}

		private IEnumerable<ToolData> SplitCurrentRegionInternal(int w, int h)
		{
			var offsetX = CurrentPosition.X / w - CurrentRegion.Rect.X;
			var offsetY = CurrentPosition.Y / h - CurrentRegion.Rect.Y;

			var r = CurrentRegion.Rect;
			var topLeft = new ToolData
			{
				Include = CurrentRegion.Include,
				Rect = new RectangleF(r.X, r.Y, offsetX, offsetY)
			};
			yield return topLeft;

			var topRight = new ToolData
			{
				Include = CurrentRegion.Include,
				Rect = new RectangleF(r.X + offsetX, r.Y, r.Width - offsetX, offsetY)
			};
			yield return topRight;

			var bottomLeft = new ToolData
			{
				Include = CurrentRegion.Include,
				Rect = new RectangleF(r.X, r.Y + offsetY, offsetX, r.Height - offsetY)
			};
			yield return bottomLeft;

			var bottomRight = new ToolData
			{
				Include = CurrentRegion.Include,
				Rect = new RectangleF(r.X + offsetX, r.Y + offsetY, r.Width - offsetX, r.Height - offsetY)
			};
			yield return bottomRight;
		}

		#endregion

		#region Public methods

		public override bool OnMouseMove(PointF imagePosition, int w, int h, Keys modifierKeys, MouseButtons mouseButtons)
		{
			base.OnMouseMove(imagePosition, w, h, modifierKeys, mouseButtons);

			var relativePos = ToRelative(imagePosition, w, h);
			var region = Grid.FirstOrDefault(x => x.Rect.Contains(relativePos));
			if (region != null)
			{
				CurrentRegion = region;
				return true;
			}
			else if (CurrentRegion != null)
			{
				CurrentRegion = null;
				return true;
			}

			return (Keys.Control & modifierKeys) == Keys.Control;
		}

		public override bool OnMouseLeftDown(PointF imagePosition, int w, int h, Keys modifierKeys, int clickCount)
		{
			base.OnMouseLeftDown(imagePosition, w, h, modifierKeys, clickCount);

			if (CurrentRegion != null)
			{
				if ((modifierKeys & Keys.Control) == Keys.Control)
				{
					SplitCurrentReqion(w, h);
				}
				else
				{
					Undo.Push(Clone());
					CurrentRegion.Include = !CurrentRegion.Include;
				}
				return true;
			}
			return false;
		}

		public override void Paint(Graphics g, int w, int h, float scale, Keys modifierKeys)
		{
			using (var greenBrush = new SolidBrush(Color.FromArgb(50, 0, 255, 0)))
			using (var redBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0)))
			using (var greenActiveBrush = new SolidBrush(Color.FromArgb(90, 0, 255, 0)))
			using (var redActiveBrush = new SolidBrush(Color.FromArgb(90, 255, 0, 0)))
			{
				var pen = Pens.Black;
				foreach (var cell in Grid)
				{
					var rect = ToAbsolute(cell.Rect, w, h);
					if ((modifierKeys & Keys.Control) == Keys.Control)
					{
						g.DrawLine(pen, CurrentPosition.X, rect.Top, CurrentPosition.X, rect.Bottom);
						g.DrawLine(pen, rect.Left, CurrentPosition.Y, rect.Right, CurrentPosition.Y);
					}

					g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
					if (cell != CurrentRegion)
					{
						g.FillRectangle(cell.Include ? greenBrush : redBrush, rect);
					}
					else
					{
						g.FillRectangle(cell.Include ? greenActiveBrush : redActiveBrush, rect);
					}
				}
			}
		}

		public override Tool Clone()
		{
			return new GridTool(Undo)
			{
				Grid = Grid.Select(x => x.Clone()).ToList(),
			};
		}

		#endregion
	}
}
