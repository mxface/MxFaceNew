using Neurotec.Biometrics;
using Neurotec.Images;
using Neurotec.Surveillance;
using System;
using System.Drawing;
using System.Linq;

namespace Neurotec.Samples.Code
{
	public class EventData : IDisposable
	{
		#region Public constructor

		public EventData(NSurveillanceEventDetails details, NSurveillanceEventType eventType)
		{
			EventType = eventType;
			TimeStamp = details.TimeStamp;
			VideoTimeStamp = details.VideoTimeStamp;
			Source = details.Source;
			Error = details.Error;

			if (Error != null)
				return;

			ModalityType = details.ModalityType;
			SubjectType = details.SubjectType;

			Color = details.ObjectColor;
			Type = details.ObjectType;
			Direction = details.ObjectDirection;
			DetectionConfidence = details.DetectionConfidence;
			ClothingDetails = details.ClothingDetails;
			VehicleDetails = details.VehicleDetails;
			AgeGroupDetails = details.AgeGroupDetails;

			TraceIndex = details.TraceIndex;
			FrameIndex = details.FrameIndex;
			BestMatches = details.BestMatches.ToArray();
			Lpr = details.LicensePlateDetails;
			using (var bestDetails = details.BestDetails)
			{
				Rect = bestDetails.Rectangle;
				BestFrameIndex = bestDetails.FrameIndex;
				Image = bestDetails.GetOriginalImage(false);
				Attributes = bestDetails.Attributes;
				HasFaceDetails = bestDetails.AttributesContainsDetails;
			}

			AnalyticEvents = details.AnalyticEvents.ToArray();
			if (eventType == NSurveillanceEventType.SubjectDisappeared)
			{
				Template = details.GetSubjectTemplate();
				TrackingDetails = details.TrackingDetailsHistory.ToArray();
			}

			if (eventType == NSurveillanceEventType.SubjectSplit)
			{
				using (var dt = details.SplitFromSubject)
				{
					SplitFrom = new EventData(dt, NSurveillanceEventType.SubjectTrack) { EventType = NSurveillanceEventType.SubjectSplit };
				}
			}
			if (eventType == NSurveillanceEventType.SubjectMerged)
			{
				using (var dt = details.MergedSubject)
				{
					MergedSubject = new EventData(dt, NSurveillanceEventType.SubjectTrack) { EventType = NSurveillanceEventType.SubjectMerged };
				}
			}
		}

		#endregion

		#region Public properties

		public NSurveillanceEventType EventType { get; set; }
		public NSurveillanceModalityType ModalityType { get; set; }
		public NSurveillanceModalityType SubjectType { get; set; }
		public int TraceIndex { get; set; }

		public DateTime TimeStamp { get; set; }
		public TimeSpan VideoTimeStamp { get; set; }
		public ulong FrameIndex { get; set; }
		public ulong BestFrameIndex { get; set; }
		public NImage Image { get; set; }
		public NSurveillanceSource Source { get; set; }

		public Exception Error { get; set; }
		public Rectangle Rect { get; set; }
		public NSurveillanceObjectColorDetails Color { get; set; }
		public NSurveillanceObjectTypeDetails Type { get; set; }
		public NSurveillanceObjectDirectionDetails Direction { get; set; }
		public NVehicleDetails VehicleDetails { get; set; }
		public NClothingDetails ClothingDetails { get; set; }
		public NAgeGroupDetails AgeGroupDetails { get; set; }
		public NLicensePlateDetails Lpr { get; set; }
		public float DetectionConfidence { get; set; }
		public NsedMatchResult[] BestMatches { get; set; }
		public NLTemplate Template { get; set; }
		public NLAttributes Attributes { get; set; }
		public bool HasFaceDetails { get; set; }

		public NAnalyticEvent[] AnalyticEvents { get; set; }
		public NTrackingDetails[] TrackingDetails { get; set; }

		public EventData SplitFrom { get; set; }
		public EventData MergedSubject { get; set; }

		#endregion

		#region Public methods

		public SubjectInfo CreateSubjectInfo()
		{
			if (Error != null) throw Error;

			if (!IsOneOf(EventType, NSurveillanceEventType.SubjectAppeared, NSurveillanceEventType.SubjectSplit)) throw new InvalidOperationException();

			var si = new SubjectInfo
			{
				TraceIndex = TraceIndex,
				SourceName = Source.ToString(),
				SourceId = Source.GetId(),
				IsFromVideoFile = Source.Video != null,
			};
			UpdatedSubjectInfo(si);
			return si;
		}

		public void UpdatedSubjectInfo(SubjectInfo si)
		{
			if (Error != null) throw Error;
			if (!IsEventTypeValid(EventType))
			{
				throw new InvalidOperationException();
			}

			UpdateTimeStamps(si);

			var obj = si.Object;
			obj.ColorDetails = Color;
			obj.TypeDetails = Type;
			obj.DirectionDetails = Direction;
			obj.DetectionConfidence = DetectionConfidence;
			obj.ClothingDetails = ClothingDetails;
			obj.VehicleDetails = VehicleDetails;
			obj.AgeGroupDetails = AgeGroupDetails;
			if (obj.IsEmpty && SubjectType.HasFlag(NSurveillanceModalityType.VehiclesAndHumans))
				obj.IsEmpty = false;

			if (EventType != NSurveillanceEventType.SubjectDisappeared)
			{
				if (FrameIndex == BestFrameIndex || IsOneOf(EventType, NSurveillanceEventType.SubjectAppeared, NSurveillanceEventType.SubjectSplit, NSurveillanceEventType.SubjectMerged))
				{
					UpdateLicensePlate(si);
					UpdateObjectDetails(si);
					UpdateFaceDetails(si);

					if (si.BestImage != null)
					{
						si.BestImage.Dispose();
						si.BestImage = null;
					}
					si.BestImage = Image; Image = null;
					si.BestFrameIndex = BestFrameIndex;

					si.BestVideoTimeStamp = VideoTimeStamp;
					si.BestTimeStamp = TimeStamp;
				}
			}
			else
			{
				si.Face.Template = Template; Template = null;
				si.IsDisappeared = true;
			}

			si.SetEvents(AnalyticEvents);
			AnalyticEvents = null;
			si.TrackingDetails = TrackingDetails;
			TrackingDetails = null;
		}

		#endregion

		#region Private methods

		private void UpdateTimeStamps(SubjectInfo si)
		{
			if (si.TimeStamp < TimeStamp)
				si.TimeStamp = TimeStamp;
			if (si.VideoTimeSpan < VideoTimeStamp)
				si.VideoTimeSpan = VideoTimeStamp;
			if (EventType == NSurveillanceEventType.SubjectAppeared)
			{
				si.AppearedTimeStamp = TimeStamp;
				si.AppearedVideoTimeStamp = VideoTimeStamp;
			}
			if (EventType == NSurveillanceEventType.SubjectDisappeared)
			{
				si.DissapearedTimeStamp = TimeStamp;
				si.DissapearedVideoTimeStamp = VideoTimeStamp;
			}
		}

		private void UpdateFaceDetails(SubjectInfo si)
		{
			if (Attributes != null)
			{
				var face = si.Face;
				var bestMatch = BestMatches.FirstOrDefault();
				face.BestMatches = BestMatches;
				face.Score = bestMatch?.Score ?? 0;
				face.SubjectId = bestMatch?.Id;
				face.BestAttributes = Attributes;
				face.HasDetails = HasFaceDetails;
				face.IsEmpty = false;

				if (face.Thumbnail != null)
				{
					face.Thumbnail.Dispose();
					face.Thumbnail = null;
				}
				face.Thumbnail = SubjectInfo.CutFaceThumbnailBmp(Image, Attributes, 1, 1);
			}
			else
			{
				si.Face.Dispose();
				si.Face = new SubjectInfo.FaceDetails();
			}
		}

		private void UpdateObjectDetails(SubjectInfo si)
		{
			if (SubjectType.HasFlag(NSurveillanceModalityType.VehiclesAndHumans))
			{
				var obj = si.Object;
				obj.Rect = Rect;
				if (obj.Thumbnail != null)
				{
					obj.Thumbnail.Dispose();
					obj.Thumbnail = null;
				}
				obj.Thumbnail = SubjectInfo.CutThumbnailBmp(Image, Rect, .2f, .2f);
				obj.FrameIndex = FrameIndex;
			}
		}

		private void CutLicensePlate(SubjectInfo si, NLicensePlate plate)
		{
			using (var cut = SubjectInfo.CutRotatedThumbnail(Image, plate.Rectangle, plate.Rotation))
			{
				if (si.LicensePlate.Thumbnail != null)
				{
					si.LicensePlate.Thumbnail.Dispose();
					si.LicensePlate.Thumbnail = null;
				}
				si.LicensePlate.Thumbnail = cut.ToBitmap();
				si.LicensePlate.Best = plate;
				si.LicensePlate.IsEmpty = false;
			}
		}

		private void UpdateLicensePlate(SubjectInfo si)
		{
			var bestPlate = Lpr?.Best.FirstOrDefault();
			if (bestPlate != null)
			{
				CutLicensePlate(si, bestPlate);
			}
			else if (!si.LicensePlate.IsEmpty)
			{
				si.LicensePlate.Dispose();
				si.LicensePlate = new SubjectInfo.LicensePlateDetails();
			}
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Image?.Dispose();
			Lpr?.Dispose();
			Template?.Dispose();
			SplitFrom?.Dispose();

			if (AnalyticEvents != null)
			{
				foreach (var e in AnalyticEvents)
				{
					e.Dispose();
				}
				AnalyticEvents = null;
			}
			if (TrackingDetails != null)
			{
				foreach (var td in TrackingDetails)
				{
					td.Dispose();
				}
				TrackingDetails = null;
			}
		}

		#endregion

		#region Public static methods

		public static bool IsEventTypeValid(NSurveillanceEventType type)
		{
			return IsOneOf(type,
				NSurveillanceEventType.SubjectAppeared,
				NSurveillanceEventType.SubjectTrack,
				NSurveillanceEventType.SubjectSplit,
				NSurveillanceEventType.SubjectMerged,
				NSurveillanceEventType.SubjectDisappeared);
		}

		public static bool IsOneOf<T>(T value, params T[] oneOf)
		{
			if (oneOf != null)
			{
				foreach (var item in oneOf)
				{
					if (object.Equals(value, item)) return true;
				}
			}
			return false;
		}

		#endregion
	}
}
