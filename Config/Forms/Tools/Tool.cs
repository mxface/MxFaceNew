using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms.Tools
{

	public enum ToolType
	{
		None = -1,

		// Search Area
		Grid = 0,
		IncludePolygon,
		ExcludePolygon,
		IncludeRect,
		ExcludeRect,

		//Triggers
		Tripwire,
		RegionTrigger,
		RegionTriggerRect
	}

	public delegate bool ToolMouseFunc(PointF imagePosition, int w, int h, Keys modifierKeys, int clickCount);

	public abstract class Tool: INotifyPropertyChanged
	{
		#region Protected types

		protected class Line
		{
			#region Public constructor

			public Line(PointF p1, PointF p2)
			{
				if (p1.X < p2.X)
				{
					X1 = Convert.ToDecimal(p1.X);
					Y1 = Convert.ToDecimal(p1.Y);
					X2 = Convert.ToDecimal(p2.X);
					Y2 = Convert.ToDecimal(p2.Y);
				}
				else
				{
					X1 = Convert.ToDecimal(p2.X);
					Y1 = Convert.ToDecimal(p2.Y);
					X2 = Convert.ToDecimal(p1.X);
					Y2 = Convert.ToDecimal(p1.Y);
				}

				if (X2 != X1)
				{
					M = (Y2 - Y1) / (X2 - X1);
					B = Y1 - (M * X1);
				}
				else
				{
					M = 0;
					B = X1;
				}
			}

			#endregion

			#region Public properties

			public decimal X1 { get; private set; }
			public decimal Y1 { get; private set; }
			public decimal X2 { get; private set; }
			public decimal Y2 { get; private set; }
			public decimal M { get; private set; }
			public decimal B { get; private set; }

			#endregion

			#region Private methods

			private bool TestInterval(decimal x, decimal y)
			{
				var minx = Math.Min(X1, X2);
				var maxx = Math.Max(X1, X2);
				var miny = Math.Min(Y1, Y2);
				var maxy = Math.Max(Y1, Y2);

				return minx <= x && x <= maxx
					&& miny <= y && y <= maxy;
			}

			#endregion

			#region Public methods

			public bool Intersects(Line line, out PointF point)
			{
				point = PointF.Empty;
				if (M == line.M)
				{
					if (B == line.B)
					{
						// Same line, but maybe different ranges
						if (X1 != 0)
						{
							return (X1 < line.X1 && line.X1 < X2) || (X1 < line.X2 && line.X2 < X2);
						}
						else
						{
							return (Y1 < line.Y1 && line.Y1 < Y2) || (Y1 < line.Y2 && line.Y2 < Y2);
						}
					}
					return false;
				}
				else
				{
					var x = (line.B - B) / (M - line.M);
					var y = M * x + B;

					float Distance(decimal lx, decimal ly)
					{
						var a = lx - x;
						var b = ly - y;
						var cSquare = Convert.ToSingle(a * a + b * b);
						return (float)Math.Sqrt(cSquare);
					}

					point = new PointF(Convert.ToSingle(x), Convert.ToSingle(y));

					var diff1 = Math.Min(Distance(X1, Y1), Distance(X2, Y2));
					var diff2 = Math.Min(Distance(line.X1, line.Y1), Distance(line.X2, line.Y2));
					return TestInterval(x, y) && line.TestInterval(x, y) && diff1 > float.Epsilon && diff2 > float.Epsilon;
				}
			}

			#endregion
		}

		#endregion

		#region Public constructor

		public Tool(UndoStack undoStack)
		{
			Undo = undoStack ?? throw new ArgumentNullException(nameof(undoStack));
		}

		#endregion

		#region Public properties

		public PointF CurrentPosition { get; set; }
		public UndoStack Undo { get; private set; }
		public abstract bool IsValid { get; }
		public abstract string Hint { get; protected set; }
		public virtual bool IsSearchAreaTool { get; } = true;
		public abstract ToolType ToolType { get; }
		public List<ToolData> Grid { get; set; } = new List<ToolData>();
		public List<PointF> Points { get; set; } = new List<PointF>();

		#endregion

		#region Public events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Protected methods

		protected bool SetProperty<T>(ref T value, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(value, newValue))
			{
				value = newValue;
				OnPropertyChanged(propertyName);
			}
			return false;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected PointF ClampOnImageBorderIntersect(PointF p, PointF previous, int w, int h)
		{
			var topLeft = PointF.Empty;
			var topRigth = new PointF(w, 0);
			var bottomLeft = new PointF(0, h);
			var bottomRight = new PointF(w, h);

			var line = new Line(p, previous);
			var topLine = new Line(topLeft, topRigth);
			var bottomLine = new Line(bottomLeft, bottomRight);
			var leftLine = new Line(topLeft, bottomLeft);
			var rightLine = new Line(topRigth, bottomRight);
			if (line.Intersects(topLine, out var intersect) || line.Intersects(bottomLine, out intersect) ||
				line.Intersects(leftLine, out intersect) || line.Intersects(rightLine, out intersect))
			{
				return intersect;
			}

			return p;
		}

		protected Bitmap CreateRegionBitmap(int w, int h)
		{
			Bitmap bmp = null;

			try
			{
				bmp = new Bitmap(w, h);
				using (var g = Graphics.FromImage(bmp))
				using (var greenBrush = new SolidBrush(Color.FromArgb(50, 0, 255, 0)))
				using (var redBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0)))
				{
					Region topLevelUnion = null;
					foreach (var cell in Grid.AsEnumerable().Reverse())
					{
						using (var path = cell.CreatePath(w, h))
						{
							var activeRegion = new Region(path);
							if (topLevelUnion != null)
							{
								if (!activeRegion.IsEmpty(g) && !activeRegion.IsInfinite(g))
									activeRegion.Exclude(topLevelUnion);
								if (cell.Polygon?.Any() == false)
									topLevelUnion.Union(ToAbsolute(cell.Rect, w, h));
								else
									topLevelUnion.Union(activeRegion.Clone() as Region);
							}
							else
							{
								topLevelUnion = activeRegion;
							}

							g.FillRegion(cell.Include ? greenBrush : redBrush, activeRegion);
							if (topLevelUnion != activeRegion)
								activeRegion.Dispose();
						}
					}
					topLevelUnion?.Dispose();
				}
			}
			catch
			{
				bmp.Dispose();
				throw;
			}

			return bmp;
		}

		protected bool IsPolygonPointValid(PointF imagePosition)
		{
			return IsPolygonPointValid(Points, imagePosition, out var _);
		}

		protected bool IsPolygonPointValid(List<PointF> points, PointF imagePosition, out PointF intersectPoint)
		{
			intersectPoint = PointF.Empty;
			if (points.Count > 2)
			{
				var lastPoint = points.Last();
				var newLine = new Line(lastPoint, imagePosition);
				for (int i = 0; i < points.Count - 1; i++)
				{
					var p1 = points[i];
					var p2 = points[i + 1];
					var line = new Line(p1, p2);

					if (imagePosition != p1 && imagePosition != p2 && line.Intersects(newLine, out intersectPoint))
						return false;
				}
			}
			return true;
		}

		protected bool TryAddFinalPoint(int w, int h, bool addPoint)
		{
			var last = Points.LastOrDefault();
			var p = ClampOnImageBorderIntersect(CurrentPosition, last, w, h);
			p = ClampAbsolute(CurrentPosition, w, h);
			if (p == last)
			{
				addPoint = false;
			}

			if (addPoint)
			{
				if (Points.Count == 1 || !IsPolygonPointValid(p))
				{
					return false;
				}

				Undo.Push(Clone());
				Points.Add(p);
			}

			if (Points.Count >= 3)
			{
				if (!IsPolygonPointValid(Points.First()))
				{
					if (addPoint)
					{
						Points.RemoveAt(Points.Count - 1);
						Undo.Pop();
					}
					return false;
				}
				return true;
			}

			return false;
		}

		#endregion

		#region Public methods

		public abstract void Paint(Graphics g, int w, int h, float scale, Keys modifierKeys);

		public abstract Tool Clone();

		public virtual bool OnMouseMove(PointF imagePosition, int w, int h, Keys modifierKeys, MouseButtons mouseButtons)
		{
			CurrentPosition = imagePosition;
			return (mouseButtons & MouseButtons.Left) == MouseButtons.Left;
		}

		public virtual bool OnMouseLeftDown(PointF imagePosition, int w, int h, Keys modifierKeys, int clickCount)
		{
			return false;
		}

		public virtual bool OnMouseLeftUp(PointF pointPosition, int w, int h)
		{
			return false;
		}

		public virtual bool OnMouseRightDown(PointF imagePosition, int w, int h, Keys modifierKeys, int clickCount)
		{
			return false;
		}

		#endregion

		#region Public static methods

		public static RectangleF ToRelative(RectangleF rect, int w, int h)
		{
			return new RectangleF(rect.X / w, rect.Y / h, rect.Width / w, rect.Height / h);
		}

		public static PointF ToRelative(PointF point, int w, int h)
		{
			return new PointF(point.X / w, point.Y / h);
		}

		public static RectangleF ToAbsolute(RectangleF rect, int w, int h)
		{
			return new RectangleF(rect.X * w, rect.Y * h, rect.Width * w, rect.Height * h);
		}

		public static PointF ToAbsolute(PointF p, int w, int h)
		{
			return new PointF(p.X * w, p.Y * h);
		}

		public static PointF ClampAbsolute(PointF p, int w, int h)
		{
			return new PointF
			{
				X = Math.Min(w, Math.Max(0, p.X)),
				Y = Math.Min(h, Math.Max(0, p.Y)),
			};
		}

		public static RectangleF Clamp(RectangleF rect)
		{
			var result = rect;
			if (rect.X < 0)
			{
				result.Width += rect.X;
				result.X = 0;
			}
			if (rect.Y < 0)
			{
				result.Height += rect.Y;
				result.Y = 0;
			}
			if (rect.Right > 1)
			{
				result.Width -= rect.Right - 1;
			}
			if (rect.Bottom > 1)
			{
				result.Height -= rect.Bottom - 1;
			}
			return result;
		}

		public static PointF ToImagePosition(Point mouseLocation, float dx, float dy, float scale)
		{
			return new PointF((mouseLocation.X - dx) / scale, (mouseLocation.Y - dy) / scale);
		}

		#endregion

	}
}
