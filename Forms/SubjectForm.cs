using Neurotec.Samples.Code;
using Neurotec.Samples.Config;
using Neurotec.Samples.Data;
using Neurotec.Surveillance;
using System;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class SubjectForm : Form
	{
		#region Private fields

		private SourceController _selectedSource;
		private bool _saveWithoutOverlay = false;

		#endregion

		#region Public constructors

		public SubjectForm()
		{
			KeyPreview = true;
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public SubjectInfo Info { get; set; }
		public NAnalyticEvent TargetEvent { get; set; }
		public FaceRecordCollection FaceRecords { get; set; }
		public SubjectsView SubjectsView { get; set; }
		public SourceCollection Sources { get; set; }

		#endregion

		#region Private methods

		private void ShowGallery(int index)
		{
			var matches = Info.Face.BestMatches;
			if (index >= 0 && index < matches?.Length)
			{
				var m = matches[index];
				if (FaceRecords.TryGetValue(m.Id, out var record))
				{
					using (var image = FaceRecords.GetThumbnailById(record.Id))
					{
						var old = pbGalery.Image;
						pbGalery.Image = image.ToBitmap();
						old?.Dispose();
					}
				}
				else
				{
					var old = pbGalery.Image;
					pbGalery.Image = (Bitmap)Properties.Resources.Unknown.Clone();
					old?.Dispose();
				}
			}
		}

		private void ShowInfo()
		{
			detailsView1.Info = Info;
			detailsView1.SelectAnalyticEvent(TargetEvent);

			bool hasObjects = !Info.Object.IsEmpty;
			if (!Info.IsFromVideoFile)
			{
				Text = Info.AppearedTimeStamp == new DateTime() ?
					$"Subject #{Info.TraceIndex}" :
					Info.DissapearedTimeStamp == new DateTime() ?
						$"{Info.AppearedTimeStamp.ToLocalTime()} Subject #{Info.TraceIndex}" :
						$"{Info.AppearedTimeStamp.ToLocalTime()} - {Info.DissapearedTimeStamp.ToLocalTime()} Subject #{Info.TraceIndex}";
			}
			else
			{
				Text = Info.IsDisappeared == false?
						$"{Info.AppearedVideoTimeStamp:hh\\:mm\\:ss} Subject #{Info.TraceIndex}" :
						$"{Info.AppearedVideoTimeStamp:hh\\:mm\\:ss} - {Info.DissapearedVideoTimeStamp:hh\\:mm\\:ss} Subject #{Info.TraceIndex}";
			}

			if (hasObjects)
			{
				lblDetectionConf.Text = $"Detection Confidence: {Info.Object.DetectionConfidence * 100:0.00}";
			}
			else
			{
				lblDetectionConf.Visible = false;
			}

			var oldBitmap = pbLicensePlate.Image;
			pbLicensePlate.Image = (Bitmap)Info.LicensePlate.Thumbnail?.Clone();
			oldBitmap?.Dispose();
			if (pbLicensePlate.Image == null)
			{
				tlpLeft.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
			}
			else
			{
				var lp = Info.LicensePlate.Best;
				tlpLeft.RowStyles[1] = new RowStyle(SizeType.Percent, 100 / 3.0f);
				lblLicensePlate.Text = $"License plate: {lp.Value}";
				lblOrigin.Text = $"Origin: {lp.Origin}";
				lblLprDetectionConf.Text = $"Detection confidence: {lp.DetectionConfidence * 100:0.00}";
				lblOcrConf.Text = $"Ocr confidence: {lp.OcrConfidence * 100:0.00}";
			}

			if (hasObjects || !Info.Face.IsEmpty)
			{
				oldBitmap = thumbBox.Image;
				thumbBox.Image = (Bitmap)Info.Thumbnail.Clone();
				oldBitmap?.Dispose();
				tlpLeft.RowStyles[0] = new RowStyle(SizeType.Percent, 100 / 3.0f * 2);
			}
			else
			{
				tlpLeft.RowStyles[0] = new RowStyle(SizeType.Absolute, 0);
			}
			tlpLeft.Invalidate();

			objectView.Info = Info;
			objectView.State = _selectedSource;
			objectView.SelectedEvent = TargetEvent;
			ShowGallery(0);
		}

		private void UpdateInfo()
		{
			if (Info == null)
				throw new InvalidOperationException();

			tlpCenter.SuspendLayout();
			tlpCenter.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 50);
			tlpCenter.RowStyles[2] = new RowStyle(SizeType.AutoSize, 0);

			cbBestMatches.Items.Clear();
			lblBestMatch.Text = string.Empty;
			if (Info.Face.BestMatches?.Any() == true)
			{
				var matches = Info.Face.BestMatches;
				bool multiple = matches.Length > 1;
				if (multiple)
				{
					lblBestMatch.Text = $"Matched with {matches.Length} subjects";
					foreach (var m in matches)
					{
						cbBestMatches.Items.Add($"{m.Id}, score {m.Score}");
					}
					cbBestMatches.SelectedIndex = 0;
					cbBestMatches.Visible = true;
					lblMatches.Visible = true;
				}
				else
				{
					lblBestMatch.Text = $"Matched with {Info.Face.SubjectId}, Score {Info.Face.Score}";
					lblMatches.Visible = false;
					cbBestMatches.Visible = false;
				}
			}
			else
			{
				tlpCenter.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
			}
			tlpCenter.ResumeLayout();

			_selectedSource = Sources.FirstOrDefault(x => x.Id == Info.SourceId);
			ShowInfo();
		}

		private void SubjectFormLoad(object sender, EventArgs e)
		{
			UpdateInfo();
			TargetEvent = null;
			objectView.CheckState = sourceHeader.CheckState = SurveillanceConfig.SubjectFormConfig;
		}

		private void CbBestMatchesSelectedIndexChanged(object sender, EventArgs e)
		{
			ShowGallery(cbBestMatches.SelectedIndex);
		}

		private void ShowPrevious()
		{
			if (SubjectsView.TrySelectPrevious(out var prev))
			{
				Info = prev;
				UpdateInfo();
			}
			else
			{
				SystemSounds.Beep.Play();
			}
		}

		private void ShowNext()
		{
			if (SubjectsView.TrySelectNext(out var next))
			{
				Info = next;
				UpdateInfo();
			}
			else
			{
				SystemSounds.Beep.Play();
			}
		}

		private void BtnNextClick(object sender, EventArgs e)
		{
			ShowNext();
		}

		private void BtnPrevClick(object sender, EventArgs e)
		{
			ShowPrevious();
		}

		private void DetailsViewShowTriggerDetails(object sender, DetailsView.ShowArgs e)
		{
			objectView.SelectedEvent = e.AnalyticEvent;
		}

		private void SaveImage()
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (_saveWithoutOverlay)
					{
						var analyticEvent = detailsView1.GetSelecedAnalyticEvent();
						if (analyticEvent != null)
						{
							using (var eventDetails = analyticEvent.EventDetails)
							using (var image = eventDetails.GetOriginalImage(false))
							{
								image.Save(saveFileDialog.FileName);
							}
						}
						else
						{
							Info.BestImage.Save(saveFileDialog.FileName);
						}
					}
					else
					{
						using (var bmp = objectView.DrawOnImage())
						{
							bmp.Save(saveFileDialog.FileName);
						}
					}
				}
				catch (Exception ex)
				{
					Utils.ShowException(ex);
				}
			}
		}

		private void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			_saveWithoutOverlay = false;
			toolStripSave.Text = "Save Image";
			SaveImage();
		}

		private void SaveToolStripWithoutOverlayClick(object sender, EventArgs e)
		{
			_saveWithoutOverlay = true;
			toolStripSave.Text = "Save Original Image";
			SaveImage();
		}

		private void ToolStripButtonClick(object sender, EventArgs e)
		{
			SaveImage();
		}

		private void SubjectFormFormClosing(object sender, FormClosingEventArgs e)
		{
			SurveillanceConfig.SubjectFormConfig = sourceHeader.CheckState;
		}

		#endregion

		#region Protected methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				Close();
				return true;
			}
			else if (keyData == Keys.Left)
			{
				ShowPrevious();
				return true;
			}
			else if (keyData == Keys.Right)
			{
				ShowNext();
				return true;
			}
			else if (keyData == Keys.Down || keyData == Keys.Up)
			{
				bool up = keyData == Keys.Up;
				if (Info.HasEvents)
				{
					var selected = detailsView1.GetSelecedAnalyticEvent();
					if (selected == null && !up)
					{
						detailsView1.SelectAnalyticEvent(Info.Events[0]);
					}
					else if (selected != null)
					{
						var index = Array.IndexOf(Info.Events, selected) + (up ? -1 : 1);
						if (index >= 0 && index < Info.Events.Length)
						{
							detailsView1.SelectAnalyticEvent(Info.Events[index]);
						}
						else if (index == -1)
						{
							detailsView1.SelectAnalyticEvent(null);
						}
					}
				}
			}
			else if (keyData.HasFlag(Keys.Control))
			{
				var key = keyData & Keys.KeyCode;
				var state = sourceHeader.CheckState;
				if (key == Keys.D1 || key == Keys.NumPad1)
				{
					state.ShowTrackLine = !state.ShowTrackLine;
				}
				else if (key == Keys.D2 || key == Keys.NumPad2)
				{
					state.ShowSearchArea = !state.ShowSearchArea;
				}
				else if (key == Keys.D3 || key == Keys.NumPad3)
				{
					state.ShowTriggers = !state.ShowTriggers;
				}
				else if (key == Keys.S)
				{
					SaveImage();
				}
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion
	}
}
