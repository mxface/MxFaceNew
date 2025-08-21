using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Neurotec.Samples.Drawing
{
	public class TriggerPainter : IDisposable
	{
		#region Nested types

		public class Resources : IDisposable
		{
			#region Public properties

			public Pen Pen { get; set; }
			public Pen DashedPen { get; set; }
			public Brush Brush { get; set; }

			#endregion

			#region Public static methods

			public static Resources Create(NAnalyticTrigger trigger, int alpha, int thickness)
			{
				var color = trigger.GetColor();
				if (trigger is NTripwire tripwire)
				{
					return CreateTripwire(color, thickness);
				}
				else
				{
					return CreateRegion(color, alpha);
				}
			}

			public static Resources CreateTripwire(Color color, int thickness) => new Resources
			{
				Pen = new Pen(color, thickness),
				DashedPen = new Pen(color, thickness * 2)
				{
					DashPattern = new float[] { 3, 3 }
				},
			};

			public static Resources CreateRegion(Color color, int alpha) => new Resources
			{
				Brush = new SolidBrush(Color.FromArgb(alpha, color)),
				DashedPen = new Pen(color, 2)
				{
					DashPattern = new float[] { 3, 3 }
				}
			};

			#endregion

			#region IDisposable

			public void Dispose()
			{
				Pen?.Dispose();
				DashedPen?.Dispose();
				Brush?.Dispose();
			}

			#endregion
		}

		public abstract class Painter : IDisposable
		{
			public static readonly Pen OutlinePen = new Pen(Brushes.Red, 20);

			public GraphicsPath Path { get; set; }
			public string Name { get; set; }
			public string Description { get; set; }
			public StringFormat StringFormat { get; set; }
			public RectangleF Bounds { get; protected set; }

			public abstract void Paint(Graphics g, Resources r, bool highligt = false);

			public void PaintText(Graphics g, Font font, Font smallFont, Brush brush)
			{
				var nameSize = g.MeasureString(Name, font);

				var x = Bounds.X + (Bounds.Width - nameSize.Width) / 2;
				var y = Bounds.Y + Bounds.Height / 2 - nameSize.Height / 2;
				g.DrawString(Name, font, brush, x, y);
				y += nameSize.Height + 3;

				var lines = Description.Split('\n');
				foreach (var line in lines)
				{
					var lineSize = g.MeasureString(line, smallFont);
					x = Bounds.X + (Bounds.Width - lineSize.Width) / 2;
					g.DrawString(line, smallFont, brush, x, y);
					y += lineSize.Height;
				}
			}

			public bool HitTest(Point position) => Path.IsVisible(position) || Path.IsOutlineVisible(position, OutlinePen);

			public virtual void Dispose() => Path?.Dispose();
		}

		public class Tripwire : Painter
		{
			#region Public constructor

			public Tripwire(NTripwire tripwire, int viewWidth, int viewHeight, float scale, float dx, float dy)
			{
				Path = CreatePath(tripwire, viewWidth, viewHeight, scale, dx, dy);

				Name = tripwire.GetName();
				Bounds = Path.GetBounds();

				var eventFilter = tripwire.EventFilter;
				if (eventFilter.HasFlag(NAnalyticEventType.CrossedIn) && eventFilter.HasFlag(NAnalyticEventType.CrossedOut))
				{
					Description = "In / Out";
				}
				else
				{
					Description = eventFilter.HasFlag(NAnalyticEventType.CrossedIn) ? "In" : "Out";
				}
			}

			#endregion

			#region Private static methods

			private static GraphicsPath CreatePath(PointF p1, PointF p2, float scale)
			{
				var resultPath = new GraphicsPath();
				resultPath.AddLine(p1, p2);

				var gp = PathUtils.CreateArrowPath(scale);

				var angle = (float)CalculateAngle(p1, p2) - 90;
				var angleRadians = (Math.PI / 180) * angle;

				var bounds = gp.GetBounds();
				var middle = CalculateMiddlePoint(bounds);
				var lineMiddle = CalculateMiddlePoint(RectangleF.FromLTRB(p1.X, p1.Y, p2.X, p2.Y));
				var dx = lineMiddle.X - middle.X - bounds.Width * (float)Math.Cos(angleRadians);
				var dy = lineMiddle.Y - middle.Y - bounds.Height * (float)Math.Sin(angleRadians);

				gp.RotateAtCenter(angle);
				gp.Translate(dx, dy);
				resultPath.AddPath(gp, false);
				return resultPath;
			}

			private static double CalculateAngle(PointF p1, PointF p2)
			{
				var x1 = p1.X;
				var x2 = p2.X;
				var y1 = p1.Y;
				var y2 = p2.Y;

				double degrees;

				if (x2 - x1 == 0)
				{
					degrees = y2 > y1 ? 90 : 270;
				}
				else
				{
					var riseoverrun = (double)(y2 - y1) / (x2 - x1);
					var radians = Math.Atan(riseoverrun);
					degrees = radians * (180 / Math.PI);

					if ((x2 - x1) < 0 || (y2 - y1) < 0)
					{
						degrees += 180;
					}
					if ((x2 - x1) > 0 && (y2 - y1) < 0)
					{
						degrees -= 180;
					}
					if (degrees < 0)
					{
						degrees += 360;
					}
				}
				return degrees;
			}

			private static PointF CalculateMiddlePoint(RectangleF rect)
				=> new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);

			#endregion

			#region Public static methods

			public static GraphicsPath CreatePath(PointF first, PointF second, int viewWidth, int viewHeight, float scale, float dx, float dy)
			{
				var targetWidth = (int)(scale * viewWidth);
				var targetHeight = (int)(scale * viewHeight);
				var p1 = new PointF(dx + first.X * targetWidth, dy + first.Y * targetHeight);
				var p2 = new PointF(dx + second.X * targetWidth, dy + second.Y * targetHeight);

				return CreatePath(p1, p2, scale);
			}

			public static GraphicsPath CreatePath(NTripwire tripwire, int viewWidth, int viewHeight, float scale, float dx, float dy)
				=> CreatePath(tripwire.FirstPoint, tripwire.SecondPoint, viewWidth, viewHeight, scale, dx, dy);

			public static void Paint(Graphics g, GraphicsPath gp, Pen pen)
			{
				var interpolation = g.InterpolationMode;
				var smoothing = g.SmoothingMode;

				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.SmoothingMode = SmoothingMode.AntiAlias;

				g.DrawPath(pen, gp);

				g.InterpolationMode = interpolation;
				g.SmoothingMode = smoothing;
			}

			#endregion

			#region IPainter

			public override void Paint(Graphics g, Resources r, bool highligt)
			{
				Paint(g, Path, highligt ? r.DashedPen : r.Pen);
			}

			#endregion
		}

		public class Region : Painter
		{
			#region Public properties

			public PointF[] Points { get; set; }

			#endregion

			#region Public constructor

			public Region(NRegionTrigger region, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f)
			{
				Points = Calculate(region, viewWidth, viewHeight, scale, dx, dy);
				Path = new GraphicsPath();
				Path.AddPolygon(Points);
				Path.CloseFigure();
				Name = region.GetName();

				var filter = region.EventFilter;
				Description = filter == NAnalyticEventType.All ? "All Events" : filter.ToString();
				if (filter.HasFlag(NAnalyticEventType.Timer))
				{
					Description += $"\nTimer {region.EventTimerDuration:0}s, Minimum: {region.MinimumTimerDuration:0}s";
				}

				Bounds = Path.GetBounds();
			}

			#endregion

			#region Public static methods

			public static PointF[] Calculate(NRegionTrigger region, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f)
				=> Calculate(region.Points, viewWidth, viewHeight, scale, dx, dy);

			public static PointF[] Calculate(IEnumerable<PointF> points, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f)
			{
				var targetWidth = (int)(scale * viewWidth);
				var targetHeight = (int)(scale * viewHeight);
				return points
					.Select(p => new PointF(p.X * targetWidth + dx, p.Y * targetHeight + dy))
					.ToArray();
			}

			public static void Paint(Graphics g, PointF[] points, Brush brush) => g.FillPolygon(brush, points, FillMode.Alternate);

			#endregion

			#region IPainter

			public override void Paint(Graphics g, Resources r, bool highlight)
			{
				Paint(g, Points, r.Brush);
				if (highlight)
					g.DrawPolygon(r.DashedPen, Points);
			}

			#endregion
		}

		#endregion

		#region Private fields

		private List<Painter> _painters = new List<Painter>();
		private List<Resources> _resources = new List<Resources>();
		private readonly Font _font;
		private readonly Font _smallFont;

		#endregion

		#region Public static methods

		public static void PaintRegion(NRegionTrigger region, Graphics g, Brush brush, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f)
		{
			var points = Region.Calculate(region, viewWidth, viewHeight, scale, dx, dy);
			Region.Paint(g, points, brush);
		}

		public static void PaintRegion(NRegionTrigger region, Graphics g, Color color, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f, int alpha = 50)
		{
			using (var brush = new SolidBrush(Color.FromArgb(alpha, color)))
			{
				PaintRegion(region, g, brush, viewWidth, viewHeight, scale, dx, dy);
			}
		}

		public static void PaintTripwire(NTripwire tripwire, Graphics g, Color color, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f, int thickness = 2)
		{
			using (var resources = Resources.Create(tripwire, 255, thickness))
			{
				PaintTripwire(tripwire, g, resources.Pen, viewWidth, viewHeight, scale, dx, dy);
			}
		}

		public static void PaintTripwire(NTripwire tripwire, Graphics g, Pen pen, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f)
		{
			using (var gp = Tripwire.CreatePath(tripwire, viewWidth, viewHeight, scale, dx, dy))
			{
				g.DrawPath(pen, gp);
			}
		}

		public static TriggerPainter Create(IEnumerable<NAnalyticTrigger> triggers, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f, int alpha = 50, int thickness = 2)
		{
			return new TriggerPainter(viewWidth * scale, viewHeight * scale)
			{
				_resources = triggers.Select(x => Resources.Create(x, alpha, thickness)).ToList(),
				_painters = Measure(triggers, viewWidth, viewHeight, scale, dx, dy).ToList(),
			};
		}

		#endregion

		#region Private static methods

		private static IEnumerable<Painter> Measure(IEnumerable<NAnalyticTrigger> triggers, int viewWidth, int viewHeight, float scale = 1.0f, float dx = 0.0f, float dy = 0.0f)
		{
			foreach (var trigger in triggers)
			{
				if (trigger is NTripwire tripwire)
				{
					yield return new Tripwire(tripwire, viewWidth, viewHeight, scale, dx, dy);
				}
				else if (trigger is NRegionTrigger region)
				{
					yield return new Region(region, viewWidth, viewHeight, scale, dx, dy);
				}
				else
					throw new NotImplementedException();
			}
		}

		#endregion

		#region Private constructor

		private TriggerPainter(float viewVidth, float viewHeight)
		{
			var size = Math.Min(viewHeight, viewHeight);
			var em = size / 420 * 12;
			var ems = em * 0.83f;

			_font = new Font(FontFamily.GenericSerif, em, FontStyle.Bold);
			_smallFont = new Font(FontFamily.GenericSerif, ems, FontStyle.Bold);
		}

		#endregion

		#region Public methods

		public void Paint(Graphics g)
		{
			Paint(g, new Point(-1, -1));
		}

		public void Paint(Graphics g, Point mousePosition)
		{
			for (int i = 0; i < _painters.Count; i++)
			{
				var trigger = _painters[i];
				bool hit = trigger.HitTest(mousePosition);
				var painter = _painters[i];
				var res = _resources[i];
				painter.Paint(g, res, hit);
				if (hit)
					painter.PaintText(g, _font, _smallFont, Brushes.White);
			}
		}

		public void Dispose()
		{
			foreach (var p in _painters)
			{
				p.Dispose();
			}
			_painters.Clear();
			foreach (var r in _resources)
			{
				r.Dispose();
			}
			_resources.Clear();
			_font?.Dispose();
		}

		#endregion
	}
}
