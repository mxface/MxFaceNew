using Neurotec.Biometrics;
using Neurotec.Drawing.Drawing2D;
using Neurotec.Images;
using Neurotec.Images.Processing;
using Neurotec.Samples.Data;
using Neurotec.Surveillance;
using System;
using System.Drawing;

namespace Neurotec.Samples.Code
{
	public class SubjectInfo : IDisposable
	{
		#region Public types

		public class FaceDetails : IDisposable
		{
			#region Public properties

			public bool IsEmpty { get; set; } = true;

			public NLAttributes BestAttributes { get; set; }
			public bool HasDetails { get; set; }

			public Rectangle Rect
			{
				get
				{
					var r = BestAttributes?.BoundingRect ?? Neurotec.Drawing.Rectangle.Empty;
					return new Rectangle(r.X, r.Y, r.Width, r.Height);
				}
			}

			public string StatusText { get; set; }
			public string SubjectId { get; set; }
			public int Score { get; set; }
			public NsedMatchResult[] BestMatches { get; set; }
			public NLTemplate Template { get; set; }
			public Bitmap Thumbnail { get; set; }
			public Bitmap GalleryThumbnail { get; set; }

			#endregion

			#region IDisposable

			public void Dispose()
			{
				BestAttributes?.Dispose();
				Template?.Dispose();
				Thumbnail?.Dispose();
				GalleryThumbnail?.Dispose();
			}

			#endregion
		}

		public class ObjectDetails: IDisposable
		{
			#region Public properties

			public bool IsEmpty { get; set; } = true;

			public Rectangle Rect { get; set; }
			public float DetectionConfidence { get; set; }
			public NSurveillanceObjectColorDetails ColorDetails { get; set; }
			public NSurveillanceObjectTypeDetails TypeDetails { get; set; }
			public NSurveillanceObjectDirectionDetails DirectionDetails { get; set; }
			public NClothingDetails ClothingDetails { get; set; }
			public NVehicleDetails VehicleDetails { get; set; }
			public NAgeGroupDetails AgeGroupDetails { get; set; }
			public Bitmap Thumbnail { get; set; }
			public ulong FrameIndex { get; set; }

			#endregion

			#region IDisposable

			public void Dispose()
			{
				ClothingDetails?.Dispose();
				VehicleDetails?.Dispose();
				AgeGroupDetails?.Dispose();
				Thumbnail?.Dispose();
			}

			#endregion
		}

		public class LicensePlateDetails: IDisposable
		{
			#region Public properties

			public bool IsEmpty { get; set; } = true;
			public LicensePlateRecord Watchlist { get; set; }
			public NLicensePlate Best { get; set; }
			public Bitmap Thumbnail { get; set; }

			#endregion

			#region IDisposable

			public void Dispose()
			{
				Best?.Dispose();
				Thumbnail?.Dispose();
			}

			#endregion
		}

		#endregion

		#region Public properties

		public int TraceIndex { get; set; }
		public ulong BestFrameIndex { get; set; }

		public DateTime AppearedTimeStamp { get; set; } = new DateTime();
		public TimeSpan AppearedVideoTimeStamp { get; set; } = TimeSpan.Zero;
		public DateTime DissapearedTimeStamp { get; set; } = new DateTime();
		public TimeSpan DissapearedVideoTimeStamp { get; set; } = TimeSpan.Zero;
		public DateTime TimeStamp { get; set; }
		public TimeSpan VideoTimeSpan { get; set; } = TimeSpan.Zero;
		public DateTime BestTimeStamp { get; set; }
		public TimeSpan BestVideoTimeStamp { get; set; }
		public Bitmap Thumbnail
		{
			get
			{
				return Face.Thumbnail ?? Object.Thumbnail ?? LicensePlate.Thumbnail;
			}
		}
		public NImage BestImage { get; set; }

		public ObjectDetails Object { get; private set; } = new ObjectDetails();
		public FaceDetails Face { get; set; } = new FaceDetails();
		public LicensePlateDetails LicensePlate { get; set; } = new LicensePlateDetails();

		public string SourceName { get; set; }
		public string SourceId { get; set; }
		public bool IsFromVideoFile { get; set; }
		public bool IsDisappeared { get; set; }

		public NAnalyticEvent[] Events { get; set; }
		public bool HasEvents { get; set; }
		public NTrackingDetails[] TrackingDetails { get; set; }

		#endregion

		#region Public constructors

		public SubjectInfo()
		{
		}

		#endregion

		#region Public static methods

		public static Bitmap CutThumbnailBmp(NImage image, Rectangle rect, float inflateX = .2f, float inflateY = .2f)
		{
			using (var cut = CutThumbnail(image, rect, inflateX, inflateY))
			{
				return cut.ToBitmap();
			}
		}

		public static NImage CutThumbnail(NImage image, Rectangle rect, float inflateX = .2f, float inflateY = .2f)
		{
			var newRect = rect;
			newRect.Inflate((int)(rect.Width * inflateX), (int)(rect.Height * inflateY));
			newRect.Intersect(new Rectangle(0, 0, (int)image.Width, (int)image.Height));
			return NImage.FromImage(NPixelFormat.Rgb8U, 0, image, (uint)newRect.X, (uint)newRect.Y, (uint)newRect.Width, (uint)newRect.Height);
		}

		public static NImage CutRotatedThumbnail(NImage image, Rectangle r, float rotation)
		{
			return Nrgbip.RotatedCopy(image, r.X + r.Width / 2, r.Y + r.Height / 2, rotation / 180 * Math.PI, r.Width / 2, r.Height / 2, false, new NRgb(), (uint)r.Width, (uint)r.Height, 0);
		}

		public static NImage CutFaceThumbnail(NImage image, NLAttributes attributes, float inflateX = 1f, float inflateY = 1f)
		{
			var rect = attributes.BoundingRect;
			rect.Inflate((int)(rect.Width * inflateX), (int)(rect.Height * inflateY));
			rect.Intersect(new Neurotec.Drawing.Rectangle(0, 0, (int)image.Width, (int)image.Height));
			return NImage.FromImage(NPixelFormat.Rgb8U, 0, image, (uint)rect.X, (uint)rect.Y, (uint)rect.Width, (uint)rect.Height);
		}

		public static Bitmap CutFaceThumbnailBmp(NImage image, NLAttributes attributes, float inflateX = 1f, float inflateY = 1f)
		{
			using (var cut = CutFaceThumbnail(image, attributes, inflateX, inflateY))
			{
				return cut.ToBitmap();
			}
		}

		public static NImage CutAndScaleFaceThumbnail(NImage image, NLAttributes attributes, float inflateX = 1f, float inflateY = 1f, int maxWidth = 480, int maxHeight = 640)
		{
			var thumbnail = CutFaceThumbnail(image, attributes, inflateX, inflateY);
			if (thumbnail.Width > maxWidth || thumbnail.Height > maxHeight)
			{
				var scale = Math.Min((float)maxWidth / thumbnail.Width, (float)maxHeight / thumbnail.Height);
				var width = (uint)Math.Ceiling(thumbnail.Width * scale);
				var height = (uint)Math.Ceiling(thumbnail.Height * scale);
				return Nrgbip.Scale(thumbnail, 0, 0, thumbnail.Width, thumbnail.Height, width, height, InterpolationMode.Bilinear);
			}
			else
				return thumbnail;
		}

		#endregion

		#region Public events

		public void SetEvents(NAnalyticEvent[] events)
		{
			if (Events != null)
			{
				foreach (var e in Events)
				{
					e.Dispose();
				}
				Events = null;
			}

			Events = events;
			HasEvents = Events?.Length > 0;
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Object?.Dispose();
			Face?.Dispose();
			LicensePlate?.Dispose();

			if (BestImage != null)
			{
				BestImage.Dispose();
				BestImage = null;
			}

			if (TrackingDetails != null)
			{
				foreach (var td in TrackingDetails)
				{
					td.Dispose();
				}
			}
			SetEvents(null);
		}

		#endregion
	}
}
