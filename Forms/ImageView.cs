using Neurotec.Biometrics;
using Neurotec.Samples.Code;
using Neurotec.Samples.Config;
using Neurotec.Samples.Drawing;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public class ImageView : Neurotec.Gui.NView
	{
		#region Private fields

		private Bitmap _bmp;
		private SubjectInfo _info;
		private SourceController _source;
		private NAnalyticEvent _selectedEvent;
		private SourceCheckState _checkState;
		private SearchAreaPainter _searchAreaPainter;
		private TriggerPainter _triggerPainter;
		private TrackLinePainter _trackLinePainter;

		#endregion

		#region Public constructor

		public ImageView()
		{
			CanPan = true;
		}

		#endregion

		#region Public properties

		public Bitmap Image
		{
			get => _bmp;
			set
			{
				_bmp?.Dispose();
				_bmp = value;
				if (value != null)
				{
					DataChanged(_bmp.Width, _bmp.Height);
				}
				else
					DataChanged(1, 1);
			}
		}

		public SubjectInfo Info
		{
			get => _info;
			set
			{
				_info = value;
				_trackLinePainter = null;
				SetBmp(value?.BestImage.ToBitmap());
				Invalidate();
			}
		}

		public SourceController State
		{
			get => _source;
			set
			{
				if (_source != value)
				{
					_searchAreaPainter?.Dispose();
					_searchAreaPainter = null;
					_triggerPainter?.Dispose();
					_triggerPainter = null;
				}
				_source = value;
				Invalidate();
			}
		}

		public SourceCheckState CheckState
		{
			get => _checkState;
			set
			{
				if (_checkState != null) _checkState.PropertyChanged -= CheckStatePropertyChanged;
				_checkState = value;
				if (_checkState != null) _checkState.PropertyChanged += CheckStatePropertyChanged;
				Invalidate();
			}
		}

		public NAnalyticEvent SelectedEvent
		{
			get => _selectedEvent;
			set
			{
				_selectedEvent = value;
				if (value == null)
					SetBmp(Info?.BestImage.ToBitmap());
				else
				{
					using (var details = value.EventDetails)
					using (var image = details.GetOriginalImage(true))
					{
						SetBmp(image.ToBitmap());
					}
				}
				Invalidate();
			}
		}

		#endregion

		#region Public methods

		public Bitmap DrawOnImage()
		{
			if (_bmp == null) throw new InvalidOperationException();

			var bmp = (Bitmap)_bmp.Clone();
			using (var g = Graphics.FromImage(bmp))
			{
				TriggerPainter triggerPaiter = null;
				SearchAreaPainter areaPainter = null;
				DrawOn(g, bmp.Width, bmp.Height, 0, 0, null, ref triggerPaiter, ref areaPainter);
				triggerPaiter?.Dispose();
				areaPainter?.Dispose();
			}
			return bmp;
		}

		#endregion

		#region Private methods

		private void CheckStatePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Invalidate();
		}

		private void SetBmp(Bitmap value)
		{
			_bmp?.Dispose();
			_bmp = value;
			DataChanged(_bmp?.Width ?? 1, _bmp?.Height ?? 1);
		}

		#endregion

		#region Protected methods

		protected void DrawSubject(Graphics g, NLAttributes faceAttributes, Rectangle vhRect, NLicensePlate lp, Point? mousePosition = null)
		{
			int thickness = 2;

			if (faceAttributes != null)
			{
				var brush = Brushes.Lime;
				using (var pen = new Pen(brush, thickness))
				{
					var rect = faceAttributes.BoundingRect;
					g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
				}
			}

			if (!vhRect.IsEmpty)
			{
				var brush = Brushes.GreenYellow;
				using (var pen = new Pen(brush, thickness))
				{
					g.DrawRectangle(pen, vhRect);
				}
			}

			if (lp != null)
			{
				var brush = Brushes.Lime;
				using (var pen = new Pen(brush, thickness))
				{
					var rect = new Rectangle(lp.Rectangle.X, lp.Rectangle.Y, lp.Rectangle.Width, lp.Rectangle.Height);

					g.TranslateTransform(rect.X + rect.Width / 2, rect.Y);
					g.RotateTransform(lp.Rotation);
					g.TranslateTransform(-rect.X - rect.Width / 2, -rect.Y);

					g.DrawRectangle(pen, rect);

					g.TranslateTransform(rect.X + rect.Width / 2, rect.Y);
					g.RotateTransform(-lp.Rotation);
					g.TranslateTransform(-rect.X - rect.Width / 2, -rect.Y);
				}
			}

			if (Info.TrackingDetails != null && CheckState?.ShowTrackLine == true)
			{
				var origins = new List<NBoxOrigin>();
				if (Info.Events.Length != 0)
				{
					var preferedOrigin = (SelectedEvent ?? Info.Events[0]).Trigger.Origin;
					origins.Add(preferedOrigin);
				}
				if (State != null)
				{
					foreach (var item in State.Source.AnalyticTriggers)
					{
						origins.Add(item.Origin);
					}
				}

				if (_trackLinePainter == null)
					_trackLinePainter = new TrackLinePainter();
				_trackLinePainter.Paint(g, Info.TrackingDetails, mousePosition, origins.Distinct().ToArray());
			}
		}

		protected void DrawOn(Graphics g, int w, int h, float dx, float dy, Point? mousePosition,
			ref TriggerPainter triggerPainter, ref SearchAreaPainter searchAreaPainter)
		{
			if (State?.Source.AnalyticTriggers.Count > 0 && CheckState?.ShowTriggers == true)
			{
				if (triggerPainter == null)
				{
					triggerPainter = TriggerPainter.Create(State.Source.AnalyticTriggers, w, h);
				}
				triggerPainter.Paint(g, mousePosition ?? new Point(-1, -1));
			}

			if (State != null && CheckState?.ShowSearchArea == true)
			{
				if (searchAreaPainter == null)
				{
					searchAreaPainter = State.GetAreaPainter(w, h);
				}
				searchAreaPainter?.Paint(g, w, h);
			}

			if (SelectedEvent != null)
			{
				using (var eventDetails = SelectedEvent.EventDetails)
				using (var attributes = eventDetails.Attributes)
				using (var vh = eventDetails.VehicleDetails)
				using (var clothing = eventDetails.ClothingDetails)
				using (var licensePlates = eventDetails.LicensePlateDetails)
				{
					var vhRect = eventDetails.SubjectType.HasFlag(NSurveillanceModalityType.VehiclesAndHumans) ? eventDetails.Rectangle : Rectangle.Empty;
					DrawSubject(g, attributes, vhRect, licensePlates?.Current.FirstOrDefault(), mousePosition);
				}
			}
			else
			{
				var vhRect = Info.BestFrameIndex == Info.Object.FrameIndex ?
					Info.Object.Rect : Rectangle.Empty;
				DrawSubject(g, Info.Face.BestAttributes, vhRect, Info.LicensePlate.Best, mousePosition);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			var g = e.Graphics;
			if (_bmp != null)
			{
				PrepareGraphics(g, new Matrix());
				g.DrawImage(_bmp, 0, 0, _bmp.Width, _bmp.Height);

				var dx = Math.Max(0, (int)(((Width) - _bmp.Width * Zoom) / 2.0f));
				var dy = Math.Max(0, (int)((Height - _bmp.Height * Zoom) / 2.0f));
				var pos = PointToClient(MousePosition);
				var mousePosition = new Point
				{
					X = (int)((pos.X - dx) / Zoom - AutoScrollPosition.X / Zoom),
					Y = (int)((pos.Y - dy) / Zoom - AutoScrollPosition.Y / Zoom)
				};

				DrawOn(g, _bmp.Width, _bmp.Height, dx, dy, mousePosition, ref _triggerPainter, ref _searchAreaPainter);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Invalidate();
		}

		#endregion
	}
}
