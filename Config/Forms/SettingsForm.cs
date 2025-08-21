using Neurotec.Biometrics;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neurotec.Samples.Config.Forms
{
	public partial class SettingsForm : Form
	{
		#region Public constructor

		public SettingsForm()
		{
			InitializeComponent();

			cbScaling.Items.Add(NDetectorScaleCount.One);
			cbScaling.Items.Add(NDetectorScaleCount.Two);
			cbScaling.Items.Add(NDetectorScaleCount.Three);
			cbScaling.Items.Add(NDetectorScaleCount.Four);

			cbPlatesScaling.Items.Add(NDetectorScaleCount.One);
			cbPlatesScaling.Items.Add(NDetectorScaleCount.Two);
			cbPlatesScaling.Items.Add(NDetectorScaleCount.Three);
			cbPlatesScaling.Items.Add(NDetectorScaleCount.Four);

			cbTemplateSize.Items.Add(NTemplateSize.Small);
			cbTemplateSize.Items.Add(NTemplateSize.Medium);
			cbTemplateSize.Items.Add(NTemplateSize.Large);
			cbTemplateSize.SelectedIndex = 1;
		}

		#endregion

		#region Public properties

		public NSurveillance Surveillance { get; set; }

		#endregion

		#region Private fields

		private Dictionary<string, Preset> _presets;

		NPropertyBag _pbDefaultPreset;

		private Preset _selectedPreset = null;

		#endregion Private fields

		#region Data exchange

		public void LoadSettings()
		{
			_pbDefaultPreset = Preset.GetPropertyBagFrom(Surveillance);
			_presets = SurveillanceConfig.Presets;
			_selectedPreset = null;
			LoadGeneralSettings(Surveillance);
			LoadPresetSettings(Surveillance);
			UpdatePresetList();
		}

		public void SaveSettings()
		{
			SaveSelectedPreset();

			SurveillanceConfig.MiscMaxTreeNodeCount = Convert.ToInt32(nudMaxNodeCount.Value);
			SurveillanceConfig.RetryFrequency = Convert.ToInt32(nudRetryFreq.Value);
			SurveillanceConfig.SaveEvents = chbSaveEvents.Checked;
			SurveillanceConfig.Presets = _presets;

			_pbDefaultPreset.ApplyTo(Surveillance);
			Surveillance.UseGPU = chbUseGpu.Checked;
			Surveillance.EnableGpuLowMemoryMode = chbLowMemory.Checked;
			Surveillance.MatchingThreshold = Convert.ToInt32(nudMatchingThreshold.Value);

			var pb = new NPropertyBag();
			Surveillance.CaptureProperties(pb);
			SurveillanceConfig.SurveillanceProperties = pb.ToString();
			SurveillanceConfig.Save();
		}

		#endregion Data exchange

		#region Private methods

		private void UpdatePresetList()
		{
			if (_presets == null)
			{
				_presets = new Dictionary<string, Preset>();
			}

			cbPreset.Items.Clear();
			cbPreset.Items.Add("Default");
			foreach (var item in _presets)
			{
				cbPreset.Items.Add(item.Value);
			}

			if(_selectedPreset == null)
			{
				cbPreset.SelectedIndex = 0;
			}
			else
			{
				cbPreset.SelectedItem = _selectedPreset;
			}
		}

		private void LoadGeneralSettings(NSurveillance target)
		{
			nudMaxNodeCount.Value = SurveillanceConfig.MiscMaxTreeNodeCount;
			nudRetryFreq.Value = SurveillanceConfig.RetryFrequency;
			chbSaveEvents.Checked = SurveillanceConfig.SaveEvents;
			chbUseGpu.Checked = target.UseGPU;
			chbLowMemory.Checked = target.EnableGpuLowMemoryMode;
			nudMatchingThreshold.Value = target.MatchingThreshold;
		}

		private void LoadPresetSettings(NSurveillance target)
		{
			cbScaling.SelectedItem = target.DetectorScaling;

			nudVhThreshold.Value = target.VehicleHumanDetectorThreshold;
			chbDetectClothingDetails.Checked = target.DetectClothingDetails;
			chbDetectVehicleDetails.Checked = target.DetectVehicleDetails;
			chbEstimageAgeGroup.Checked = target.EstimateAgeGroup;

			cbPlatesScaling.SelectedItem = target.LicensePlateDetectorScaling;
			nudPlatesThreshold.Value = target.LicensePlateDetectorThreshold;
			chbInterpretOasZero.Checked = target.LicensePlateInterpretOAsZero;
			nudMinCharCount.Value = target.LicensePlateMinimalCharacterCount;
			nudOcrThreshold.Value = target.LicensePlateOcrThreshold;
			chbLPTemplateMatching.Checked = target.LicensePlateEnableTemplateMatching;
			btnEditPriorityCountries.Enabled = chbLPTemplateMatching.Checked;
			tbPriorityCountries.Enabled = chbLPTemplateMatching.Checked;
			tbPriorityCountries.Text = target.LicensePlatePriorityCountries;
			chbLatinCharactersOnly.Checked = target.LicensePlateLatinOnly;

			chbDetectMasks.Checked = target.FacesDetectMasks;
			cbTemplateSize.SelectedItem = target.FacesTemplateSize;
			nudFacesMinInterOcularDistance.Value = target.FacesMinimalInterOcularDistance;
			nudConfThreshold.Value = target.FacesConfidenceThreshold;
			nudQuality.Value = target.FacesQualityThreshold;
		}

		private void SavePresetSetting(NSurveillance target)
		{
			target.DetectorScaling = (NDetectorScaleCount)cbScaling.SelectedItem;

			target.VehicleHumanDetectorThreshold = Convert.ToInt32(nudVhThreshold.Value);
			target.DetectClothingDetails = chbDetectClothingDetails.Checked;
			target.DetectVehicleDetails = chbDetectVehicleDetails.Checked;
			target.EstimateAgeGroup = chbEstimageAgeGroup.Checked;

			target.LicensePlateDetectorScaling = (NDetectorScaleCount)cbPlatesScaling.SelectedItem;
			target.LicensePlateDetectorThreshold = Convert.ToInt32(nudPlatesThreshold.Value);
			target.LicensePlateInterpretOAsZero = chbInterpretOasZero.Checked;
			target.LicensePlateMinimalCharacterCount = Convert.ToInt32(nudMinCharCount.Value);
			target.LicensePlateOcrThreshold = Convert.ToInt32(nudOcrThreshold.Value);
			target.LicensePlateEnableTemplateMatching = chbLPTemplateMatching.Checked;
			target.LicensePlatePriorityCountries = tbPriorityCountries.Text;
			target.LicensePlateLatinOnly = chbLatinCharactersOnly.Checked;

			target.FacesDetectMasks = chbDetectMasks.Checked;
			target.FacesTemplateSize = (NTemplateSize)cbTemplateSize.SelectedItem;
			target.FacesMinimalInterOcularDistance = Convert.ToInt32(nudFacesMinInterOcularDistance.Value);
			target.FacesConfidenceThreshold = Convert.ToByte(nudConfThreshold.Value);
			target.FacesQualityThreshold = Convert.ToByte(nudQuality.Value);
		}

		private void LoadSelectedPreset()
		{
			using (var target = new NSurveillance())
			{
				if (_selectedPreset != null)
				{
					NPropertyBag pbPreset = _selectedPreset.GetPropertyBag();
					if(pbPreset != null)
					{
						pbPreset.ApplyTo(target);
						LoadPresetSettings(target);
					}
				}
				else
				{
					_pbDefaultPreset.ApplyTo(target);
					LoadPresetSettings(target);
				}
			}
		}

		private void SaveSelectedPreset()
		{
			using (var target = new NSurveillance())
			{
				SavePresetSetting(target);
				NPropertyBag pb = Preset.GetPropertyBagFrom(target);

				if (_selectedPreset != null)
				{
					_selectedPreset.PropertiesString = pb.ToString();
				}
				else
				{
					_pbDefaultPreset = pb;
				}
			}
		}

		#endregion  Private methods

		#region Private events

		private void SettingsFormShown(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void BtnDefaultClick(object sender, EventArgs e)
		{
			using (var target = new NSurveillance())
			{
				target.UseGPU = true;
				if (_selectedPreset == null)
				{
					SurveillanceConfig.ResetGeneralSettings();
					LoadGeneralSettings(target);
				}
				LoadPresetSettings(target);
			}
		}

		private void BtnEditPriorityCountriesClick(object sender, EventArgs e)
		{
			using (var dialog = new PriorityCountriesForm() { PriorityCountries = tbPriorityCountries.Text })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					tbPriorityCountries.Text = dialog.PriorityCountries;
				}
			}
		}

		private void ChbLPTemplateMatchingCheckStateChanged(object sender, EventArgs e)
		{
			btnEditPriorityCountries.Enabled = chbLPTemplateMatching.Checked;
			tbPriorityCountries.Enabled = chbLPTemplateMatching.Checked;
			lblPriorityCountries.Enabled = chbLPTemplateMatching.Checked;
		}

		private void BtnEditPresetClick(object sender, EventArgs e)
		{
			using (var dialog = new PresetsForm() { Presets = new Dictionary<string, Preset>(_presets) })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_presets = dialog.Presets;
					_selectedPreset = null;
					UpdatePresetList();
				}
			}
		}

		private void CmbPresetSelectedIndexChanged(object sender, EventArgs e)
		{
			SaveSelectedPreset();
			_selectedPreset = cbPreset.SelectedIndex == 0 ? null : (Preset)cbPreset.SelectedItem;
			LoadSelectedPreset();
		}

		#endregion Private events

		private void SettingsFormClosed(object sender, FormClosedEventArgs e)
		{
			SurveillanceConfig.Reload();
		}
	}
}
