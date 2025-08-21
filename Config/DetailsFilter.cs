namespace Neurotec.Samples.Config
{
	public class DetailsFilter
	{
		public bool ShowFaceAttributes { get; set; } = true;
		public bool ShowFaceQuality { get; set; } = true;
		public bool ShowObjectDirection { get; set; } = false;
		public bool ShowObjectColor { get; set; } = true;
		public bool ShowObjectType { get; set; } = true;
		public bool ShowLPOrigin { get; set; } = true;
		public bool ShowVehicleModel { get; set; } = false;
		public bool ShowTags { get; set; } = false;
		public bool ShowAgeGroups { get; set; } = true;
		public bool ShowLPFormattedValue { get; set; } = false;

		public bool ShowAnalyticEvent { get; set; } = true;
		public bool ShowAnalyticEventBorder { get; set; } = true;
	}
}
