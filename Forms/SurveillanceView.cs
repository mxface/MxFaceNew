using Neurotec.Images;
using Neurotec.Media;
using Neurotec.Samples.Code;
using Neurotec.Samples.Drawing;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class SurveillanceView : UserControl
	{
		#region Private constants

		private const uint SrcCopy = 0x00CC0020;
		private const int StretchHalftone = 4;

		#endregion

		#region External code

		[DllImport("gdi32")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		[DllImport("gdi32")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32")]
		private static extern bool DeleteObject(IntPtr hObject);

		[DllImport("gdi32")]
		private static extern bool DeleteDC(IntPtr hdc);

		[DllImport("gdi32")]
		static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

		[DllImport("gdi32")]
		private static extern bool SetStretchBltMode(IntPtr hdc, int stretchMode);

		#endregion

		#region Private fields

		private NImage _image = null;
		private NVideoSample _sample = null;
		private IntPtr _bmp = IntPtr.Zero;
		private int _imageWidth, _imageHeight;
		private Task<(IntPtr hBitmap, int width, int height)> _convertTask = null;

		private SourceController _state;
		private string _sourceName = string.Empty;
		private string _errorMessage = string.Empty;
		private NMediaState _mediaState = NMediaState.Running;
		private Queue<DateTime> _framesInTime = new Queue<DateTime>();
		private Queue<DateTime> _framesInRealTime = new Queue<DateTime>();
		private double _progress = double.NaN;

		private Brush _runningBrush = Brushes.GreenYellow;
		private Brush _pendingBrush = Brushes.Black;
		private Brush _errorBrush = Brushes.Red;
		private Font _boldFont;
		private Color _regionColor = Color.FromArgb(50, 0, 255, 0);

		private SearchAreaPainter _searchAreaOverlay;
		private TriggerPainter _triggersOverlay;

		#endregion

		#region Public constructor

		public SurveillanceView()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public SourceController State
		{
			get { return _state; }
			set
			{
				if (_state != value)
				{
					if (_state != null)
					{
						_state.Source.PropertyChanged -= SourcePropertyChanged;
						_state.PropertyChanged -= SourceStateChanged;
					}

					_state = value;
					ResetOverlay();
					if (_state != null)
					{
						_state.Source.PropertyChanged += SourcePropertyChanged;
						_state.PropertyChanged += SourceStateChanged;
						_sourceName = _state.Source.Camera?.DisplayName ?? _state.Source.Video.Source.ToString();

						_mediaState = _state.Source.State;
					}

					sourceHeader.Title = _state?.ToString();
					sourceHeader.State = value;
					Reset();

					UpdateSourceHeaderLocation(value?.ShowSourceHeader ?? true);
				}
			}
		}

		public double FpsMeasureTime { get; set; } = 3;

		#endregion

		#region Protected methods

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			drawPanel.Invalidate();
			_triggersOverlay?.Dispose();
			_triggersOverlay = null;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);

			State = null;
			_image?.Dispose();
			_sample?.Dispose();
			_triggersOverlay?.Dispose();
			DeleteAndZeroBitmap(ref _bmp);
		}

		#endregion

		#region Private methods

		private void PaintOverlay(Graphics g, float dx, float dy, float scale)
		{
			if (State.ShowSearchArea && State.Source.SearchArea.Count > 0)
			{
				if (_searchAreaOverlay == null)
					_searchAreaOverlay = State.GetAreaPainter(_imageWidth, _imageHeight);

				var targetWidth = (int)(scale * _imageWidth);
				var targetHeight = (int)(scale * _imageHeight);
				_searchAreaOverlay.Paint(g, targetWidth, targetHeight, dx, dy);
			}

			if (State.ShowTriggers)
			{
				if (_triggersOverlay == null)
				{
					_triggersOverlay = TriggerPainter.Create(State.Source.AnalyticTriggers, _imageWidth, _imageHeight, scale, dx, dy);
				}
				_triggersOverlay.Paint(g, drawPanel.PointToClient(MousePosition));
			}
		}

		private void SetTitle(Graphics g, float dx, float dy)
		{
			bool isRunning = _mediaState == NMediaState.Running;
			bool withImage = _bmp != IntPtr.Zero;
			var b = GetBrush(isRunning, withImage);
			var f = GetFont();
			var prefix = string.Empty;
			var progressText = string.Empty;
			if (isRunning)
			{
				var numerator = _framesInRealTime.Count / FpsMeasureTime;
				var denominator = _framesInTime.Count / FpsMeasureTime;
				prefix = _framesInTime.Count > 0 ? $"{numerator:f0}/{denominator:f0} fps" : "Waiting for frames";
				if (!double.IsNaN(_progress))
					progressText = $" ({_progress * 100:00.00}%)";
			}
			else if (!string.IsNullOrEmpty(_errorMessage))
			{
				prefix = $"Stopped (Error: {_errorMessage})";
			}
			else
			{
				prefix = $"Stopped";
			}
			var text = $"{prefix} {progressText} - {_sourceName}";
			sourceHeader.Title = text;

			if (!isRunning)
			{
				var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
				g.DrawString(text, f, b, new RectangleF(0, 0, Width, Height), sf);
			}
		}

		private void TryTakeImage(bool force)
		{
			if (force || _convertTask?.IsCompleted == true)
			{
				DeleteAndZeroBitmap(ref _bmp);
				if (_convertTask != null)
				{
					var result = _convertTask.Result;
					_bmp = result.hBitmap;
					_imageWidth = result.width;
					_imageHeight = result.height;
					_convertTask = null;
				}
			}

			if (_convertTask == null && (_image != null || _sample != null))
			{
				_convertTask = ConvertAndInvalidate();
			}
		}

		private Task<(IntPtr hBitmap, int width, int height)> ConvertAndInvalidate()
		{
			Task<(IntPtr hBitmap, int width, int height)> task = null;

			if (_image != null)
			{
				var image = _image;
				_image = null;

				task = Task.Run(() =>
				{
					using (image)
					{
						return (image.ToHBitmap(), (int)image.Width, (int)image.Height);
					}
				});
			}
			else if (_sample != null)
			{
				var sample = _sample;
				_sample = null;

				task = Task.Run(() =>
				{
					using (var image = sample.ToImage())
					{
						sample.Dispose();
						return (image.ToHBitmap(), (int)image.Width, (int)image.Height);
					}
				});
			}

			if (task != null)
			{
				task.ContinueWith(_ =>
				{
					BeginInvoke(new Action(() =>
					{
						if (IsHandleCreated)
							drawPanel.Invalidate();
					}));
				});

				return task;
			}

			return null;
		}

		private Font GetFont()
		{
			return _boldFont ?? (_boldFont = new Font(Font.FontFamily, 12, FontStyle.Bold));
		}

		private Brush GetBrush(bool isRunning, bool withImage)
		{
			if (isRunning)
				return withImage ? _runningBrush : _pendingBrush;
			else
				return _errorBrush;
		}

		private void DeleteAndZeroBitmap(ref IntPtr hBitmap)
		{
			if (hBitmap != IntPtr.Zero)
			{
				IntPtr handle = hBitmap;
				hBitmap = IntPtr.Zero;
				Task.Run(() => DeleteObject(handle));
			}
		}

		private void Reset()
		{
			_framesInRealTime.Clear();
			_framesInTime.Clear();
			_image?.Dispose();
			_image = null;
			_sample?.Dispose();
			_sample = null;
			ResetOverlay();
			DeleteAndZeroBitmap(ref _bmp);
			if (_convertTask != null)
			{
				var result = _convertTask.Result.Item1;
				DeleteAndZeroBitmap(ref result);
				_convertTask = null;
			}
			drawPanel.Invalidate();
		}

		private void ResetOverlay()
		{
			_searchAreaOverlay?.Dispose();
			_searchAreaOverlay = null;
			_triggersOverlay?.Dispose();
			_triggersOverlay = null;
		}

		private bool TestMouseIsOver()
		{
			return ClientRectangle.Contains(PointToClient(MousePosition));
		}

		private void UpdateSourceHeaderLocation(bool pinned)
		{
			tableLayoutPanel1.SuspendLayout();
			drawPanel.SuspendLayout();
			tableLayoutPanel1.Controls.Remove(sourceHeader);
			drawPanel.Controls.Remove(sourceHeader);
			if (pinned)
				tableLayoutPanel1.Controls.Add(sourceHeader, 0, 0);
			else
				drawPanel.Controls.Add(sourceHeader);
			drawPanel.ResumeLayout();
			tableLayoutPanel1.ResumeLayout();

			_triggersOverlay?.Dispose();
			_triggersOverlay = null;
		}

		private void SourceStateChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "ShowSourceHeader")
			{
				sourceHeader.Visible = State.ShowSourceHeader || TestMouseIsOver();
				UpdateSourceHeaderLocation(State.ShowSourceHeader);
			}
		}

		private void SourcePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (IsHandleCreated)
			{
				if (e.PropertyName == "State")
				{
					BeginInvoke(new Action<NMediaState>(state =>
					{
						_mediaState = state;
						if (state == NMediaState.Running)
						{
							ResetOverlay();
						}

						Reset();
					}), ((NSurveillanceSource)sender).State);
				}
				else if (e.PropertyName == "Error")
				{
					BeginInvoke(new Action<Exception>(ex =>
					{
						_errorMessage = ex?.Message;
						drawPanel.Invalidate();
					}), ((NSurveillanceSource)sender).Error);
				}
			}
		}

		private void DrawPanelPaint(object sender, PaintEventArgs e)
		{
			if (DesignMode) return;

			float scalex = 1, scaley = 1, scale = 1;
			float dx = 0, dy = 0;

			TryTakeImage(_bmp == IntPtr.Zero);

			var g = e.Graphics;

			bool withImage = _bmp != IntPtr.Zero;
			if (withImage)
			{
				var width = drawPanel.Width;
				var height = drawPanel.Height;

				scalex = (float)width / _imageWidth;
				scaley = (float)height / _imageHeight;
				scale = Math.Min(scalex, scaley);
				dx = (float)Math.Round((width - _imageWidth * scale) / 2.0f);
				dy = (float)Math.Round((height - _imageHeight * scale) / 2.0f);

				var dc = g.GetHdc();
				var srcDc = CreateCompatibleDC(dc);
				var obj = SelectObject(srcDc, _bmp);

				SetStretchBltMode(dc, StretchHalftone);

				StretchBlt(dc, (int)dx, (int)dy, (int)(width - 2 * dx), (int)(height - 2 * dy), srcDc, 0, 0, _imageWidth, _imageHeight, SrcCopy);

				DeleteObject(obj);
				DeleteDC(srcDc);

				g.ReleaseHdc();

				PaintOverlay(g, dx, dy, scale);
			}

			SetTitle(g, dx, dy);
		}

		private void DrawPanelMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 1)
			{
				if (e.Button == MouseButtons.Left && State != null)
				{
					DoDragDrop(State, DragDropEffects.Move | DragDropEffects.Link);
					State.SelectSource();
				}
			}
		}

		private void DrawPanelMouseMove(object sender, MouseEventArgs e)
		{
			if (State?.ShowSourceHeader == false)
			{
				bool isVisible = sourceHeader.Visible;
				if (!isVisible)
				{
					sourceHeader.Visible = true;
				}
			}
		}

		private void DrawPanelMouseLeave(object sender, EventArgs e)
		{
			if (State?.ShowSourceHeader == false && sourceHeader.Visible && !ClientRectangle.Contains(PointToClient(MousePosition)))
			{
				sourceHeader.Visible = false;
			}
		}

		private void SourceHeaderMouseLeft(object sender, EventArgs e)
		{
			if (State?.ShowSourceHeader == false && !TestMouseIsOver())
			{
				sourceHeader.Visible = false;
			}
		}

		#endregion

		#region Public methods

		public void SetCaptureEventData(CaptureEventData data)
		{
			var now = DateTime.Now.ToUniversalTime();

			_progress = data.Progress;
			_framesInTime.Enqueue(data.TimeStamp);
			_framesInRealTime.Enqueue(now);

			for (; ; )
			{
				if ((data.TimeStamp - _framesInTime.Peek()).TotalSeconds > FpsMeasureTime)
					_framesInTime.Dequeue();
				else
					break;
			}

			for (; ; )
			{
				if ((now - _framesInRealTime.Peek()).TotalSeconds > FpsMeasureTime)
					_framesInRealTime.Dequeue();
				else
					break;
			}

			if (_sample != null)
			{
				_sample.Dispose();
				_sample = null;
			}

			if (_image != null)
			{
				_image.Dispose();
				_image = null;
			}

			if (data.Image != null)
			{
				_image = data.Image;
				data.Image = null;
			}
			else if (data.Sample != null)
			{
				_sample = data.Sample;
				data.Sample = null;
			}

			if (_convertTask == null)
			{
				_convertTask = ConvertAndInvalidate();
			}

		}

		#endregion
	}
}
