using Neurotec.Biometrics;
using Neurotec.Images;
using Neurotec.Samples.Code;
using Neurotec.Surveillance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Neurotec.Samples.Data
{
	public class Record : IDisposable
	{
		#region Public properties

		public int Id { get; set; }
		public DateTime TimeStamp { get; set; }
		public TimeSpan VideoTimeStamp { get; set; }
		public string Source { get; set; }
		public bool IsVideoSource { get; set; }
		public NImage Image { get; set; }
		public ObjectRecord Object { get; set; }
		public LicenseRecord License { get; set; }
		public FullFaceRecord Face { get; set; }
		public bool HasObject { get => Object != null; }
		public bool HasLicense { get => License != null; }
		public bool HasFace { get => Face != null; }

		#endregion

		#region Public constructor

		public Record()
		{
		}

		public Record(int id, DateTime timeStamp, TimeSpan videoTimeStamp, bool isVideo, string source, ObjectRecord objectRecord, LicenseRecord licenseRecord, FullFaceRecord faceRecord)
		{
			Id = id;
			TimeStamp = timeStamp;
			Source = source;
			Object = objectRecord;
			License = licenseRecord;
			Face = faceRecord;
			VideoTimeStamp = videoTimeStamp;
			IsVideoSource = isVideo;
		}

		#endregion

		#region Public static methods

		public static Record CreateRecord(SubjectInfo si, NImage fullImage, Bitmap objectThumb, Bitmap licenseThumb, Bitmap faceThumb)
		{
			var record = new Record()
			{
				TimeStamp = si.BestTimeStamp,
				VideoTimeStamp = si.BestVideoTimeStamp,
				Image = fullImage,
				Source = si.SourceName,
				IsVideoSource = si.IsFromVideoFile
			};

			if (!si.Object.IsEmpty)
			{
				var objectRecord = new ObjectRecord(si.Object.TypeDetails, si.Object.ColorDetails, si.Object.DirectionDetails, si.Object.VehicleDetails, si.Object.ClothingDetails, si.Object.AgeGroupDetails)
				{
					Thumbnail = objectThumb,
					BoundingRect = si.Object.Rect,
					DetectionConfidence = si.Object.DetectionConfidence,
				};
				record.Object = objectRecord;
			}

			if (!si.LicensePlate.IsEmpty)
			{
				var licenseRecord = new LicenseRecord()
				{
					Thumbnail = licenseThumb,
					BoundingRect = si.LicensePlate.Best.Rectangle,
					DetectionConfidence = si.LicensePlate.Best.DetectionConfidence,
					OcrConfidence = si.LicensePlate.Best.OcrConfidence,
					OcclusionConf = si.LicensePlate.Best.OcclusionConfidence,
					Origin = si.LicensePlate.Best.Origin,
					Value = si.LicensePlate.Best.Value,
					InWatchlist = si.LicensePlate.Watchlist != null,
					Owner = si.LicensePlate.Watchlist?.Owner,

				};
				record.License = licenseRecord;
			}

			if (!si.Face.IsEmpty)
			{
				NsedMatchResult bestMatch = null;
				if (si.Face.BestMatches != null && si.Face.BestMatches.Count() > 0)
				{
					bestMatch = si.Face.BestMatches?.OrderByDescending(item => item.Score).First();
				}

				var faceRecord = new FullFaceRecord(si.Face.BestAttributes, bestMatch)
				{
					Thumbnail = faceThumb
				};
				record.Face = faceRecord;
			}

			return record;
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			Object?.Dispose();
			License?.Dispose();
			Image?.Dispose();
		}

		#endregion
	}

	public class LicenseRecord : IDisposable
	{
		#region Public properties

		[JsonIgnore]
		public Bitmap Thumbnail { get; set; }
		public string Value { get; set; }
		public string Origin { get; set; }
		public float OcrOriginConfidence { get; set; }
		public float DetectionConfidence { get; set; }
		public float OcrConfidence { get; set; }
		public float OcclusionConf { get; set; }
		public Rectangle BoundingRect { get; set; }
		public bool InWatchlist { get; set; }
		public string Owner { get; set; }

		#endregion

		#region Public static methods

		public static string GetCsvHeader()
		{
			return "licensePlate;origin;ocrOriginConf;licensePlateInWatchlist;licensePlateOwner;ocrConf;detectionConfocclusionConf;";
		}

		public static IEnumerable<object> GetCsvValues(LicenseRecord lic)
		{
			yield return lic?.Value;
			yield return lic?.Origin;
			yield return lic?.OcrOriginConfidence;
			yield return lic?.InWatchlist ?? false;
			yield return lic?.Owner;
			yield return lic?.OcrConfidence ?? null;
			yield return lic?.DetectionConfidence ?? null;
			yield return lic?.OcclusionConf;
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			Thumbnail?.Dispose();
		}

		#endregion
	}

	public class FullFaceRecord : IDisposable
	{
		public class MatchResult
		{
			public int Score { get; set; }
			public string Id { get; set; }
		}

		#region Public properties

		[JsonIgnore]
		public Bitmap Thumbnail { get; set; }
		public Neurotec.Drawing.Rectangle BoundingRect { get; set; }
		public float Roll { get; set; }
		public byte DetectionConfidence { get; set; }
		public byte Quality { get; set; }
		public MatchResult Match { get; set; }

		[JsonIgnore]
		public NGender Gender
		{
			get
			{
				if (Attributes.TryGetValue(NBiometricAttributeId.GenderMale, out var maleConf) && Attributes.TryGetValue(NBiometricAttributeId.GenderFemale, out var femaleConf))
				{
					if (maleConf <= 100 && femaleConf <= 100)
					{
						return maleConf > femaleConf ? NGender.Male : NGender.Female;
					}
				}
				return NGender.Unknown;
			}
		}

		public Dictionary<NBiometricAttributeId, byte> Attributes { get; set; }

		#endregion

		#region Public constructor

		public FullFaceRecord()
		{
		}

		public FullFaceRecord(NLAttributes attributes, NsedMatchResult match)
		{
			Match = match != null ? new MatchResult { Id = match.Id, Score = match.Score } : null;
			BoundingRect = attributes.BoundingRect;
			DetectionConfidence = attributes.DetectionConfidence;
			Quality = attributes.Quality;

			this.Attributes = attributes.Values.ToDictionary(x => x.Id, x => x.Value);
		}

		#endregion

		#region Public methods

		public string GetAttributesString()
		{
			if (Attributes.Any())
			{
				return Attributes.Select(x => $"{x.Key}={x.Value}").Aggregate((a, b) => a + ";" + b);
			}
			return null;
		}

		public static IEnumerable<KeyValuePair<NBiometricAttributeId, byte>> ParseAttributesString(string attributesString)
		{
			if (attributesString != null)
			{
				var values = attributesString.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var pair in values)
				{
					var kv = pair.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
					var key = (NBiometricAttributeId)Enum.Parse(typeof(NBiometricAttributeId), kv[0]);
					var value = byte.Parse(kv[1]);
					yield return new KeyValuePair<NBiometricAttributeId, byte>(key, value);
				}
			}
		}

		public byte GetAttributeValue(NBiometricAttributeId id)
		{
			return Attributes.TryGetValue(id, out var value) ? value : NBiometricTypes.QualityUnknown;
		}

		public static string GetCsvHeader()
		{
			return
				"age;gender;genderConfidence;withGlasses;glassesConfidence;withDarkGlasses;darkGlassesConfidence;withBeard;beardConfidence;" +
				"withMustache;mustacheConfidence;smile;smileConfidence;Blink;blinkConfidence;MouthOpen;mouthOpenConfidence;" +
				"faceMask;faceMaskConfidence;" +
				"matchId;matchScore;";
		}

		public static IEnumerable<object> GetCsvValues(FullFaceRecord face)
		{
			if (face != null)
			{
				yield return face.GetAttributeValue(NBiometricAttributeId.Age);
				yield return face.Gender;

				if (face.Gender == NGender.Male)
					yield return face.GetAttributeValue(NBiometricAttributeId.GenderMale);
				else if (face.Gender == NGender.Female)
					yield return face.GetAttributeValue(NBiometricAttributeId.GenderFemale);
				else
					yield return NBiometricTypes.QualityUnknown;

				var idsWithConfidence = new[]
				{
					NBiometricAttributeId.Glasses,
					NBiometricAttributeId.DarkGlasses,
					NBiometricAttributeId.Beard,
					NBiometricAttributeId.Mustache,
					NBiometricAttributeId.Smile,
					NBiometricAttributeId.EyesOpen,
					NBiometricAttributeId.MouthOpen,
					NBiometricAttributeId.FaceMask,
				};

				foreach (var id in idsWithConfidence)
				{
					var conf = face.GetAttributeValue(id);
					yield return conf > 50 && conf <= NBiometricTypes.QualityMax;
					yield return conf;
				}

				yield return face.Match?.Id ?? null;
				yield return face.Match?.Score ?? -1;
			}
			else
			{
				for (int i = 0; i < 35; i++)
				{
					yield return null;
				}
			}
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			Thumbnail?.Dispose();
		}

		#endregion
	}

	public class ObjectRecord : IDisposable
	{
		#region Public properties

		[JsonIgnore]
		public bool HasDirection
		{
			get => NorthConfidence > 0 || NorthEastConfidence > 0 || EastConfidence > 0 || SouthEastConfidence > 0
					|| SouthConfidence > 0 || SouthWestConfidence > 0 || WestConfidence > 0 || NorthWestConfidence > 0;
		}
		[JsonIgnore]
		public bool HasColor
		{
			get => RedColorConfidence > 0 || OrangeColorConfidence > 0 || YellowColorConfidence > 0 || GreenColorConfidence > 0
					|| BlueColorConfidence > 0 || SilverColorConfidence > 0 || WhiteColorConfidence > 0 || BlackColorConfidence > 0 || BrownColorConfidence > 0 || GrayColorConfidence > 0;
		}
		[JsonIgnore]
		public Bitmap Thumbnail { get; set; }
		public Rectangle BoundingRect { get; set; }
		public float DetectionConfidence { get; set; }
		public float CarConfidence { get; set; }
		public float PersonConfidence { get; set; }
		public float BusConfidence { get; set; }
		public float TruckConfidence { get; set; }
		public float BikeConfidence { get; set; }
		public float RedColorConfidence { get; set; }
		public float OrangeColorConfidence { get; set; }
		public float YellowColorConfidence { get; set; }
		public float GreenColorConfidence { get; set; }
		public float BlueColorConfidence { get; set; }
		public float SilverColorConfidence { get; set; }
		public float WhiteColorConfidence { get; set; }
		public float BlackColorConfidence { get; set; }
		public float BrownColorConfidence { get; set; }
		public float GrayColorConfidence { get; set; }
		public float NorthConfidence { get; set; }
		public float NorthEastConfidence { get; set; }
		public float EastConfidence { get; set; }
		public float SouthEastConfidence { get; set; }
		public float SouthConfidence { get; set; }
		public float SouthWestConfidence { get; set; }
		public float WestConfidence { get; set; }
		public float NorthWestConfidence { get; set; }
		public NVehicleOrientation Orientation { get; set; }
		public float PrientationAngle { get; set; }
		public float OrientationConfidence { get; set; }
		public string VehicleMake { get; set; }
		public float VehicleMakeConfidence { get; set; }
		public string CarModel { get; set; }
		public List<KeyValuePair<string, float>> Clothes { get; set; }
		public NAgeGroup AgeGroup { get; set; } = NAgeGroup.Unknown;
		public float AgeGroupConfidence { get; set; }
		public List<KeyValuePair<string, float>> Tags { get; set; }

		#endregion

		#region Public constructors

		public ObjectRecord()
		{
		}

		public ObjectRecord(NSurveillanceObjectTypeDetails type, NSurveillanceObjectColorDetails color, NSurveillanceObjectDirectionDetails direction,
			NVehicleDetails vehicleDetails, NClothingDetails clothingDetails, NAgeGroupDetails ageGroupDetails)
		{
			CarConfidence = type.CarConfidence;
			PersonConfidence = type.PersonConfidence;
			BusConfidence = type.BusConfidence;
			TruckConfidence = type.TruckConfidence;
			BikeConfidence = type.BikeConfidence;
			RedColorConfidence = color.RedColorConfidence;
			OrangeColorConfidence = color.OrangeColorConfidence;
			YellowColorConfidence = color.YellowColorConfidence;
			GreenColorConfidence = color.GreenColorConfidence;
			BlueColorConfidence = color.BlueColorConfidence;
			SilverColorConfidence = color.SilverColorConfidence;
			WhiteColorConfidence = color.WhiteColorConfidence;
			BlackColorConfidence = color.BlackColorConfidence;
			BrownColorConfidence = color.BrownColorConfidence;
			GrayColorConfidence = color.GrayColorConfidence;
			NorthConfidence = direction.NorthConfidence;
			NorthEastConfidence = direction.NorthEastConfidence;
			EastConfidence = direction.EastConfidence;
			SouthEastConfidence = direction.SouthEastConfidence;
			SouthConfidence = direction.SouthConfidence;
			SouthWestConfidence = direction.SouthWestConfidence;
			WestConfidence = direction.WestConfidence;
			NorthWestConfidence = direction.NorthWestConfidence;

			var model = vehicleDetails?.Models?.FirstOrDefault();
			VehicleMake = model?.MakeModels.First().Key;
			VehicleMakeConfidence = model?.Confidence ?? float.NaN;
			CarModel = model?.MakeModels.First().Value;
			if (clothingDetails != null)
			{
				Clothes = new List<KeyValuePair<string, float>>();
				foreach (var val in clothingDetails?.Values)
				{
					Clothes.Add(new KeyValuePair<string, float>(val.Name, val.Confidence));
				}
			}
			if (ageGroupDetails != null)
			{
				AgeGroup = ageGroupDetails.Group;
				AgeGroupConfidence = ageGroupDetails.GroupConfidence;
			}

			Tags = vehicleDetails?.Tags.Select(x => new KeyValuePair<string, float>(x.Name, x.Confidence)).ToList();
		}

		#endregion

		#region Public methods

		public static string GetCsvHeader()
		{
			return
				"person;car;truck;bus;bike;" +
				"red;orange;green;blue;silver;white;black;brown;gray;" +
				"north;northEast;east;southEast;south;southWest;west;northWest;clothes;clothesConfidence;" +
				"vehicleMake;vehicleMakeConfidence;carModel;ageGroup;ageGroupConfidence;tags;tagsConfidences;";
		}

		public static IEnumerable<object> GetCsvValues(ObjectRecord obj)
		{
			if (obj != null)
			{
				yield return obj.PersonConfidence;
				yield return obj.CarConfidence;
				yield return obj.TruckConfidence;
				yield return obj.BusConfidence;
				yield return obj.BikeConfidence;
				yield return obj.RedColorConfidence;
				yield return obj.OrangeColorConfidence;
				yield return obj.GreenColorConfidence;
				yield return obj.BlueColorConfidence;
				yield return obj.SilverColorConfidence;
				yield return obj.WhiteColorConfidence;
				yield return obj.BlackColorConfidence;
				yield return obj.BrownColorConfidence;
				yield return obj.GrayColorConfidence;
				yield return obj.NorthConfidence;
				yield return obj.NorthEastConfidence;
				yield return obj.EastConfidence;
				yield return obj.SouthEastConfidence;
				yield return obj.SouthConfidence;
				yield return obj.SouthWestConfidence;
				yield return obj.WestConfidence;
				yield return obj.NorthWestConfidence;

				var (valueString, confidenceString) = MakeCsvValue(obj.Clothes);
				yield return valueString;
				yield return confidenceString;

				if (obj.VehicleMake?.Length > 0)
				{
					yield return obj.VehicleMake;
					yield return obj.VehicleMakeConfidence;
				}
				else
				{
					yield return null;
					yield return null;
				}
				yield return obj.CarModel;

				yield return obj.AgeGroup.ToString();
				yield return obj.AgeGroupConfidence;

				var tags = MakeCsvValue(obj.Tags);
				yield return tags.valueString;
				yield return tags.confidenceString;
			}
			else
			{
				for (int i = 0; i < 31; i++)
				{
					yield return null;
				}
			}
		}

		#endregion

		#region Private methods

		private static (string valueString, string confidenceString) MakeCsvValue(List<KeyValuePair<string, float>> values, string separator = @" | ")
		{
			bool first = true;
			var valueString = string.Empty;
			var confidenceString = string.Empty;
			if (values != null)
			{
				foreach (var v in values)
				{
					if (!first)
					{
						valueString += separator;
						confidenceString += separator;
					}
					valueString += v.Key;
					confidenceString += v.Value.ToString();
					first = false;
				}
			}
			return (valueString, confidenceString);
		}

		#endregion

		#region IDisposable
		public void Dispose()
		{
			Thumbnail?.Dispose();
		}
		#endregion
	}
}
