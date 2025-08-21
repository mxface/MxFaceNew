using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms
{
	public partial class PriorityCountriesForm : Form
	{
		#region Private fields

		private Dictionary<string, string> _notSelectedCodes = new Dictionary<string, string>();

		#endregion

		#region Public constructor

		public PriorityCountriesForm()
		{
			InitializeComponent();
		}

		#endregion Public constructor

		#region Public properties

		public string PriorityCountries { get; set; }

		#endregion Public properties

		#region Private properties

		private Dictionary<string, string> countryCodeMap = new Dictionary<string, string>();

		#endregion Private properties

		#region Private methods

		private void FilterCountryList(string filter)
		{
			listBoxSupported.BeginUpdate();
			listBoxSupported.Items.Clear();

			var filtered = string.IsNullOrWhiteSpace(filter) ? _notSelectedCodes :
				_notSelectedCodes.Where(x => x.Key.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 || x.Value.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1);

			foreach (var entry in filtered)
			{
				listBoxSupported.Items.Add(AddCountryName(entry.Key));
			}

			listBoxSupported.EndUpdate();
		}

		private void LoadCountryList()
		{
			listBoxSupported.Items.Clear();

			foreach (var entry in countryCodeMap)
			{
				listBoxSupported.Items.Add(AddCountryName(entry.Key));
				_notSelectedCodes[entry.Key] = entry.Value;
			}

			var countryCodeList = PriorityCountries.Split(' ');
			foreach (var countryCode in countryCodeList)
			{
				if (countryCode.Length > 1)
				{
					listBoxSelected.Items.Add(AddCountryName(countryCode));
					listBoxSupported.Items.Remove(AddCountryName(countryCode));
					_notSelectedCodes.Remove(countryCode);
				}
			}
		}

		private string AddCountryName(string countryCode)
		{
			string trimmed = countryCode.Trim();
			if (countryCodeMap.ContainsKey(trimmed))
			{
				return trimmed + " - " + countryCodeMap[trimmed];
			}
			return trimmed;
		}

		private string RemoveCountryName(string input)
		{
			int index = input.IndexOf("-");
			if (index > 0)
			{
				input = input.Substring(0, index);
			}

			return input.Trim();
		}

		private KeyValuePair<string, string> ParseCountryCode(string combined)
		{
			var split = combined.Split(new string[] { "-" }, StringSplitOptions.None);
			return new KeyValuePair<string, string>(split[0].Trim(), split[1].Trim());
		}

		private List<string> MoveToList(ListBox from, ListBox to)
		{
			var lastSelected = from.SelectedIndex;
			var moved = new List<string>();
			while (from.SelectedItems.Count > 0)
			{
				var selected = from.SelectedItems[0];
				to.Items.Add(selected);
				lastSelected = from.SelectedIndex;
				from.Items.Remove(selected);
				moved.Add(selected.ToString());
			}

			if (lastSelected != -1 && from.Items.Count > 0)
			{
				if (lastSelected >= from.Items.Count)
				{
					from.SetSelected(lastSelected - 1, true);
				}
				else
				{
					from.SetSelected(lastSelected, true);
				}
			}

			return moved;
		}

		#endregion Private methods

		#region Private events

		private void PriorityCountriesFormShown(object sender, EventArgs e)
		{
			countryCodeMap = NSurveillance.GetSupportedPriorityCountryCodes()
				.ToDictionary(x => x.Key, x => x.Value);

			LoadCountryList();
		}

		private void ButtonAddClick(object sender, EventArgs e)
		{
			var moved = MoveToList(listBoxSupported, listBoxSelected)
				.Select(ParseCountryCode);
			foreach (var pair in moved)
			{
				_notSelectedCodes.Remove(pair.Key);
			}
		}

		private void ButtonRemoveClick(object sender, EventArgs e)
		{
			var moved = MoveToList(listBoxSelected, listBoxSupported)
				.Select(ParseCountryCode);
			foreach (var pair in moved)
			{
				_notSelectedCodes[pair.Key] = pair.Value;
			}
			FilterCountryList(tbSearch.Text);
		}

		private void ButtonUpClick(object sender, EventArgs e)
		{
			int selectedIndex = listBoxSelected.SelectedIndex;
			if (selectedIndex > 0)
			{
				listBoxSelected.Items.Insert(selectedIndex - 1, listBoxSelected.Items[selectedIndex]);
				listBoxSelected.Items.RemoveAt(selectedIndex + 1);
				listBoxSelected.SelectedIndex = selectedIndex - 1;
			}
		}

		private void ButtonDownClick(object sender, EventArgs e)
		{
			int selectedIndex = listBoxSelected.SelectedIndex;
			if (selectedIndex < listBoxSelected.Items.Count - 1 & selectedIndex != -1)
			{
				listBoxSelected.Items.Insert(selectedIndex + 2, listBoxSelected.Items[selectedIndex]);
				listBoxSelected.Items.RemoveAt(selectedIndex);
				listBoxSelected.SelectedIndex = selectedIndex + 1;
			}
		}

		private void ListBoxSupportedSelectedValueChanged(object sender, EventArgs e)
		{
			buttonAdd.Enabled = listBoxSupported.SelectedIndex != -1;
		}

		private void ListBoxSelectedSelectedValueChanged(object sender, EventArgs e)
		{
			buttonRemove.Enabled = listBoxSelected.SelectedIndex != -1;
			buttonUp.Enabled = listBoxSelected.SelectedItems.Count == 1;
			if (listBoxSelected.SelectedIndex <= 0)
			{
				buttonUp.Enabled = false;
			}
			buttonDown.Enabled = listBoxSelected.SelectedItems.Count == 1;
			if (listBoxSelected.SelectedIndex == listBoxSelected.Items.Count - 1)
			{
				buttonDown.Enabled = false;
			}
		}

		private void ButtonOKClick(object sender, EventArgs e)
		{
			PriorityCountries = "";
			foreach (var item in listBoxSelected.Items)
			{
				PriorityCountries += RemoveCountryName(item.ToString()) + " ";
			}

			if (listBoxSelected.Items.Count > 0)
			{
				PriorityCountries = PriorityCountries.Remove(PriorityCountries.Length - 1);
			}
		}

		private void TbSearchTextChanged(object sender, EventArgs e)
		{
			FilterCountryList(tbSearch.Text);
		}

		private void ListBoxSupportedDoubleClick(object sender, EventArgs e)
		{
			MoveToList(listBoxSupported, listBoxSelected);
		}

		private void ListBoxSelectedDoubleClick(object sender, EventArgs e)
		{
			MoveToList(listBoxSelected, listBoxSupported);
		}

		#endregion

		#region Protected methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
				return true;
			}
			else if (keyData == (Keys.F | Keys.Control))
			{
				tbSearch.Focus();
				tbSearch.SelectAll();
				return true;
			}
			else if (keyData == Keys.Enter && tbSearch.Focused)
			{
				listBoxSupported.Select();
				listBoxSupported.Focus();
				listBoxSupported.SelectedItem = listBoxSupported.Items.OfType<object>().FirstOrDefault();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion
	}
}
