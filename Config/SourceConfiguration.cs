using System.Collections.Generic;

namespace Neurotec.Samples.Config
{
	public class SourceConfiguration
	{
		#region Public properties

		public string SourceId { get; set; }
		public string SettingsPreset { get; set; } = null;
		public string PreferedFormat { get; set; } = null;

		public List<SearchAreaType> Areas { get; set; } = new List<SearchAreaType>();
		public bool IsGrid { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
		public bool CheckSearchAreaByObjectCenter { get; set; }

		public List<TriggerType> Triggers { get; set; } = new List<TriggerType>();

		#endregion
	}
}
