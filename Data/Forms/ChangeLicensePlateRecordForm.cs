using System;
using System.Windows.Forms;

namespace Neurotec.Samples.Data.Forms
{
	public partial class ChangeLicensePlateRecordForm : Form
	{
		#region Public constructor

		public ChangeLicensePlateRecordForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public LicensePlateCollection LicensePlates { get; set; }
		public LicensePlateRecord Record { get; set; }

		#endregion

		#region Private methods

		private void BtnOkClick(object sender, EventArgs e)
		{
			var value = CleanLicensePlate();
			if (string.IsNullOrWhiteSpace(value))
			{
				System.Media.SystemSounds.Beep.Play();
				return;
			}
			if (value != Record.Value && LicensePlates.Contains(value))
			{
				MessageBox.Show("This license plate already exists!", "Duplicate Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			LicensePlates.Delete(Record.Value);
			LicensePlates.Add(value, tbOwner.Text);

			DialogResult = DialogResult.OK;
		}

		private string CleanLicensePlate()
		{
			return tbValue.Text?.Trim().ToUpperInvariant() ?? string.Empty;
		}

		private void ChangeLicensePlateRecordFormShown(object sender, EventArgs e)
		{
			if (LicensePlates == null) throw new ArgumentException(nameof(LicensePlates));

			tbOwner.Text = Record.Owner;
			tbValue.Text = Record.Value;
			tbValue.Focus();
		}

		#endregion

		#region Protected methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				if (tbValue.Focused)
				{
					tbOwner.Focus();
					return true;
				}
				else if (tbOwner.Focused)
				{
					btnOk.PerformClick();
					return true;
				}
			}
			else if (keyData == Keys.Escape)
			{
				Close();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion
	}
}
