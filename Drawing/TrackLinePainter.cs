using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Neurotec.Samples.Drawing
{
	public static class RectangleExtension
	{
		public static Rectangle ToRect(this Neurotec.Drawing.Rectangle r)
			=> new Rectangle(r.X, r.Y, r.Width, r.Height);
	}

	public class TrackLinePainter: IDisposable
	{
		#region Private types

		private class LineData
		{
			#region Public properties

			public NBoxOrigin Origin { get; set; }
			public GraphicsPath Path { get; set; }
			public PointF Start { get; set; }
			public PointF End { get; set; }
			public RectangleF Bounds { get; set; }

			public Color Color { get; set; }
			public bool FirstOrigin { get; set; }

			#endregion

			#region Public methods

			public static LineData Create(PointF[] points, Color color, NBoxOrigin boxOrigin, bool firstOrigin)
			{
				var gp = new GraphicsPath();
				gp.AddLines(points);

				return new LineData
				{
					Start = points[0],
					End = points.Last(),
					Origin = boxOrigin,
					FirstOrigin = firstOrigin,
					Color = color,
					Path = gp,
					Bounds = gp.GetBounds(),
				};
			}

			public void Paint(Graphics g, Font font, bool hit)
			{
				RectangleF ToEllipse(PointF p, float radius = 3) => new RectangleF(p.X - radius, p.Y - radius, radius * 2, radius * 2);

				if (!hit)
				{
					using (var p = new Pen(FirstOrigin ? Color : Color.FromArgb(128, Color)))
					{
						if (!FirstOrigin)
						{
							p.DashPattern = new[] { 5.0f, 5.0f };
							p.DashStyle = DashStyle.Custom;
						}
						g.DrawPath(p, Path);
						g.FillEllipse(Brushes.LimeGreen, ToEllipse(Start));
						g.FillEllipse(Brushes.Blue, ToEllipse(End));
					}
				}
				else
				{
					using (var thickPen = new Pen(Color, 7))
					{
						g.DrawPath(thickPen, Path);
						g.FillEllipse(Brushes.LimeGreen, ToEllipse(Start, 7));
						g.FillEllipse(Brushes.Blue, ToEllipse(End, 7));
						if (font != null)
						{
							var startSize = g.MeasureString("Start", font, int.MaxValue);
							var endSize = g.MeasureString("End", font, int.MaxValue);
							g.DrawString("Start", font, Brushes.White, Start.X - startSize.Width / 2, Start.Y - startSize.Height - 2);
							g.DrawString("End", font, Brushes.White, End.X - endSize.Width / 2, End.Y - endSize.Height - 2);
						}
					}
				}
			}

			public bool HitTest(Point mousePosition)
			{
				if (Bounds.Contains(mousePosition))
				{
					using (var outlinePen = CreateWidePen())
					{
						if (Path.PointCount < 4096) // Disable hit test due to bad performance
							return Path.IsOutlineVisible(mousePosition, outlinePen);
					}
				}
				return false;
			}

			#endregion

			#region Private static methods

			private static Pen CreateWidePen() => new Pen(Brushes.Red, 25);

			#endregion
		}

		#endregion

		#region Private fields
		private NBoxOrigin[] _previousOrigins = null;
		private List<LineData> _lineData = new List<LineData>();
		private Font _font;

		#endregion

		public TrackLinePainter()
		{
			_font = new Font(FontFamily.GenericSerif, 24, FontStyle.Bold);
		}

		#region Private methods

		private bool ValidateSameOrigins(NBoxOrigin[] origins)
		{
			bool sameOrigins = true;
			if (_previousOrigins?.Length == origins.Length)
			{
				for (int i = 0; i < origins.Length; i++)
				{
					if (origins[i] != _previousOrigins[i])
					{
						sameOrigins = false;
						break;
					}
				}
			}
			else
			{
				sameOrigins = false;
			}

			if (!sameOrigins)
				_previousOrigins = origins;

			return sameOrigins;
		}

		private static IEnumerable<LineData> CreateLines(NBoxOrigin[] origins, IEnumerable<NTrackingDetails> trackingDetails)
		{
			bool firstOrigin = true;
			foreach (var origin in origins)
			{
				PointF OriginPoint(Rectangle r)
				{
					var x = r.Left + r.Width / 2.0f;
					var y = r.Top + r.Height / 2.0f;
					if (origin != NBoxOrigin.Center)
						y = origin == NBoxOrigin.TopCenter ? r.Top : r.Bottom;
					return new PointF(x, y);
				}

				var points = trackingDetails
					.AsParallel()
					.AsOrdered()
					.Where(x => x.LicensePlates.Count != 0)
					.Select(x => x.LicensePlates[0].BoundingBox)
					.Select(OriginPoint)
					.ToArray();

				if (points.Length >= 2)
				{
					yield return LineData.Create(points, Color.Lime, origin, firstOrigin);
				}

				points = trackingDetails
					.AsParallel()
					.AsOrdered()
					.Where(x => x.SubjectType.HasFlag(NSurveillanceModalityType.VehiclesAndHumans))
					.Select(x => OriginPoint(x.Rectangle))
					.ToArray();
				if (points.Length >= 2)
				{
					yield return LineData.Create(points, Color.GreenYellow, origin, firstOrigin);
				}

				points = trackingDetails
					.AsParallel()
					.AsOrdered()
					.Where(x => x.SubjectType.HasFlag(NSurveillanceModalityType.Faces))
					.Select(x => x.Attributes.BoundingRect.ToRect())
					.Select(OriginPoint)
					.ToArray();
				if (points.Length >= 2)
				{
					yield return LineData.Create(points, Color.Lime, origin, firstOrigin);
				}
				firstOrigin = false;
			}
		}

		#endregion

		#region Public methods

		public void Paint(Graphics g, IEnumerable<NTrackingDetails> trackingDetails, Point? mousePosition = null, NBoxOrigin[] origins = null)
		{
			if (origins == null || origins.Length == 0)
			{
				origins = new[] { NBoxOrigin.Center };
			}

			if (_lineData.Count == 0 || !ValidateSameOrigins(origins))
			{
				_lineData.Clear();
				_lineData.AddRange(CreateLines(origins, trackingDetails));
			}

			var wasHit = false;
			foreach (var line in _lineData)
			{
				bool hit = mousePosition.HasValue && !wasHit && line.HitTest(mousePosition.Value);
				line.Paint(g, _font, hit);
				wasHit |= hit;
			}
		}

		public void Dispose()
		{
			_font?.Dispose();
		}

		#endregion
	}
}

