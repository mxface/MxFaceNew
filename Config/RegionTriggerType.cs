using Neurotec.Surveillance;
using System.Collections.Generic;
using System.Drawing;

namespace Neurotec.Samples.Config
{
	public class RegionTriggerType: TriggerType
	{
		public List<PointF> Points { get; set; } = new List<PointF>();
		public double EventTimerMinDuration { get; set; } = 10;
		public double EventTimerDuration { get; set; } = 10;

		public static implicit operator NRegionTrigger(RegionTriggerType value)
		{
			if (value != null)
			{
				var region = new NRegionTrigger(value.Points.ToArray(), value.Origin, value.EventFilter, value.EventTimerDuration, value.EventTimerMinDuration);
				value.ApplyOptionalProperties(region);
				return region;
			}
			return null;
		}
	}
}
