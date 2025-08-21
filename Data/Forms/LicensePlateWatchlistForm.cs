using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Data.Forms
{
	public partial class LicensePlateWatchlistForm : Form
	{
		#region Constants

		private const int PageSize = 50;

		#endregion

		#region Private fields

		private string _searchTerm = string.Empty;

		#endregion

		#region Public constructor

		public LicensePlateWatchlistForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public LicensePlateCollection LicensePlates { get; set; }
		public string TargetValue { get; set; }

		#endregion

		#region Private methods

		private void UpdateTotalCount()
		{
			lblTotal.Text = $"Subject Count: {LicensePlates.GetCount()}";
		}

		private IEnumerable<LicensePlateRecord> GetLicensePlates()
		{
			if (!string.IsNullOrWhiteSpace(_searchTerm))
			{
				var term = _searchTerm.ToUpperInvariant();
				return LicensePlates.Where(x => x.Value.Contains(term)).OrderBy(x => x.Value);
			}
			return LicensePlates.OrderBy(x => x.Value);
		}

		private void ShowList()
		{
			listViewPlates.BeginUpdate();

			var selected = listViewPlates.SelectedItems.OfType<ListViewItem>().FirstOrDefault()?.SubItems[0].Text;
			ListViewItem selectedItem = null;
			listViewPlates.Clear();
			foreach (var plateRecord in GetLicensePlates())
			{
				var plate = string.IsNullOrEmpty(plateRecord.Owner) ? plateRecord.Value : $"{plateRecord.Value} - {plateRecord.Owner}";
				var item = listViewPlates.Items.Add(plate);
				item.Tag = plateRecord.Value;
				if (selected == plate)
				{
					item.Selected = true;
					selectedItem = item;
				}
			}

			listViewPlates.EndUpdate();
			selectedItem?.EnsureVisible();
		}

		private string CleanLicensePlate(string value)
		{
			return tbSearchAndAdd.Text?.Trim().ToUpperInvariant() ?? string.Empty;
		}

		#endregion

		#region Private form events

		private void BtnAddClick(object sender, EventArgs e)
		{
			var value = CleanLicensePlate(tbSearchAndAdd.Text);
			if (string.IsNullOrWhiteSpace(value))
			{
				System.Media.SystemSounds.Beep.Play();
			}
			if (LicensePlates.Contains(value))
			{
				System.Media.SystemSounds.Beep.Play();
				return;
			}

			LicensePlates.Add(value, tbOwner.Text);
			var item = listViewPlates.Items.Add(value);
			item.Selected = true;
			item.Tag = value;
			tbSearchAndAdd.Text = string.Empty;
			tbOwner.Text = string.Empty;
			item.EnsureVisible();

			UpdateTotalCount();
			tbSearchAndAdd.Focus();
		}

		private void TbSearchTextChanged(object sender, EventArgs e)
		{
			_searchTerm = CleanLicensePlate(tbSearchAndAdd.Text);
			btnAdd.Enabled = !string.IsNullOrWhiteSpace(_searchTerm);
			ShowList();
		}

		private void LicensePlateWatchlistFormShown(object sender, EventArgs e)
		{
			if (LicensePlates == null) throw new ArgumentNullException(nameof(LicensePlates));

			tbSearchAndAdd.Text = TargetValue;
			_searchTerm = TargetValue;

			ShowList();
			UpdateTotalCount();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Delete)
			{
				if (!tbSearchAndAdd.Focused && btnDelete.Enabled)
					btnDelete.PerformClick();
			}
			else if (keyData == Keys.Enter)
			{
				if (tbSearchAndAdd.Focused && btnAdd.Enabled)
					tbOwner.Focus();
				else if (tbOwner.Focused && btnAdd.Enabled)
					btnAdd.PerformClick();
			}
			else if (keyData == Keys.Escape)
			{
				Close();
			}
			else if (keyData == (Keys.F | Keys.Control))
			{
				tbSearchAndAdd.Focus();
				tbSearchAndAdd.SelectAll();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void BtnDeleteClick(object sender, EventArgs e)
		{
			var selected = listViewPlates.SelectedItems[0];
			var value = (string)selected.Tag;
			if (MessageBox.Show($"Are you sure you want to delete subject '{value}'?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				LicensePlates.Delete(value);
				listViewPlates.Items.RemoveAt(selected.Index);
				UpdateTotalCount();
			}
		}

		private void BtnClearClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete all subjects with saved names?", "Confirm clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				LicensePlates.Clear();
				listViewPlates.Items.Clear();
				UpdateTotalCount();
			}
		}

		private void ListViewPlatesSelectedIndexChanged(object sender, EventArgs e)
		{
			btnDelete.Enabled = listViewPlates.SelectedItems.Count > 0;
		}

		private void ListViewPlatesMouseDoubleClick(object sender, MouseEventArgs e)
		{
			var item = listViewPlates.HitTest(e.X, e.Y)?.Item;
			if (item != null)
			{
				var value = (string)item.Tag;
				var record = LicensePlates[value];
				if (record != null)
				{
					using (var dialog = new ChangeLicensePlateRecordForm())
					{
						dialog.LicensePlates = LicensePlates;
						dialog.Record = record;
						if (dialog.ShowDialog() == DialogResult.OK)
						{
							_searchTerm = string.Empty;
							tbOwner.Text = string.Empty;
							tbSearchAndAdd.Text = string.Empty;
							ShowList();
						}
					}
				}
			}
		}

		#endregion
	}
}
