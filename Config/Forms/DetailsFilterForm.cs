using System;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms
{
	public partial class DetailsFilterForm : Form
	{
		#region Public constructor

		public DetailsFilterForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public DetailsFilter Filter { get; set; } = new DetailsFilter();

		#endregion

		#region Private methods

		private void DetailsFilterShown(object sender, EventArgs e)
		{
			chbFaceAttributes.Checked = Filter.ShowFaceAttributes;
			chbFaceQuality.Checked = Filter.ShowFaceQuality;
			chbLPOrigin.Checked = Filter.ShowLPOrigin;
			chbModels.Checked = Filter.ShowVehicleModel;
			chbObjectColor.Checked = Filter.ShowObjectColor;
			chbObjectDirection.Checked = Filter.ShowObjectDirection;
			chbObjectType.Checked = Filter.ShowObjectType;
			chbTags.Checked = Filter.ShowTags;
			chbAgeGroup.Checked = Filter.ShowAgeGroups;
			rbValue.Checked = Filter.ShowLPFormattedValue == false;
			rbFormattedValue.Checked = Filter.ShowLPFormattedValue;
			chbShowEvents.Checked = Filter.ShowAnalyticEvent;
			chbShowEventBorder.Checked = Filter.ShowAnalyticEventBorder;
		}

		private void SaveSettings()
		{
			Filter.ShowFaceAttributes = chbFaceAttributes.Checked;
			Filter.ShowFaceQuality = chbFaceQuality.Checked;
			Filter.ShowLPOrigin = chbLPOrigin.Checked;
			Filter.ShowVehicleModel = chbModels.Checked;
			Filter.ShowObjectColor = chbObjectColor.Checked;
			Filter.ShowObjectDirection = chbObjectDirection.Checked;
			Filter.ShowObjectType = chbObjectType.Checked;
			Filter.ShowTags = chbTags.Checked;
			Filter.ShowAgeGroups = chbAgeGroup.Checked;
			Filter.ShowLPFormattedValue = rbFormattedValue.Checked;
			Filter.ShowAnalyticEvent = chbShowEvents.Checked;
			Filter.ShowAnalyticEventBorder = chbShowEventBorder.Checked;
		}

		private void BtnSaveClick(object sender, EventArgs e)
		{
			SaveSettings();
		}

		#endregion
	}
}
