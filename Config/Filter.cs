using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neurotec.Samples.Config
{
	public class Filter: ICloneable
	{
		#region Public properties

		public NSurveillanceObjectColor Color { get; set; } = NSurveillanceObjectColor.None;
		public float ColorConfidence { get; set; } = 0.5f;
		public NSurveillanceObjectDirection Direction { get; set; } = NSurveillanceObjectDirection.None;
		public float DirectionConfidence { get; set; } = 0.3f;
		public NSurveillanceObjectType Type { get; set; }
		public float TypeConfidence { get; set; } = 0.5f;
		public bool? WatchlistFilter { get; set; } = null;
		public bool MustHaveFace { get; set; }
		public bool MustHaveLicensePlate { get; set; }
		public bool WithTriggersOnly { get; set; }
		public string TriggerName { get; set; }
		public NAnalyticEventType AnalyticEventType { get; set; } = NAnalyticEventType.All;

		#endregion

		#region Private methods

		private IEnumerable<NSurveillanceObjectColor> GetColors()
		{
			var values = (NSurveillanceObjectColor[])Enum.GetValues(typeof(NSurveillanceObjectColor));
			foreach (var flag in values.Where(x => x > NSurveillanceObjectColor.None))
			{
				if ((Color & flag) == flag)
					yield return flag;
			}
		}

		private IEnumerable<NSurveillanceObjectDirection> GetDirections()
		{
			var values = (NSurveillanceObjectDirection[])Enum.GetValues(typeof(NSurveillanceObjectDirection));
			foreach (var flag in values.Where(x => x > NSurveillanceObjectDirection.None))
			{
				if ((Direction & flag) == flag)
					yield return flag;
			}
		}

		private IEnumerable<NSurveillanceObjectType> GetTypes()
		{
			var values = (NSurveillanceObjectType[])Enum.GetValues(typeof(NSurveillanceObjectType));
			foreach (var flag in values.Where(x => x > NSurveillanceObjectType.None))
			{
				if ((Type & flag) == flag)
					yield return flag;
			}
		}

		#endregion

		#region Public methods

		public override string ToString()
		{
			var sb = new StringBuilder();
			void AppendSeparator()
			{
				if (sb.Length > 0)
					sb.Append(", ");
			}

			if (WatchlistFilter != null)
			{
				sb.Append(WatchlistFilter == true ? "In Watchlist" : "Not In Watchlist");
			}

			if (MustHaveFace)
			{
				AppendSeparator();
				sb.Append("With Face");
			}

			if (MustHaveLicensePlate)
			{
				AppendSeparator();
				sb.Append("With License");
			}

			if (WithTriggersOnly)
			{
				AppendSeparator();
				sb.Append("With Events");
			}

			if (Type > NSurveillanceObjectType.None)
			{
				AppendSeparator();
				sb.Append(GetTypes().Select(x => x.ToString()).Aggregate((a, b) => $"{a}, {b}"));
			}

			if (Color > NSurveillanceObjectColor.None)
			{
				AppendSeparator();
				sb.Append(GetColors().Select(x => x.ToString()).Aggregate((a, b) => $"{a}, {b}"));
			}

			if (Direction > NSurveillanceObjectDirection.None)
			{
				AppendSeparator();
				sb.Append(GetDirections().Select(x => x.ToString()).Aggregate((a, b) => $"{a}, {b}"));
			}

			return sb.Length > 0 ? sb.ToString() : "None";
		}

		#endregion

		#region ICloneable

		public object Clone()
		{
			return new Filter
			{
				Color = this.Color,
				ColorConfidence = this.ColorConfidence,
				Type = this.Type,
				TypeConfidence = this.TypeConfidence,
				Direction = this.Direction,
				DirectionConfidence = this.DirectionConfidence,
				MustHaveFace = this.MustHaveFace,
				MustHaveLicensePlate = this.MustHaveLicensePlate,
				WatchlistFilter = this.WatchlistFilter,
				WithTriggersOnly = this.WithTriggersOnly,
				TriggerName = this.TriggerName,
				AnalyticEventType = this.AnalyticEventType
			};
		}

		#endregion
	}
}
