using Neurotec.Surveillance;
using System;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class OptimizationDialog : Form
	{
		#region Public constructor

		public OptimizationDialog()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public NSurveillanceModalityType Modalities { get; set; } = NSurveillanceModalityType.Faces | NSurveillanceModalityType.VehiclesAndHumans | NSurveillanceModalityType.LicensePlateRecognition;
		public NSurveillance Surveillance { get; set; }

		#endregion

		#region Private methods

		private NSurveillanceModalityType GetModalities()
		{
			NSurveillanceModalityType type = NSurveillanceModalityType.None;
			if (chbFaces.Checked)
				type |= NSurveillanceModalityType.Faces;
			if (chbVh.Checked)
				type |= NSurveillanceModalityType.VehiclesAndHumans;
			if (chbLpr.Checked)
				type |= NSurveillanceModalityType.LicensePlateRecognition;

			return type;
		}

		private void OnModalityCheckChanged(bool check, NSurveillanceModalityType modality)
		{
			var value = GetModalities();
			if (check)
				value |= modality;
			else
				value &= ~modality;

			if (value == NSurveillanceModalityType.None)
			{
				bool Check(NSurveillanceModalityType t, CheckBox chb)
				{
					if (modality != t)
					{
						chb.Checked = true;
						value |= t;
						return true;
					}
					return false;
				}

				if (!Check(NSurveillanceModalityType.Faces, chbFaces))
				{
					if (!Check(NSurveillanceModalityType.VehiclesAndHumans, chbVh))
						Check(NSurveillanceModalityType.LicensePlateRecognition, chbLpr);
				}
			}
		}

		private void OptimizationDialogLoad(object sender, EventArgs e)
		{
			chbFaces.Checked = (NSurveillanceModalityType.Faces & Modalities) == NSurveillanceModalityType.Faces;
			chbVh.Checked = (NSurveillanceModalityType.VehiclesAndHumans & Modalities) == NSurveillanceModalityType.VehiclesAndHumans;
			chbLpr.Checked = (NSurveillanceModalityType.LicensePlateRecognition & Modalities) == NSurveillanceModalityType.LicensePlateRecognition;
			pbProgress.Visible = false;
			lblProgress.Visible = false;
		}

		private void ChbFacesCheckedChanged(object sender, EventArgs e)
		{
			OnModalityCheckChanged(chbFaces.Checked, NSurveillanceModalityType.Faces);
		}

		private void ChbVhCheckedChanged(object sender, EventArgs e)
		{
			OnModalityCheckChanged(chbVh.Checked, NSurveillanceModalityType.VehiclesAndHumans);
		}

		private void ChbLprCheckedChanged(object sender, EventArgs e)
		{
			OnModalityCheckChanged(chbLpr.Checked, NSurveillanceModalityType.LicensePlateRecognition);
		}

		private void EnableControls(bool enable)
		{
			tableLayoutPanel1.Enabled = enable;
		}

		private void OnProgressChanged(object sender, NSurveillanceProgressEventArgs args)
		{
			if (InvokeRequired)
			{
				this.BeginInvoke(new NSurveillanceProgressCallback(OnProgressChanged), sender, args);
			}
			else if (IsHandleCreated)
			{
				lblProgress.Visible = true;
				lblProgress.Text = $"Optimization in progress: {args.Value}/{args.Maximum}";
				pbProgress.Maximum = args.Maximum;
				pbProgress.Value = args.Value;
			}
		}

		private async void BtnOptimizeClick(object sender, EventArgs e)
		{
			try
			{
				EnableControls(false);

				pbProgress.Visible = true;
				lblProgress.Visible = true;
				if (rbAll.Checked)
				{
					await NSurveillance.OptimizeModelsAsync(GetModalities(), chbLowMemory.Checked, progressCallback: OnProgressChanged);
				}
				else
				{
					await Surveillance.OptimizeModelsAsync(GetModalities(), progressCallback: OnProgressChanged);
				}
				EnableControls(true);
				Modalities = GetModalities();
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				EnableControls(true);
				pbProgress.Visible = false;
				lblProgress.Visible = false;
				Utils.ShowException(ex);
			}
		}

		private void OptimizationDialogFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!tableLayoutPanel1.Enabled)
			{
				e.Cancel = true;
			}
		}

		private void RbCheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				chbLowMemory.Enabled = radioButton == rbAll;
			}
		}

		#endregion
	}
}
