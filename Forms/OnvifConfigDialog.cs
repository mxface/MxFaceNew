using Neurotec.Devices;
using System;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class OnvifConfigDialog : Form
	{
		#region Public constructor

		public OnvifConfigDialog()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public NCamera Camera { get; set; }

		#endregion

		#region Private methods

		private void BtnOkClick(object sender, EventArgs e)
		{
			ApplyValues();
		}

		private void OnvifConfigDialogLoad(object sender, EventArgs e)
		{
			try
			{
				tbUser.Text = Camera.GetProperty<string>("OnvifUsername");
				mtbPassword.Text = Camera.GetProperty<string>("OnvifPassword");
				tbStreamUser.Text = Camera.GetProperty<string>("StreamUsername");
				mtbStreamPassword.Text = Camera.GetProperty<string>("StreamPassword");
			}
			catch (Exception ex)
			{
				Utils.ShowException(ex);
			}
		}

		private void ApplyValues()
		{
			try
			{
				Camera.SetProperty("OnvifUsername", tbUser.Text);
				Camera.SetProperty("OnvifPassword", mtbPassword.Text);
				Camera.SetProperty("StreamUsername", tbStreamUser.Text);
				Camera.SetProperty("StreamPassword", mtbStreamPassword.Text);
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Utils.ShowException(ex);
			}
		}

		private void TextBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ApplyValues();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
			}
		}

		#endregion
	}
}
