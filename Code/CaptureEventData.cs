using Neurotec.Images;
using Neurotec.Media;
using Neurotec.Surveillance;
using System;

namespace Neurotec.Samples.Code
{
	public class CaptureEventData : IDisposable
	{
		#region Public constructor

		public CaptureEventData(NSurveillanceEventDetails details)
		{
			TimeStamp = details.TimeStamp;
			Source = details.Source;
			Error = details.Error;
			Progress = details.VideoProgress;

			if (Error == null)
			{
				Sample = details.GetVideoSample(false);
				if (Sample == null)
				{
					Image = details.GetOriginalImage(false);
				}
			}
		}

		#endregion

		#region Public properties

		public DateTime TimeStamp { get; set; }
		public NSurveillanceSource Source { get; set; }
		public NImage Image { get; set; }
		public NVideoSample Sample { get; set; }
		public Exception Error { get; set; }
		public double Progress { get; set; }

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Image?.Dispose();
			Sample?.Dispose();
		}

		#endregion
	}
}
