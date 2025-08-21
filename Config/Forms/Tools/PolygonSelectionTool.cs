using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms.Tools
{
	public class PolygonSelectionTool : Tool, ICompleableTool
	{
		#region Public constructor

		public PolygonSelectionTool(UndoStack undoStack, ToolType mode)
			: this(undoStack, mode, null)
		{
		}

		public PolygonSelectionTool(UndoStack undoStack, ToolType mode, IEnumerable<ToolData> area)
			: base(undoStack)
		{
			Mode = mode;
			Grid = area?.ToList() ?? new List<ToolData>();
		}

		#endregion

		#region Public properties

		public ToolType Mode { get; set; } = ToolType.IncludeRect;
		public bool IsInclude { get => Mode == ToolType.IncludeRect || Mode == ToolType.IncludePolygon; }
		public bool IsPolygon { get => Mode == ToolType.ExcludePolygon || Mode == ToolType.IncludePolygon; }
		public Bitmap RegionMap { get; set; }

		public override bool IsValid => Grid.Any();
		public override string Hint
		{
			get
			{
				switch (ToolType)
				{
					case ToolType.IncludePolygon:
						return "Click to select points of polygon region where search should be performed.\n" +
							"Press 'Esc', 'Enter' or double click to complete polygon selection.";
					case ToolType.ExcludePolygon:
						return "Click to select points of polygon region where search should NOT be performed.\n" +
							"Press 'Esc', 'Enter' or double click to complete polygon selection.";
					case ToolType.IncludeRect:
						return "Click and drag to select region where search should be performed.";
					case ToolType.ExcludeRect:
						return "Click and drag to select region where search should NOT be performed.";
					default:
						throw new NotImplementedException();
				}
			}
			protected set
			{
				throw new NotSupportedException();
			}
		}
		public override ToolType ToolType
		{
			get
			{
				if (IsPolygon)
				{
					return IsInclude ? ToolType.IncludePolygon : ToolType.ExcludePolygon;
				}
				else
				{
					return IsInclude ? ToolType.IncludeRect : ToolType.ExcludeRect;
				}
			}
		}

		public PointF StartPosition { get; set; }
		public bool Modifying { get; set; }

		#endregion

		#region Private methods

		private void AddGridEntry(ToolData entry)
		{
			Undo.Push(Clone());
			if (Grid.Count == 0)
			{
				Grid.Add(new ToolData
				{
					Include = !IsInclude,
					Rect = new RectangleF { X = 0, Y = 0, Width = 1, Height = 1 }
				});
			}
			Grid.Add(entry);
			RegionMap?.Dispose();
			RegionMap = null;
		}

		#endregion

		#region Public methods

		public bool CompleteModification(int w, int h, bool addPoint)
		{
			if (Modifying)
			{
				if (IsPolygon)
				{
					if (!TryAddFinalPoint(w, h, addPoint))
					{
						SystemSounds.Beep.Play();
						return false;
					}

					AddGridEntry(new ToolData
					{
						Include = IsInclude,
						Polygon = Points
								.Select(points => ToRelative(points, w, h))
								.ToList()
					});
					Modifying = false;
					Points.Clear();
					return true;
				}
				else
				{
					bool include = Mode == ToolType.IncludeRect;
					var rect = ToRelative(GetDragedRectangle(), w, h);
					var clamped = Clamp(rect);
					if (clamped.Width > 0 && clamped.Height > 0)
					{
						var newRegion = new ToolData
						{
							Include = include,
							Rect = clamped
						};

						StartPosition = PointF.Empty;
						Modifying = false;
						AddGridEntry(newRegion);
					}
					return true;
				}
			}
			return false;
		}

		public RectangleF GetDragedRectangle()
		{
			var x = Math.Min(StartPosition.X, CurrentPosition.X);
			var y = Math.Min(StartPosition.Y, CurrentPosition.Y);
			var w = Math.Abs(StartPosition.X - CurrentPosition.X);
			var h = Math.Abs(StartPosition.Y - CurrentPosition.Y);
			return new RectangleF(x, y, w, h);
		}

		public override bool OnMouseLeftDown(PointF imagePosition, int w, int h, Keys modifierKeys, int clickCount)
		{
			base.OnMouseLeftDown(imagePosition, w, h, modifierKeys, clickCount);

			if (IsPolygon)
			{
				imagePosition = ClampOnImageBorderIntersect(imagePosition, Points.LastOrDefault(), w, h);
				imagePosition = ClampAbsolute(imagePosition, w, h);
				if (clickCount > 1) return CompleteModification(w, h, true);
				if (IsPolygonPointValid(imagePosition))
				{
					Undo.Push(Clone());
					Modifying = true;
					Points.Add(imagePosition);
					return true;
				}
				else
				{
					SystemSounds.Beep.Play();
					return false;
				}
			}
			else
			{
				Modifying = true;
				StartPosition = imagePosition;
				return true;
			}

		}

		public override bool OnMouseLeftUp(PointF pointPosition, int w, int h)
		{
			base.OnMouseLeftUp(pointPosition, w, h);

			try
			{
				if (Modifying && !IsPolygon)
				{
					CompleteModification(w, h, true);
				}

				return false;
			}
			finally
			{
				StartPosition = PointF.Empty;
				if (!IsPolygon)
				{
					Modifying = false;
				}
			}
		}

		public override bool OnMouseMove(PointF imagePosition, int w, int h, Keys modifierKeys, MouseButtons mouseButtons)
		{
			base.OnMouseMove(imagePosition, w, h, modifierKeys, mouseButtons);

			CurrentPosition = imagePosition;
			return (mouseButtons & MouseButtons.Left) == MouseButtons.Left || IsPolygon;
		}

		public override Tool Clone()
		{
			return new PolygonSelectionTool(Undo, Mode)
			{
				Grid = Grid.Select(x => x.Clone()).ToList(),
				Modifying = Modifying,
				Points = Points.ToList(),
				CurrentPosition = CurrentPosition,
				RegionMap = null,
			};
		}

		public override void Paint(Graphics g, int w, int h, float scale, Keys modifierKeys)
		{
			var targetWidth = (int)(w * scale);
			var targetHeight = (int)(h * scale);

			var map = RegionMap;
			if (Grid.Count != 0 && (map?.Width != targetWidth || map?.Height != targetHeight))
			{
				RegionMap?.Dispose();
				RegionMap = null;
				map = RegionMap = CreateRegionBitmap(targetWidth, targetHeight);
			}

			if (map != null)
			{
				g.ScaleTransform(1 / scale, 1 / scale);
				g.DrawImage(map, 0, 0);
				g.ScaleTransform(scale, scale);
			}

			using (var greenActiveBrush = new SolidBrush(Color.FromArgb(90, 0, 255, 0)))
			using (var redActiveBrush = new SolidBrush(Color.FromArgb(90, 255, 0, 0)))
			using (var thickPen = new Pen(IsInclude ? Brushes.Green : Brushes.Red, 2))
			{
				if (Modifying)
				{
					if (IsPolygon)
					{
						var points = Points.ToList();
						if (points.Count > 1)
						{
							g.DrawLines(thickPen, points.ToArray());
						}

						if (points.Count > 0)
						{
							var color = IsInclude ? Color.Green : Color.Red;
							using (var validPen = new Pen(color, 5))
							using (var invalidPen = new Pen(Color.DarkRed, 8))
							using (var invalidPenLight = new Pen(Color.DarkRed, 5))
							{
								validPen.DashPattern = new[] { 3.0f, 5.0f };
								invalidPenLight.DashPattern = new[] { 3.0f, 5.0f };

								bool valid = IsPolygonPointValid(CurrentPosition);
								g.DrawLine(valid ? validPen : invalidPen, CurrentPosition, points.Last());
								points.Add(CurrentPosition);

								valid = IsPolygonPointValid(points, points.First(), out var _);
								g.DrawLine(valid ? validPen : invalidPenLight, CurrentPosition, Points.First());
							}

							g.FillPolygon(IsInclude ? greenActiveBrush : redActiveBrush, points.ToArray());
						}
					}
					else
					{
						g.FillRectangle(IsInclude ? greenActiveBrush : redActiveBrush, GetDragedRectangle());
					}
				}
			}
		}

		#endregion
	}
}
