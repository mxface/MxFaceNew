using Neurotec.Biometrics;
using Neurotec.Surveillance;
using System;

namespace Neurotec.Samples.Config
{
	public class Preset
	{
		#region Private fields

		private static string _defaultPropertiesString = null;

		#endregion

		public string Name { get; set; }
		public string PropertiesString { get; set; }
		public string PresetGUID { get; set; }

		#region Static constructor

		static Preset()
		{
			using (var target = new NSurveillance() { UseGPU = true })
			using (var pb = GetPropertyBagFrom(target))
			{
				_defaultPropertiesString = pb.ToString();
			}
		}

		#endregion

		#region Public static methods

		public static NPropertyBag GetPropertyBagFrom(NSurveillance target)
		{
			NPropertyBag pb = new NPropertyBag
			{
				{ "ObjectTracker.DetectorScaling", target.GetProperty<NDetectorScaleCount>("ObjectTracker.DetectorScaling") },

				{ "ObjectTracker.DetectorThreshold", target.GetProperty<int>("ObjectTracker.DetectorThreshold") },
				{ "ObjectTracker.DetectClothingDetails", target.GetProperty<bool>("ObjectTracker.DetectClothingDetails") },
				{ "ObjectTracker.DetectVehicleDetails", target.GetProperty<bool>("ObjectTracker.DetectVehicleDetails") },

				{ "ObjectTracker.LicensePlateDetectorScaling", target.GetProperty<NDetectorScaleCount>("ObjectTracker.LicensePlateDetectorScaling") },
				{ "ObjectTracker.LicensePlateDetectorThreshold", target.GetProperty<int>("ObjectTracker.LicensePlateDetectorThreshold") },
				{ "ObjectTracker.LicensePlateInterpretOasZero", target.GetProperty<bool>("ObjectTracker.LicensePlateInterpretOasZero") },
				{ "ObjectTracker.LicensePlateMinCharacterCount", target.GetProperty<int>("ObjectTracker.LicensePlateMinCharacterCount") },
				{ "ObjectTracker.LicensePlateOcrThreshold", target.GetProperty<int>("ObjectTracker.LicensePlateOcrThreshold") },
				{ "ObjectTracker.LicensePlateEnableTemplateMatching", target.GetProperty<bool>("ObjectTracker.LicensePlateEnableTemplateMatching") },
				{ "ObjectTracker.LicensePlatePriorityCountries", target.GetProperty<string>("ObjectTracker.LicensePlatePriorityCountries") },
				{ "ObjectTracker.LicensePlateLatinOnly", target.LicensePlateLatinOnly },

				{ "ObjectTracker.FacesDetectMasks", target.GetProperty<bool>("ObjectTracker.FacesDetectMasks") },
				{ "ObjectTracker.FaceTemplateSize", target.GetProperty<NTemplateSize>("ObjectTracker.FaceTemplateSize") },
				{ "ObjectTracker.FaceMinIod", target.GetProperty<int>("ObjectTracker.FaceMinIod") },
				{ "ObjectTracker.FaceDetectionThreshold", target.GetProperty<int>("ObjectTracker.FaceDetectionThreshold") },
				{ "ObjectTracker.FaceQualityThreshold", target.GetProperty<int>("Faces.QualityThreshold") }
			};

			return pb;
		}

		#endregion

		#region Public constructors

		public Preset(string name)
		{
			PresetGUID = Guid.NewGuid().ToString();
			Name = name;
			PropertiesString = _defaultPropertiesString;
		}

		public Preset(string name, string guid, string propertiesString)
		{
			PresetGUID = guid;
			Name = name;
			PropertiesString = propertiesString;
		}

		public Preset()
		{

		}

		#endregion

		#region Public methods

		public NPropertyBag GetPropertyBag()
		{
			return NPropertyBag.Parse(PropertiesString);
		}

		public override string ToString()
		{
			return Name;
		}

		#endregion
	}
}
