namespace Neurotec.Samples.Data
{
	public struct RecordSource
	{
		#region Public static fields

		public static readonly RecordSource Empty = new RecordSource(null, false);

		#endregion

		#region Public constructor

		public RecordSource(string name, bool isVideoSource)
		{
			Name = name;
			IsVideoSource = isVideoSource;
		}

		#endregion

		#region Public properties

		public string Name { get; set; }
		public bool IsVideoSource { get; set; }

		#endregion

		#region Public properties

		public override string ToString()
		{
			return Name ?? string.Empty;
		}

		#endregion
	}
}
