using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace Neurotec.Samples.Drawing
{
	public class SearchAreaPainter : IDisposable
	{
		#region Private fields

		private Bitmap _full;
		private int _imageWidth, _imageHeight;
		private Bitmap _overlay;

		#endregion

		#region Private constructor

		private SearchAreaPainter()
		{
		}

		#endregion

		#region Public static methods

		public static SearchAreaPainter Create(NSurveillanceSource source, int targetWidth, int targetHeight, byte alpha = 25)
		{
			return new SearchAreaPainter
			{
				_full = CreateRegionBitmap(source.SearchArea, targetWidth, targetHeight, alpha)
			};
		}

		#endregion

		#region Public properties

		public int ImageWidth { get => _imageWidth; }
		public int ImageHeight { get => _imageHeight; }

		#endregion

		private static Bitmap CreateRegionBitmap(IEnumerable<NSearchArea> areas, int w, int h, byte alpha = 25)
		{
			Bitmap bmp = null;

			PointF ToAbsolute(PointF p) => new PointF(p.X * w, p.Y * h);
			RectangleF ToAbsoluteRect(RectangleF r) => new RectangleF
			{
				X = r.X * w,
				Y = r.Y * h,
				Width = r.Width * w,
				Height = r.Height * h
			};

			GraphicsPath CreatePath(NSearchArea area)
			{
				if (area is NPolygonSearchArea polygon)
				{
					var gp = new GraphicsPath();
					gp.AddPolygon(polygon.Points.Select(ToAbsolute).ToArray());
					gp.CloseFigure();
					return gp;
				}
				else if (area is NRectangleSearchArea rectArea)
				{
					var gp = new GraphicsPath();
					gp.AddRectangle(ToAbsoluteRect(rectArea.Rectangle));
					return gp;
				}
				else
					throw new NotImplementedException();
			}

			try
			{
				bmp = new Bitmap(w, h);
				using (var g = Graphics.FromImage(bmp))
				using (var greenBrush = new SolidBrush(Color.FromArgb(alpha, 0, 255, 0)))
				using (var redBrush = new SolidBrush(Color.FromArgb(alpha, 255, 0, 0)))
				{
					Region topLevelUnion = null;
					foreach (var area in areas.Reverse())
					{
						using (var path = CreatePath(area))
						{
							var activeRegion = new Region(path);
							if (topLevelUnion != null)
							{
								if (!activeRegion.IsEmpty(g) && !activeRegion.IsInfinite(g))
									activeRegion.Exclude(topLevelUnion);
								if (area is NRectangleSearchArea rectArea)
									topLevelUnion.Union(ToAbsoluteRect(rectArea.Rectangle));
								else
									topLevelUnion.Union(activeRegion.Clone() as Region);
							}
							else
							{
								topLevelUnion = activeRegion;
							}

							g.FillRegion(area.Type == NSearchAreaType.Include ? greenBrush : redBrush, activeRegion);
							if (topLevelUnion != activeRegion)
								activeRegion.Dispose();
						}
					}
					topLevelUnion?.Dispose();
				}
			}
			catch
			{
				bmp.Dispose();
				throw;
			}

			return bmp;
		}

		#region Public methods

		public void Paint(Graphics g, int targetWidth, int targetHeight, float dx = 0, float dy = 0)
		{
			if (_overlay == null || _overlay.Width != targetWidth || _overlay.Height != targetHeight)
			{
				_overlay?.Dispose();
				_overlay = null;

				if (targetWidth != _imageWidth || targetHeight != _imageHeight)
				{
					_overlay = ScaleBitmap(_full, targetWidth, targetHeight);
				}
				else
				{
					_overlay = (Bitmap)_full.Clone();
				}
			}

			g.DrawImage(_overlay, dx, dy);
		}

		public SearchAreaPainter GetCopy()
		{
			return new SearchAreaPainter
			{
				_full = (Bitmap)_full.Clone(),
				_imageHeight = _imageHeight,
				_imageWidth = _imageWidth,
			};
		}

		#endregion

		#region Private static methods

		private static Bitmap ScaleBitmap(Bitmap target, int width, int height)
		{
			var dstImage = new Bitmap(width, height);
			dstImage.SetResolution(target.HorizontalResolution, target.VerticalResolution);
			using (var graphics = Graphics.FromImage(dstImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(target, new Rectangle(0, 0, width, height), 0, 0, target.Width, target.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}
			return dstImage;
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			_overlay?.Dispose();
			_full?.Dispose();
		}

		#endregion
	}

}
