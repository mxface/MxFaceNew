using Neurotec.Surveillance;
using System.Drawing;

namespace Neurotec.Samples.Config
{
	public abstract class TriggerType
	{
		#region Public static fields

		public static readonly Color DefaultColor = Color.DarkOrange;

		#endregion

		#region Public properties

		public NBoxOrigin Origin { get; set; }
		public string Name { get; set; }
		public Color Color { get; set; } = DefaultColor;
		public NAnalyticEventType EventFilter { get; set; } = NAnalyticEventType.All;

		#endregion

		#region Protected methods

		protected void ApplyOptionalProperties(NAnalyticTrigger trigger)
		{
			trigger.SetProperty("Name", Name);
			trigger.SetProperty("Color", Color);
		}

		protected void TryGetOptionalProperties(NAnalyticTrigger trigger)
		{
			using (var properties = trigger.Properties)
			{
				if (properties.TryGetValue("Name", out var name))
				{
					Name = name.ToString();
				}
				if (properties.TryGetValue("Color", out var color) && color is Color colorValue)
				{
					Color = colorValue;
				}
			}
		}

		#endregion

		#region Public static methods

		public static implicit operator NAnalyticTrigger(TriggerType value)
		{
			if (value != null)
			{
				if (value is RegionTriggerType region)
				{
					return (NRegionTrigger)region;
				}
				else if (value is TripwireTriggerType tripwire)
				{
					return (NTripwire)tripwire;
				}
			}
			return null;
		}

		#endregion
	}
}
