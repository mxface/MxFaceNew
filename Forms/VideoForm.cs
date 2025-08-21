using Neurotec.Media;
using Neurotec.Samples.Config;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class VideoForm : Form
	{
		#region Private types

		private enum OpenStatus
		{
			Pending,
			InProgress,
			Opened,
			Error,
			Canceled
		}

		private class VideoStatus
		{
			public string Id { get; set; }
			public string DisplayName { get; set; }
			public string FileName { get; set; }
			public OpenStatus Status { get; set; }
			public string Resolution { get; set; } = "-";
			public string Length { get; set; } = "-";
			public string Error { get; set; }

			public int Index { get; set; }
			public NMediaReader Reader { get; set; }

			public bool FromHistory { get; set; }
			public bool InHistory { get; set; }
		}

		#endregion

		#region Private fields

		private CancellationTokenSource _tokenSource = new CancellationTokenSource();
		private List<VideoStatus> _videos = new List<VideoStatus>();
		private List<VideoStatus> _openQue = new List<VideoStatus>();
		private List<VideoStatus> _removeFromHistory = new List<VideoStatus>();
		private Task _openTask = null;

		private static readonly string GroupRecent = "lvgRecent";
		private static readonly string GroupSelected = "lvgSelected";

		private const int HistorySize = 256;

		#endregion

		#region Public constructor

		public VideoForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods

		private static bool OpenReader(VideoStatus e, bool preferVlc)
		{
			try
			{
				if (File.Exists(e.FileName))
				{
					e.Reader = new NMediaReader(e.FileName, NMediaType.Video, false, preferVlc ? NMediaSource.FlagPreferVlc : 0u);
					e.Length = e.Reader.Length > TimeSpan.FromSeconds(0) ? e.Reader.Length.ToString() : "-";

					try
					{
						var format = e.Reader.Source.GetCurrentFormat(NMediaType.Video) as NVideoFormat;
						if (format != null)
						{
							e.Resolution = string.Format("{0} x {1}", format.Width, format.Height);
						}
					}
					catch
					{
					}

					e.Status = OpenStatus.Opened;
					return true;
				}
				else
				{
					e.Status = OpenStatus.Error;
					e.Error = "File not found";
				}
			}
			catch (Exception ex)
			{
				e.Error = ex.Message;
				e.Status = OpenStatus.Error;
			}
			return false;
		}

		private void OnVideoStatusChanged(VideoStatus e)
		{
			var item = lvVideos.Items.Cast<ListViewItem>()
				.Where(x => x.Tag == e)
				.FirstOrDefault();

			if (item == null) return;

			var lviStatus = item.SubItems[1];
			lviStatus.Text = e.Status.ToString();
			if (e.Status >= OpenStatus.Error)
			{
				item.ForeColor = Color.Red;
				item.ToolTipText = $"Couldn't open file: {e.Error}";
				if (e.FromHistory)
				{
					_removeFromHistory.Add(e);
				}
			}
			else if (e.Status == OpenStatus.Opened)
			{
				item.ForeColor = Color.Green;
			}

			item.SubItems[2].Text = e.Resolution;
			item.SubItems[3].Text = e.Length;
		}

		private void Enable(bool enable)
		{
			btnBrowse.Enabled = enable;
			btnOk.Enabled = enable;
			btnReset.Enabled = enable;
			chbPreferVlc.Enabled = enable;
		}

		private void CleanupVideos()
		{
			if (_videos.Any())
			{
				foreach (var v in _videos)
				{
					v.Reader?.Dispose();
					v.Reader = null;
				}
				_videos.Clear();
			}
		}

		private ListViewItem MoveFromHistory(ListViewItem item, VideoStatus entry)
		{
			lvVideos.Items.Remove(item);

			entry.InHistory = false;
			var lvi = new ListViewItem(new[] { entry.FileName, entry.Status.ToString(), "-", "-" })
			{
				UseItemStyleForSubItems = true,
				Group = lvVideos.Groups[GroupSelected],
				Tag = entry,
			};
			lvVideos.Items.Insert(0, lvi);
			return lvi;
		}

		private ListViewItem MoveToHistory(ListViewItem item, VideoStatus entry)
		{
			lvVideos.Items.Remove(item);

			entry.FromHistory = true;
			entry.Reader?.Dispose();
			entry.Reader = null;
			entry.InHistory = true;
			entry.Status = OpenStatus.Pending;
			return AddListEntry(entry);
		}

		private ListViewItem AddListEntry(VideoStatus entry, ListViewGroup preferedGroup = null)
		{
			ListViewGroup group = null;
			string[] columns = null;
			if (entry == null)
			{
				group = preferedGroup ?? lvVideos.Groups[GroupSelected];
				columns = new[] { "", "", "", "" };
			}
			else
			{
				group = preferedGroup ?? (entry.InHistory ? lvVideos.Groups[GroupRecent] : lvVideos.Groups[GroupSelected]);
				if (entry.InHistory)
					columns = new[] { entry.FileName, "", "", "" };
				else
					columns = new[] { entry.FileName, entry.Status.ToString(), entry.Resolution, entry.Length };
			}

			var lvi = new ListViewItem(columns)
			{
				UseItemStyleForSubItems = true,
				Group = group,
				Tag = entry,
			};
			if (entry?.Status == OpenStatus.Opened)
			{
				lvi.ForeColor = Color.Green;
			}
			else if (entry?.Status >= OpenStatus.Error)
			{
				lvi.ForeColor = Color.Red;
			}

			lvVideos.Items.Add(lvi);
			return lvi;
		}

		private void EnsureGroupsVisible()
		{
			bool addSelected = true;
			bool addRecent = true;
			foreach (ListViewItem item in lvVideos.Items)
			{
				if (item.Tag is null)
				{
					if (item.Group.Name == GroupRecent)
					{
						addRecent = false;
					}
					else if (item.Group.Name == GroupSelected)
					{
						addSelected = false;
					}
				}
			}

			if (addSelected)
				AddListEntry(null, lvVideos.Groups[GroupSelected]);
			if (addRecent)
				AddListEntry(null, lvVideos.Groups[GroupRecent]);
		}

		private void EnsureNotNeededItemsNotShown()
		{
			bool hasSelected = false;
			bool hasRecent = false;
			ListViewItem emptyRecent = null;
			ListViewItem emptySelected = null;

			foreach (ListViewItem item in lvVideos.Items)
			{
				if (item.Tag is VideoStatus status)
				{
					if (status.InHistory)
						hasRecent = true;
					else
						hasSelected = true;
				}
				else
				{
					if (item.Group.Name == GroupSelected)
						emptySelected = item;
					else
						emptyRecent = item;
				}
			}

			if (hasSelected && emptySelected != null)
				lvVideos.Items.Remove(emptySelected);
			if (hasRecent && emptyRecent != null)
				lvVideos.Items.Remove(emptyRecent);
		}

		private void CheckScheduleVideoFileOpen()
		{
			if (_openTask == null || _openTask.IsCompleted)
			{
				if (_openQue.Any())
				{
					Enable(false);
					_openTask = OpenVideoFilesTask(_openQue);
					_openQue = new List<VideoStatus>();
					return;
				}
				else
				{
					_openTask = null;
					Enable(true);
				}
			}
		}

		private async Task OpenVideoFiles(params string[] files)
		{
			_tokenSource = new CancellationTokenSource();
			tbFilter.Text = string.Empty;

			Enable(false);

			lvVideos.SuspendLayout();

			var opening = new List<VideoStatus>();

			var group = lvVideos.Groups[GroupSelected];
			foreach (var fileName in files)
			{
				var existing = lvVideos.Items.Cast<ListViewItem>()
					.Where(x => ((VideoStatus)x.Tag)?.FileName == fileName)
					.FirstOrDefault();
				if (existing != null)
				{
					var status = existing.Tag as VideoStatus;
					if (status.InHistory)
					{
						MoveFromHistory(existing, status);
						opening.Add(status);
						continue;
					}
					else
					{
						// File already opened
						continue;
					}
				}

				var entry = new VideoStatus { FileName = fileName, DisplayName = Path.GetFileName(fileName) };
				AddListEntry(entry);
				_videos.Add(entry);
				opening.Add(entry);
			}

			EnsureNotNeededItemsNotShown();
			EnsureGroupsVisible();

			lvVideos.ResumeLayout();
			_openTask = OpenVideoFilesTask(opening);

			await _openTask;
		}

		private Task OpenVideoFilesTask(List<VideoStatus> items)
		{
			bool preferVlc = chbPreferVlc.Checked;
			return Task.Factory.StartNew(() =>
			{
				foreach (var item in items)
				{
					if (!_tokenSource.IsCancellationRequested)
					{
						item.Status = OpenStatus.InProgress;
						BeginInvoke(new Action<VideoStatus>(OnVideoStatusChanged), item);
						OpenReader(item, preferVlc);
					}
					else
					{
						item.Status = OpenStatus.Canceled;
					}
					BeginInvoke(new Action<VideoStatus>(OnVideoStatusChanged), item);
				}

				BeginInvoke(new Action(CheckScheduleVideoFileOpen));
			});
		}

		private async void BtnBrowseClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				await OpenVideoFiles(openFileDialog.FileNames);
			}
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			if (_videos.Any() == false)
			{
				MessageBox.Show("Please select a video file(s)");
			}
			else if (_videos.Any(x => x.Status == OpenStatus.Opened) == false)
			{
				MessageBox.Show("Couldn't open any videos, please select a video file(s)");
			}
			else
			{
				Sources = _videos
					.Where(x => x.Status == OpenStatus.Opened && !x.InHistory)
					.Select(x =>
					{
						var src = new NSurveillanceSource(SelectedModality, x.Reader);
						src.SetProperty("FullPath", x.FileName);
						return src;
					})
					.ToArray();

				UpdateRecentHistory();
				DialogResult = DialogResult.OK;
			}
		}

		private void UpdateRecentHistory()
		{
			var history = SurveillanceConfig.RecentSources;
			var newVideos = _videos.Where(x => x.Status == OpenStatus.Opened)
				.Select(x => new RecentSourceConfig()
				{
					Id = x.Reader.Source.Id,
					Name = x.DisplayName,
					Path = x.FileName,
					LastOpened = DateTime.Now,
				})
				.ToArray();

			foreach (var value in newVideos)
			{
				history[value.Id] = value;
			}

			foreach (var remove in _removeFromHistory)
			{
				history.Remove(remove.Id);
			}

			if (history.Count > HistorySize)
			{
				var toRemove = history
					.OrderBy(x => x.Value.LastOpened)
					.Take(history.Count - HistorySize)
					.Select(x => x.Key)
					.ToArray();
				foreach (var key in toRemove)
				{
					history.Remove(key);
				}
			}

			SurveillanceConfig.RecentSources = history;
		}

		private void BtnCancelClick(object sender, EventArgs e)
		{
			_tokenSource.Cancel();
			if (btnBrowse.Enabled)
			{
				CleanupVideos();
				DialogResult = DialogResult.Cancel;
			}
		}

		private void BtnResetClick(object sender, EventArgs e)
		{
			ResetViews();
			Enable(true);
		}

		private void TbFileNameTextChanged(object sender, EventArgs e)
		{
			var term = tbFilter.Text?.ToLower() ?? string.Empty;
			lvVideos.SuspendLayout();
			lvVideos.Items.Clear();

			IEnumerable<VideoStatus> filtered = _videos;

			if (term != string.Empty)
			{
				filtered = _videos
					.Where(x => x.FileName.ToLower().Contains(term))
					.Select(x => new { inName = x.DisplayName.ToLower().Contains(term), value = x })
					.OrderByDescending(x => x.inName)
					.ThenBy(x => x.value.FileName)
					.Select(x => x.value)
					.ToArray();
			}

			var groupRecent = lvVideos.Groups[GroupRecent];
			var groupSelected = lvVideos.Groups[GroupSelected];

			foreach (var video in filtered)
			{
				AddListEntry(video);
			}

			EnsureGroupsVisible();
			EnsureNotNeededItemsNotShown();
			lvVideos.ResumeLayout();
		}

		private void VideoFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!btnOk.Enabled)
			{
				e.Cancel = true;
				_tokenSource.Cancel();
			}
		}

		private void ResetViews()
		{
			CleanupVideos();
			lvVideos.Items.Clear();

			var recent = SurveillanceConfig.RecentSources;
			foreach (var src in recent.Values.OrderByDescending(x => x.LastOpened).ThenBy(x => x.Name))
			{
				var entry = new VideoStatus { FileName = src.Path, DisplayName = src.Name, FromHistory = true, InHistory = true, Id = src.Id };
				AddListEntry(entry);
				_videos.Add(entry);
			}

			EnsureGroupsVisible();
		}

		private void VideoFormShown(object sender, EventArgs e)
		{
			SelectedModality = AllowedModalityTypes & SelectedModality;
			if (SelectedModality == NSurveillanceModalityType.None)
				SelectedModality = AllowedModalityTypes;

			tsbFaces.Checked = SelectedModality.HasFlag(NSurveillanceModalityType.Faces);
			tsbLpr.Checked = SelectedModality.HasFlag(NSurveillanceModalityType.LicensePlateRecognition);
			tsbObjects.Checked = SelectedModality.HasFlag(NSurveillanceModalityType.VehiclesAndHumans);

			if (IsMoreThanOneFlagSet(AllowedModalityTypes))
			{
				tsbFaces.Visible = AllowedModalityTypes.HasFlag(NSurveillanceModalityType.Faces);
				tsbObjects.Visible = AllowedModalityTypes.HasFlag(NSurveillanceModalityType.VehiclesAndHumans);
				tsbLpr.Visible = AllowedModalityTypes.HasFlag(NSurveillanceModalityType.LicensePlateRecognition);
			}
			else
			{
				toolStripModalities.Visible = false;
				lblModalities.Visible = false;
			}

			ResetViews();
		}

		private static bool IsMoreThanOneFlagSet(NSurveillanceModalityType value)
		{
			return (value & (value - 1)) != 0;
		}

		private void OnModalityCheckChanged(bool check, NSurveillanceModalityType modality)
		{
			var value = SelectedModality;
			if (check)
				value |= modality;
			else
				value &= ~modality;

			if (value == NSurveillanceModalityType.None)
			{
				bool SetIfSupported(NSurveillanceModalityType t, ToolStripButton tsb)
				{
					if (modality != t && AllowedModalityTypes.HasFlag(t))
					{
						tsb.Checked = true;
						value |= t;
						return true;
					}
					return false;
				}

				if (!SetIfSupported(NSurveillanceModalityType.Faces, tsbFaces))
				{
					if (!SetIfSupported(NSurveillanceModalityType.VehiclesAndHumans, tsbObjects))
						SetIfSupported(NSurveillanceModalityType.LicensePlateRecognition, tsbLpr);
				}
			}

			SelectedModality = value;
		}

		private void TsbFacesClick(object sender, EventArgs e)
		{
			OnModalityCheckChanged(tsbFaces.Checked, NSurveillanceModalityType.Faces);
		}

		private void TsbObjectsClick(object sender, EventArgs e)
		{
			OnModalityCheckChanged(tsbObjects.Checked, NSurveillanceModalityType.VehiclesAndHumans);
		}

		private void TsbLprClick(object sender, EventArgs e)
		{
			OnModalityCheckChanged(tsbLpr.Checked, NSurveillanceModalityType.LicensePlateRecognition);
		}

		private void LvVideosMouseDoubleClick(object sender, MouseEventArgs e)
		{
			var item = lvVideos.HitTest(e.X, e.Y)?.Item;
			if (item != null && item.Tag is VideoStatus videoStatus)
			{
				if (videoStatus.InHistory)
				{
					lvVideos.SuspendLayout();
					MoveFromHistory(item, videoStatus);
					EnsureNotNeededItemsNotShown();
					EnsureGroupsVisible();

					_openQue.Add(videoStatus);
					CheckScheduleVideoFileOpen();
					lvVideos.ResumeLayout();
				}
				else if (videoStatus.Status >= OpenStatus.Opened)
				{
					MoveToHistory(item, videoStatus);
					EnsureNotNeededItemsNotShown();
					EnsureGroupsVisible();
				}
				else
				{
					System.Media.SystemSounds.Beep.Play();
				}
			}
		}

		#endregion

		#region Protected methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Delete)
			{
				lvVideos.SuspendLayout();
				foreach (var item in lvVideos.Items.Cast<ListViewItem>().ToArray())
				{
					if (item.Tag is VideoStatus videoStatus)
					{
						if (videoStatus.InHistory == false && videoStatus.Status >= OpenStatus.Opened)
						{
							if (videoStatus.FromHistory)
							{
								MoveToHistory(item, videoStatus);
							}
							else
							{
								videoStatus.Reader?.Dispose();
								_videos.Remove(videoStatus);
								lvVideos.Items.Remove(item);
							}
						}
					}
				}
				EnsureGroupsVisible();
				EnsureNotNeededItemsNotShown();
				lvVideos.ResumeLayout();
			}
			else if (keyData == (Keys.F | Keys.Control))
			{
				tbFilter.Focus();
				tbFilter.SelectAll();
				return true;
			}
			else if (keyData == Keys.Enter && tbFilter.Focused)
			{
				var history = lvVideos.Items.Cast<ListViewItem>()
					.Where(x => x.Tag != null)
					.ToArray();

				if (history.Length > 0)
				{
					lvVideos.SelectedItems.Clear();
					lvVideos.Focus();
					history[0].EnsureVisible();
					history[0].Selected = true;
				}
				else
				{
					System.Media.SystemSounds.Beep.Play();
				}
				return true;
			}
			else if (keyData == Keys.Enter && lvVideos.Focused)
			{
				var selected = lvVideos.SelectedItems.Cast<ListViewItem>()
					.Where(x => x.Tag != null)
					.ToArray();
				if (selected.Length > 0)
				{
					bool sameGroup = selected.Select(x => x.Group.Name).Distinct().Count() == 1;
					if (sameGroup)
					{
						lvVideos.SuspendLayout();
						foreach (var item in selected)
						{
							var videoStatus = (VideoStatus)item.Tag;
							if (videoStatus.InHistory)
							{
								MoveFromHistory(item, videoStatus);
								_openQue.Add(videoStatus);
							}
							else if (videoStatus.Status >= OpenStatus.Opened)
							{
								MoveToHistory(item, videoStatus);
							}
						}
						EnsureGroupsVisible();
						EnsureNotNeededItemsNotShown();
						lvVideos.ResumeLayout();
						CheckScheduleVideoFileOpen();
					}
					else
					{
						System.Media.SystemSounds.Beep.Play();
					}
				}
				return true;
			}
			else if (keyData == (Keys.O | Keys.Control) && btnBrowse.Enabled)
			{
				btnBrowse.PerformClick();
				return true;
			}
			else if (keyData == (Keys.C | Keys.Control) && lvVideos.SelectedItems.Count > 0)
			{
				if (lvVideos.SelectedItems[0].Tag is VideoStatus videoStatus)
				{
					Clipboard.SetText(videoStatus.FileName);
				}
			}
			else if (keyData == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion

		#region Public properties

		public NSurveillanceSource[] Sources
		{
			get;
			private set;
		}

		public NSurveillanceModalityType AllowedModalityTypes { get; set; }

		public NSurveillanceModalityType SelectedModality { get; set; }

		#endregion
	}
}
