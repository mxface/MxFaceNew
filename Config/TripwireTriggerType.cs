using Neurotec.Surveillance;
using System.Drawing;

namespace Neurotec.Samples.Config
{
	public class TripwireTriggerType : TriggerType
	{
		#region Public properties

		public PointF FirstPoint { get; set; }
		public PointF SecondPoint { get; set; }

		#endregion

		#region Public static properties

		public static implicit operator NTripwire(TripwireTriggerType value)
		{
			if (value != null)
			{
				var tripwire = new NTripwire(value.FirstPoint, value.SecondPoint, value.Origin, value.EventFilter);
				value.ApplyOptionalProperties(tripwire);
				return tripwire;
			}
			return null;
		}

		public static implicit operator TripwireTriggerType(NTripwire value)
		{
			if (value != null)
			{
				var tripwire = new TripwireTriggerType { FirstPoint = value.FirstPoint, SecondPoint = value.SecondPoint, Origin = value.Origin };
				tripwire.TryGetOptionalProperties(value);
				return tripwire;
			}
			return null;
		}

		#endregion
	}
}
