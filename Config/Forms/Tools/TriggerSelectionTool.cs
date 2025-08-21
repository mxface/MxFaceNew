using Neurotec.Samples.Drawing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms.Tools
{
	public class TriggerSelectionTool : Tool, ICompleableTool
	{
		#region Public constants

		public const int PenThickness = 4;
		public const int SelectedPenThickness = 6;

		#endregion

		#region Private fields

		private ToolType _type = ToolType.RegionTrigger;
		private ToolData _selectedValue;
		private string _hint;

		#endregion

		#region Public properties

		public override bool IsValid
		{
			get
			{
				if (ToolType == ToolType.Tripwire)
				{
					var distance = Math.Sqrt(Math.Pow(StartPosition.X - CurrentPosition.X, 2) + Math.Pow(StartPosition.Y - CurrentPosition.Y, 2));
					return StartPosition != CurrentPosition && !CurrentPosition.IsEmpty && distance > 50;
				}
				return Grid.Any();
			}
		}
		public PointF StartPosition { get; set; }
		public bool Modifying { get; set; }
		public override bool IsSearchAreaTool => false;
		public ToolData SelectedValue
		{
			get => _selectedValue;
			set => SetProperty(ref _selectedValue, value);
		}
		public ObservableCollection<ToolData> State { get; }
		public override string Hint
		{
			get => _hint;
			protected set => SetProperty(ref _hint, value);
		}
		public override ToolType ToolType { get => _type; }

		#endregion

		#region Public constructor

		public TriggerSelectionTool(ToolType type, ObservableCollection<ToolData> state)
			: base(new UndoStack())
		{
			if (type != ToolType.RegionTrigger && type != ToolType.Tripwire && type != ToolType.RegionTriggerRect)
				throw new ArgumentOutOfRangeException(nameof(type));

			_type = type;
			SetHint();

			State = state;
			foreach (var sa in state)
			{
				Grid.Add(sa);
			}
		}

		#endregion

		#region Public methods

		public override Tool Clone()
		{
			return new TriggerSelectionTool(ToolType, State)
			{
				Modifying = Modifying,
				StartPosition = StartPosition,
				CurrentPosition = CurrentPosition,
			};
		}

		public override void Paint(Graphics g, int w, int h, float scale, Keys modifierKeys)
		{
			foreach (var value in Grid)
			{
				bool isSelected = SelectedValue == value;
				if (value.Polygon.Count == 2)
				{
					PaintTripwire(g, value.Color, value.Polygon[0], value.Polygon[1], w, h, isSelected);
				}
				else
				{
					PaintPolygon(g, value.Color, value.Polygon, w, h, false, isSelected);
				}
			}

			if (Modifying)
			{
				if (ToolType == ToolType.Tripwire)
				{
					PaintTripwire(g, TripwireTriggerType.DefaultColor, ToRelative(StartPosition, w, h), ToRelative(CurrentPosition, w, h), w, h, true);
				}
				else if (ToolType == ToolType.RegionTrigger)
				{
					PaintPolygon(g, TripwireTriggerType.DefaultColor, Points.Select(x => ToRelative(x, w, h)), w, h, true, true);
				}
				else if (ToolType == ToolType.RegionTriggerRect)
				{
					PaintPolygon(g, TripwireTriggerType.DefaultColor, ToPoints(GetDragedRectangle()).Select(x => ToRelative(x, w, h)), w, h, true, true);
				}
			}
		}

		public bool CompleteModification(int w, int h, bool addPoint)
		{
			if (Modifying)
			{
				if (!TryAddFinalPoint(w, h, addPoint))
				{
					SystemSounds.Beep.Play();
					return false;
				}

				AddGridEntry(new ToolData
				{
					Polygon = Points
						.Select(points => ToRelative(points, w, h))
						.ToList(),
					Name = "New Region"
				});
				Modifying = false;
				Points.Clear();
				return true;
			}
			return false;
		}

		public override bool OnMouseLeftUp(PointF pointPosition, int w, int h)
		{
			base.OnMouseLeftUp(pointPosition, w, h);

			if (ToolType == ToolType.Tripwire)
			{
				pointPosition = ClampOnImageBorderIntersect(pointPosition, Points.LastOrDefault(), w, h);
				pointPosition = ClampAbsolute(pointPosition, w, h);

				Modifying = false;
				if (IsValid)
				{
					CurrentPosition = ClampAbsolute(CurrentPosition, w, h);
					Grid.Add(new ToolData()
					{
						Name = "New Tripwire",
						Polygon = new List<PointF>
						{
							ToRelative(StartPosition, w, h),
							ToRelative(CurrentPosition, w, h),
						},
						Include = true,
					});
					State.Add(Grid.Last());
					StartPosition = PointF.Empty;
					return true;
				}
			}
			else if (ToolType == ToolType.RegionTriggerRect)
			{
				Modifying = false;
				var rect = ToRelative(GetDragedRectangle(), w, h);
				var clamped = Clamp(rect);
				if (clamped.Width > 0 && clamped.Height > 0)
				{
					AddGridEntry(new ToolData
					{
						Polygon = ToPoints(clamped).ToList(),
						Name = "New Region"
					});
					Points.Clear();
					return true;
				}
			}

			StartPosition = PointF.Empty;
			return false;
		}

		public override bool OnMouseLeftDown(PointF imagePosition, int w, int h, Keys modifierKeys, int clickCount)
		{
			base.OnMouseLeftDown(imagePosition, w, h, modifierKeys, clickCount);

			imagePosition = ClampOnImageBorderIntersect(imagePosition, Points.LastOrDefault(), w, h);
			if (ToolType == ToolType.Tripwire || ToolType == ToolType.RegionTriggerRect)
			{
				Modifying = true;
				StartPosition = ClampAbsolute(imagePosition, w, h);
				return true;
			}
			else
			{
				imagePosition = ClampAbsolute(imagePosition, w, h);

				if (clickCount > 1) return CompleteModification(w, h, true);
				if (IsPolygonPointValid(imagePosition))
				{
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
		}

		public override bool OnMouseMove(PointF imagePosition, int w, int h, Keys modifierKeys, MouseButtons mouseButtons)
		{
			base.OnMouseMove(imagePosition, w, h, modifierKeys, mouseButtons);

			CurrentPosition = imagePosition;
			return Modifying;
		}

		#endregion

		#region Private methods

		private void SetHint()
		{
			if (_type == ToolType.Tripwire)
			{
				Hint = "Click and drag mouse to select tripwire.";
			}
			else if (_type == ToolType.RegionTriggerRect)
			{
				Hint = "Click and drag to select region.";
			}
			else
			{
				Hint = "Click to select points of polygon region.\n" +
					"Press 'Esc', 'Enter' or double click to complete polygon selection.";
			}
		}

		private IEnumerable<PointF> ToPoints(RectangleF rect)
		{
			yield return new PointF(rect.Left, rect.Top);
			yield return new PointF(rect.Right, rect.Top);
			yield return new PointF(rect.Right, rect.Bottom);
			yield return new PointF(rect.Left, rect.Bottom);
		}

		private RectangleF GetDragedRectangle()
		{
			var x = Math.Min(StartPosition.X, CurrentPosition.X);
			var y = Math.Min(StartPosition.Y, CurrentPosition.Y);
			var w = Math.Abs(StartPosition.X - CurrentPosition.X);
			var h = Math.Abs(StartPosition.Y - CurrentPosition.Y);
			return new RectangleF(x, y, w, h);
		}

		private void PaintTripwire(Graphics g, Color color, PointF relativeFirst, PointF relativeSecond, int w, int h, bool isSelected)
		{
			var thickness = isSelected ? SelectedPenThickness : PenThickness;
			using (var path = TriggerPainter.Tripwire.CreatePath(relativeFirst, relativeSecond, w, h, 1, 0, 0))
			using (var resources = TriggerPainter.Resources.CreateTripwire(color, thickness))
			{
				TriggerPainter.Tripwire.Paint(g, path, resources.Pen);
			}
		}

		private void PaintPolygon(Graphics g, Color color, IEnumerable<PointF> relativePoints, int w, int h, bool modifying, bool isSelected)
		{
			var thickness = isSelected ? SelectedPenThickness : PenThickness;
			using (var brush = new SolidBrush(Color.FromArgb(50, color)))
			{
				if (!modifying)
				{
					var absolutePoints = TriggerPainter.Region.Calculate(relativePoints, w, h);
					if (absolutePoints.Length > 2)
					{
						TriggerPainter.Region.Paint(g, absolutePoints, brush);
						if (isSelected)
						{
							using (var dashed = new Pen(color, 4))
							{
								var length = absolutePoints.Length;
								Array.Resize(ref absolutePoints, length + 1);
								absolutePoints[length] = absolutePoints[0];

								dashed.DashPattern = new[] { 2.0f, 2.0f };
								g.DrawLines(dashed, absolutePoints);
							}
						}
					}
				}
				else
				{
					var absolutePoints = TriggerPainter.Region.Calculate(relativePoints, w, h).ToList();
					if (absolutePoints.Count == 0)
						return;

					if (ToolType == ToolType.RegionTrigger)
					{
						using (var validPen = new Pen(color, thickness))
						using (var invalidPen = new Pen(Color.DarkRed, 8))
						using (var invalidPenLight = new Pen(Color.DarkRed, 5))
						{
							validPen.DashPattern = new[] { 3.0f, 5.0f };
							invalidPenLight.DashPattern = new[] { 3.0f, 5.0f };

							bool valid = IsPolygonPointValid(CurrentPosition);
							g.DrawLine(valid ? validPen : invalidPen, CurrentPosition, absolutePoints.Last());

							absolutePoints.Add(CurrentPosition);
							valid = IsPolygonPointValid(absolutePoints, absolutePoints.First(), out var _);
							g.DrawLine(valid ? validPen : invalidPenLight, CurrentPosition, absolutePoints.First());
						}
					}
					g.FillPolygon(brush, absolutePoints.ToArray());
				}
			}
		}

		private void AddGridEntry(ToolData entry)
		{
			Grid.Add(entry);
			State.Add(entry);
		}

		#endregion
	}
}
