using Neurotec.Drawing.Drawing2D;
using Neurotec.Images;
using Neurotec.Images.Processing;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Data.Forms
{
	public partial class FacesWatchlistForms : Form
	{
		#region Constants

		private const int PageSize = 50;
		private const int ImageWidth = 140;
		private const int ImageHeight = 180;

		#endregion

		#region Private fields

		private int _page = 0;
		private string _searchTerm = null;

		#endregion

		#region Public constructors

		public FacesWatchlistForms()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public FaceRecordCollection Faces { get; set; }
		public NSurveillance Surveillance { get; set; }

		#endregion

		#region Private methods

		private void UpdateTotalCount()
		{
			lblSubjectCount.Text = $"Subject Count: {Faces.GetCount()}";
		}

		private void ClearImages()
		{
			var images = listView.LargeImageList;

			listView.Clear();
			listView.LargeImageList = null;
			images?.Dispose();
			images = null;
		}

		private IEnumerable<FaceRecord> GetRecords()
		{
			if (string.IsNullOrEmpty(_searchTerm))
			{
				return Faces;
			}
			else
			{
				return Faces.Where(x => x.FaceId.ToLower().Contains(_searchTerm));
			}
		}

		private IEnumerable<FaceRecord> GetPage(int pageNumber)
		{
			return GetRecords().Skip(pageNumber * PageSize).Take(PageSize);
		}

		private IEnumerable<FaceRecord> GetCurrentPage()
		{
			return GetPage(_page);
		}

		private Bitmap GetThumbnail(FaceRecord faceRecord)
		{
			using (var image = Faces.GetThumbnailById(faceRecord.Id))
			using (var rgb = image.PixelFormat != NPixelFormat.Rgb8U ? NImage.FromImage(NPixelFormat.Rgb8U, 0, image) : null)
			{
				var scaleX = (float)ImageWidth / image.Width;
				var scaleY = (float)ImageHeight / image.Height;
				var scale = Math.Min(scaleX, scaleY);
				var dx = (ImageWidth - scale * image.Width) / 2;
				var dy = (ImageHeight - scale * image.Height) / 2;
				using (var dst = NImage.Create(NPixelFormat.Rgb8U, ImageWidth, ImageHeight, 0))
				using (var scaled = Nrgbip.Scale(rgb ?? image, 0, 0, image.Width, image.Height, (uint)(scale * image.Width), (uint)(scale * image.Height), InterpolationMode.Bilinear))
				{
					scaled.CopyTo(dst, (uint)dx, (uint)dy);
					return dst.ToBitmap();
				}
			}
		}

		private void ShowPage(int pageNumber)
		{
			_page = pageNumber < 0 ? 0 : pageNumber;

			ClearImages();
			var images = new ImageList()
			{
				ImageSize = new Size(ImageWidth, ImageHeight),
				ColorDepth = ColorDepth.Depth32Bit
			};

			var page = GetCurrentPage().ToArray();
			var thumbnails = page.AsParallel()
				.AsOrdered()
				.Select(x => GetThumbnail(x))
				.AsSequential();
			foreach (var thumb in thumbnails)
			{
				images.Images.Add(thumb);
			}
			listView.LargeImageList = images;

			int index = 0;
			foreach (var faceRecord in page)
			{
				listView.Items.Add(faceRecord.FaceId, index++);
			}

			UpdatePageCount();
		}

		private void LoadOneMoreRecord()
		{
			var itemCount = listView.Items.Count;
			var nextItem = GetCurrentPage().Skip(itemCount).FirstOrDefault();
			if (nextItem != null)
			{
				var imageList = listView.LargeImageList;
				imageList.Images.Add(GetThumbnail(nextItem));
				listView.Items.Add(nextItem.FaceId, imageList.Images.Count - 1);
			}

			UpdatePageCount();
		}

		private void UpdatePageCount()
		{
			var pageCount = (int)Math.Ceiling(GetRecords().Count() / (float)PageSize);
			if (pageCount > 1)
			{
				lblPage.Text = $"Page {_page + 1} out of {pageCount}";
				lblPage.Visible = btnNext.Visible = btnPrev.Visible = true;
			}
			else
			{
				lblPage.Visible = btnNext.Visible = btnPrev.Visible = false;
				_page = 0;
			}

			btnPrev.Enabled = _page > 0;
			btnNext.Enabled = _page + 1 < pageCount;
		}

		#endregion

		#region Private form events

		private void FacesWatchlistFormsShown(object sender, EventArgs e)
		{
			if (Faces == null) throw new ArgumentNullException(nameof(Faces));
			if (Surveillance == null) throw new ArgumentNullException(nameof(Surveillance));

			openFileDialog.Filter = NImages.GetOpenFileFilterString(true, true);

			UpdateTotalCount();
			ShowPage(0);
		}

		private void TbSearchTextChanged(object sender, EventArgs e)
		{
			_page = 0;
			_searchTerm = tbSearch.Text?.ToLower() ?? string.Empty;
			ShowPage(0);
		}

		private void ListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			btnDelete.Enabled = listView.SelectedItems.Count > 0;
		}

		private void BtnClearClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete all subjects with saved names?", "Confirm clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Faces.Clear();
				Surveillance.RemoveAllTemplates();
				ClearImages();
				_page = 0;
				UpdatePageCount();
				UpdateTotalCount();
			}
		}

		private void BtnDeleteClick(object sender, EventArgs e)
		{
			var selected = listView.SelectedItems[0];
			var name = selected.SubItems[0].Text;
			if (MessageBox.Show($"Are you sure you want to delete subject '{name}'?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Faces.Delete(name);
				Surveillance.RemoveTemplate(name);
				listView.Items.RemoveAt(selected.Index);
				if (listView.Items.Count != 0)
				{
					LoadOneMoreRecord();
					UpdateTotalCount();
				}
				else
				{
					ShowPage(_page - 1);
				}
			}
		}

		private void BtnNextClick(object sender, EventArgs e)
		{
			ShowPage(_page + 1);
		}

		private void BtnPrevClick(object sender, EventArgs e)
		{
			ShowPage(_page - 1);
		}

		private void BtnEnrollImagesClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				using (var enrollDlg = new EnrollForm())
				{
					enrollDlg.Files = openFileDialog.FileNames;
					enrollDlg.Surveillance = Surveillance;
					enrollDlg.FaceRecordsCollection = Faces;
					enrollDlg.ShowDialog();
				};
				ShowPage(_page);
				UpdateTotalCount();
			}
		}

		private void BtnEnrollDirectoryClick(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				using (var enrollDlg = new EnrollForm())
				{
					enrollDlg.DirectoryPath = folderBrowserDialog.SelectedPath;
					enrollDlg.Surveillance = Surveillance;
					enrollDlg.FaceRecordsCollection = Faces;
					enrollDlg.ShowDialog();
				}
				ShowPage(_page);
				UpdateTotalCount();
			}
		}

		#endregion

		#region Protected methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Delete)
			{
				if (!tbSearch.Focused && btnDelete.Enabled)
					btnDelete.PerformClick();
			}
			else if (keyData == Keys.Escape)
			{
				Close();
			}
			else if (keyData == (Keys.F | Keys.Control))
			{
				tbSearch.Focus();
				tbSearch.SelectAll();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion

	}
}
