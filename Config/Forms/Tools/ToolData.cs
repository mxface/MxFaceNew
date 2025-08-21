using Neurotec.Surveillance;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Neurotec.Samples.Config.Forms.Tools
{
	public class ToolData
	{
		#region Private properties

		public RectangleF Rect { get; set; }
		public bool Include { get; set; } = true;
		public List<PointF> Polygon { get; set; } = new List<PointF>();
		public string Name { get; set; }
		public Color Color { get; set; } = Color.Red;
		public NBoxOrigin Origin { get; set; } = NBoxOrigin.Center;
		public NAnalyticEventType EventFilter { get; set; } = NAnalyticEventType.All;
		public double EventTimerMinDuration { get; set; } = 10;
		public double EventTimerDuration { get; set; } = 10;

		#endregion

		#region Public static methods

		public static ToolData Create(TriggerType trigger)
		{
			var sa = new ToolData
			{
				Color = trigger.Color,
				Name = trigger.Name,
				Origin = trigger.Origin,
				EventFilter = trigger.EventFilter,
			};
			if (trigger is TripwireTriggerType tripwire)
			{
				sa.Polygon = new List<PointF> { tripwire.FirstPoint, tripwire.SecondPoint };
			}
			else if (trigger is RegionTriggerType region)
			{
				sa.Polygon = region.Points.ToList();
				sa.EventTimerMinDuration = region.EventTimerMinDuration;
				sa.EventTimerDuration = region.EventTimerDuration;
			}
			else
				throw new NotActivatedException();
			return sa;
		}

		public static ToolData Create(SearchAreaType area)
		{
			return new ToolData
			{
				Include = area.Type == NSearchAreaType.Include,
				Rect = area.Rect,
				Polygon = area.Points?.ToList() ?? new List<PointF>()
			};
		}

		#endregion

		#region Public methods

		public bool IsTriggerTripwire() => Polygon.Count == 2;

		public SearchAreaType ToArea()
		{
			return new SearchAreaType
			{
				Type = Include ? NSearchAreaType.Include : NSearchAreaType.Exclude,
				Points = Polygon.ToList(),
				Rect = Rect,
			};
		}

		public TriggerType ToTrigger()
		{
			if (IsTriggerTripwire())
			{
				return new TripwireTriggerType
				{
					Color = Color,
					Name = Name,
					Origin = Origin,
					FirstPoint = Polygon[0],
					SecondPoint = Polygon[1],
					EventFilter = EventFilter,
				};
			}
			else
			{
				return new RegionTriggerType
				{
					Color = Color,
					Name = Name,
					Origin = Origin,
					Points = Polygon.ToList(),
					EventFilter = EventFilter,
					EventTimerMinDuration = EventTimerMinDuration,
					EventTimerDuration = EventTimerDuration,
				};
			}
		}

		public GraphicsPath CreatePath(int w, int h)
		{
			if (Polygon?.Any() == true)
			{
				var gp = new GraphicsPath();
				gp.AddPolygon(Polygon.Select(p => Tool.ToAbsolute(p, w, h)).ToArray());
				gp.CloseFigure();
				return gp;
			}
			else
			{
				var gp = new GraphicsPath();
				gp.AddRectangle(Tool.ToAbsolute(Rect, w, h));
				return gp;
			}
		}

		public ToolData Clone()
		{
			return new ToolData
			{
				Rect = Rect,
				Include = Include,
				Polygon = Polygon.ToList(),
				Name = Name,
				Color = Color,
				Origin = Origin,
			};
		}

		#endregion
	}
}
