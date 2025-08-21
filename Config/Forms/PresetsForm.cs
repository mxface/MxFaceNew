using Neurotec.Samples.Config;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms
{
	public partial class PresetsForm : Form
	{
		#region Private fields

		private bool _presetEditMode = false;

		#endregion Private fields

		#region Public constructor
		public PresetsForm()
		{
			InitializeComponent();
		}

		#endregion Public constructor

		#region Public properties

		public Dictionary<string, Preset> Presets { get; set; }

		#endregion Public properties

		#region Private methods
	
		private int GetPresetCount(String name)
		{
			int count = 0;
			foreach (var item in Presets)
			{
				if (name.Equals(item.Value.ToString()))
				{
					count++;
				}
			}

			return count;
		}

		private void UpdateControls()
		{
			tbEditItem.Visible = _presetEditMode;
			btnRename.Enabled = lbPresets.SelectedIndex >= 0 && !_presetEditMode;
			btnRemove.Enabled = lbPresets.SelectedIndex >= 0 && !_presetEditMode;
			btnAdd.Enabled = tbName.Text.Length > 0 && GetPresetCount(tbName.Text) == 0;
		}

		private void UpdatePresetList()
		{
			lbPresets.Items.Clear();
			foreach (var item in Presets)
			{
				lbPresets.Items.Add(item.Value);
			}

			tbName.Text = "";
			lbPresets.SelectedIndex = -1;
			UpdateControls();
		}

		private void StartPresetEdit(int itemIndex)
		{
			Rectangle r = lbPresets.GetItemRectangle(itemIndex);
			tbEditItem.Location = new System.Drawing.Point(r.X, r.Y);
			tbEditItem.Size = new System.Drawing.Size(r.Width, r.Height);
			lbPresets.Controls.AddRange(new System.Windows.Forms.Control[] { this.tbEditItem });
			tbEditItem.Text = lbPresets.SelectedItem.ToString();
			tbEditItem.Show();
			tbEditItem.Focus();
			tbEditItem.SelectAll();
			tbEditItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbEditItemKeyDown);
			tbEditItem.LostFocus += new System.EventHandler(this.TbEditItemEditOver);
			_presetEditMode = true;
			UpdateControls();
		}

		private void FinalizePresetEdit()
		{
			if (lbPresets.SelectedIndex >= 0)
			{
				Preset selected = (Preset) lbPresets.SelectedItem;
				if (selected.Name.Equals(tbEditItem.Text))
				{
					_presetEditMode = false;
					UpdatePresetList();
				}
				else
				{
					if (GetPresetCount(tbEditItem.Text) == 0)
					{
						selected.Name = tbEditItem.Text;
						_presetEditMode = false;
						UpdatePresetList();
					}
					else
					{
						tbEditItem.Focus();
					}
				}
			}
		}

		#endregion Private methods

		#region Private events

		private void PresetsFormShown(object sender, EventArgs e)
		{
			if (Presets == null)
			{
				Presets = new Dictionary<string, Preset>();
			}
			UpdatePresetList();
		}

		private void LbPresetsSelectedValueChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void TbNameTextChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void BtnAddClick(object sender, EventArgs e)
		{
			Preset newPreset = new Preset(tbName.Text);
			Presets[newPreset.PresetGUID] = newPreset;
			UpdatePresetList();
		}

		private void BtnRemoveClick(object sender, EventArgs e)
		{
			Preset selected = (Preset)lbPresets.SelectedItem;
			Presets.Remove(selected.PresetGUID);
			UpdatePresetList();
		}

		private void BtnRenameClick(object sender, EventArgs e)
		{
			StartPresetEdit(lbPresets.SelectedIndex);
		}

		private void LbPresetsDoubleClick(object sender, EventArgs e)
		{
			if (lbPresets.SelectedIndex >= 0)
			{
				StartPresetEdit(lbPresets.SelectedIndex);
			}
		}

		private void TbEditItemEditOver(object sender, EventArgs e)
		{
			FinalizePresetEdit();
		}

		private void TbEditItemKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				FinalizePresetEdit();
			}
		}

		#endregion Private events
	}
}
