
namespace Neurotec.Samples.Config.Forms
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.btnDefault = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.cbPreset = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.gbSample = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label14 = new System.Windows.Forms.Label();
			this.nudMaxNodeCount = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nudRetryFreq = new System.Windows.Forms.NumericUpDown();
			this.chbUseGpu = new System.Windows.Forms.CheckBox();
			this.chbSaveEvents = new System.Windows.Forms.CheckBox();
			this.chbLowMemory = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.nudMatchingThreshold = new System.Windows.Forms.NumericUpDown();
			this.gbPreset = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.gbFaces = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.label9 = new System.Windows.Forms.Label();
			this.cbTemplateSize = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.nudFacesMinInterOcularDistance = new System.Windows.Forms.NumericUpDown();
			this.chbDetectMasks = new System.Windows.Forms.CheckBox();
			this.label17 = new System.Windows.Forms.Label();
			this.nudConfThreshold = new System.Windows.Forms.NumericUpDown();
			this.nudQuality = new System.Windows.Forms.NumericUpDown();
			this.label18 = new System.Windows.Forms.Label();
			this.gbPlates = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cbPlatesScaling = new System.Windows.Forms.ComboBox();
			this.nudPlatesThreshold = new System.Windows.Forms.NumericUpDown();
			this.nudOcrThreshold = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.chbInterpretOasZero = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.nudMinCharCount = new System.Windows.Forms.NumericUpDown();
			this.chbLPTemplateMatching = new System.Windows.Forms.CheckBox();
			this.lblPriorityCountries = new System.Windows.Forms.Label();
			this.btnEditPriorityCountries = new System.Windows.Forms.Button();
			this.tbPriorityCountries = new System.Windows.Forms.TextBox();
			this.chbLatinCharactersOnly = new System.Windows.Forms.CheckBox();
			this.gbVh = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.nudVhThreshold = new System.Windows.Forms.NumericUpDown();
			this.chbDetectClothingDetails = new System.Windows.Forms.CheckBox();
			this.chbDetectVehicleDetails = new System.Windows.Forms.CheckBox();
			this.chbEstimageAgeGroup = new System.Windows.Forms.CheckBox();
			this.gbCommon = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.cbScaling = new System.Windows.Forms.ComboBox();
			this.btnEditPreset = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.gbSample.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxNodeCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRetryFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMatchingThreshold)).BeginInit();
			this.gbPreset.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.gbFaces.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudFacesMinInterOcularDistance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudConfThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudQuality)).BeginInit();
			this.gbPlates.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPlatesThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudOcrThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinCharCount)).BeginInit();
			this.gbVh.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudVhThreshold)).BeginInit();
			this.gbCommon.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnDefault
			// 
			this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDefault.Location = new System.Drawing.Point(6, 821);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(75, 23);
			this.btnDefault.TabIndex = 101;
			this.btnDefault.Text = "&Default";
			this.btnDefault.UseVisualStyleBackColor = true;
			this.btnDefault.Click += new System.EventHandler(this.BtnDefaultClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(359, 821);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 102;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// cbPreset
			// 
			this.cbPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPreset.FormattingEnabled = true;
			this.cbPreset.Location = new System.Drawing.Point(3, 4);
			this.cbPreset.Name = "cbPreset";
			this.cbPreset.Size = new System.Drawing.Size(343, 21);
			this.cbPreset.TabIndex = 112;
			this.toolTip.SetToolTip(this.cbPreset, "Presets allows to maintain multiple configurations for different scenarios.\r\nPres" +
        "et can changed for each source separately (click gear icon next to source).");
			this.cbPreset.SelectedIndexChanged += new System.EventHandler(this.CmbPresetSelectedIndexChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.gbSample, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.gbPreset, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnDefault, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 850);
			this.tableLayoutPanel1.TabIndex = 62;
			// 
			// gbSample
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.gbSample, 3);
			this.gbSample.Controls.Add(this.tableLayoutPanel4);
			this.gbSample.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbSample.Location = new System.Drawing.Point(6, 6);
			this.gbSample.Name = "gbSample";
			this.gbSample.Size = new System.Drawing.Size(428, 169);
			this.gbSample.TabIndex = 109;
			this.gbSample.TabStop = false;
			this.gbSample.Text = "General";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.label14, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.nudMaxNodeCount, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.nudRetryFreq, 1, 1);
			this.tableLayoutPanel4.Controls.Add(this.chbUseGpu, 1, 3);
			this.tableLayoutPanel4.Controls.Add(this.chbSaveEvents, 1, 2);
			this.tableLayoutPanel4.Controls.Add(this.chbLowMemory, 1, 4);
			this.tableLayoutPanel4.Controls.Add(this.label11, 0, 5);
			this.tableLayoutPanel4.Controls.Add(this.nudMatchingThreshold, 1, 5);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 7;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(422, 150);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// label14
			// 
			this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 6);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(126, 13);
			this.label14.TabIndex = 66;
			this.label14.Text = "Max Subject Node Count";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nudMaxNodeCount
			// 
			this.nudMaxNodeCount.Location = new System.Drawing.Point(135, 3);
			this.nudMaxNodeCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nudMaxNodeCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudMaxNodeCount.Name = "nudMaxNodeCount";
			this.nudMaxNodeCount.Size = new System.Drawing.Size(59, 20);
			this.nudMaxNodeCount.TabIndex = 67;
			this.nudMaxNodeCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 13);
			this.label4.TabIndex = 105;
			this.label4.Text = "Camera Retry Frequency";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudRetryFreq
			// 
			this.nudRetryFreq.Location = new System.Drawing.Point(135, 29);
			this.nudRetryFreq.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nudRetryFreq.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudRetryFreq.Name = "nudRetryFreq";
			this.nudRetryFreq.Size = new System.Drawing.Size(59, 20);
			this.nudRetryFreq.TabIndex = 106;
			this.nudRetryFreq.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// chbUseGpu
			// 
			this.chbUseGpu.AutoSize = true;
			this.chbUseGpu.Checked = true;
			this.chbUseGpu.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbUseGpu.Location = new System.Drawing.Point(135, 78);
			this.chbUseGpu.Name = "chbUseGpu";
			this.chbUseGpu.Size = new System.Drawing.Size(71, 17);
			this.chbUseGpu.TabIndex = 7;
			this.chbUseGpu.Text = "Use GPU";
			this.chbUseGpu.UseVisualStyleBackColor = true;
			// 
			// chbSaveEvents
			// 
			this.chbSaveEvents.AutoSize = true;
			this.chbSaveEvents.Checked = true;
			this.chbSaveEvents.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbSaveEvents.Location = new System.Drawing.Point(135, 55);
			this.chbSaveEvents.Name = "chbSaveEvents";
			this.chbSaveEvents.Size = new System.Drawing.Size(117, 17);
			this.chbSaveEvents.TabIndex = 107;
			this.chbSaveEvents.Text = "Save Events to DB";
			this.chbSaveEvents.UseVisualStyleBackColor = true;
			// 
			// chbLowMemory
			// 
			this.chbLowMemory.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chbLowMemory.AutoSize = true;
			this.chbLowMemory.Location = new System.Drawing.Point(135, 101);
			this.chbLowMemory.Name = "chbLowMemory";
			this.chbLowMemory.Size = new System.Drawing.Size(111, 17);
			this.chbLowMemory.TabIndex = 115;
			this.chbLowMemory.Text = "Low GPU memory";
			this.chbLowMemory.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Location = new System.Drawing.Point(3, 121);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(126, 26);
			this.label11.TabIndex = 42;
			this.label11.Text = "Matching Threshold";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nudMatchingThreshold
			// 
			this.nudMatchingThreshold.Increment = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.nudMatchingThreshold.Location = new System.Drawing.Point(135, 124);
			this.nudMatchingThreshold.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
			this.nudMatchingThreshold.Name = "nudMatchingThreshold";
			this.nudMatchingThreshold.Size = new System.Drawing.Size(72, 20);
			this.nudMatchingThreshold.TabIndex = 43;
			this.nudMatchingThreshold.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
			// 
			// gbPreset
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.gbPreset, 3);
			this.gbPreset.Controls.Add(this.tableLayoutPanel7);
			this.gbPreset.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbPreset.Location = new System.Drawing.Point(6, 181);
			this.gbPreset.Name = "gbPreset";
			this.gbPreset.Size = new System.Drawing.Size(428, 634);
			this.gbPreset.TabIndex = 111;
			this.gbPreset.TabStop = false;
			this.gbPreset.Text = "Preset";
			this.toolTip.SetToolTip(this.gbPreset, "Presets allows to maintain multiple configurations for different scenarios.");
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.Controls.Add(this.gbFaces, 0, 4);
			this.tableLayoutPanel7.Controls.Add(this.gbPlates, 0, 3);
			this.tableLayoutPanel7.Controls.Add(this.gbVh, 0, 2);
			this.tableLayoutPanel7.Controls.Add(this.gbCommon, 0, 1);
			this.tableLayoutPanel7.Controls.Add(this.btnEditPreset, 1, 0);
			this.tableLayoutPanel7.Controls.Add(this.cbPreset, 0, 0);
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 5;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(422, 615);
			this.tableLayoutPanel7.TabIndex = 0;
			// 
			// gbFaces
			// 
			this.tableLayoutPanel7.SetColumnSpan(this.gbFaces, 2);
			this.gbFaces.Controls.Add(this.tableLayoutPanel5);
			this.gbFaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbFaces.Location = new System.Drawing.Point(3, 446);
			this.gbFaces.Name = "gbFaces";
			this.gbFaces.Size = new System.Drawing.Size(416, 166);
			this.gbFaces.TabIndex = 63;
			this.gbFaces.TabStop = false;
			this.gbFaces.Text = "Faces";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 3;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.Controls.Add(this.label9, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.cbTemplateSize, 1, 2);
			this.tableLayoutPanel5.Controls.Add(this.label16, 0, 3);
			this.tableLayoutPanel5.Controls.Add(this.nudFacesMinInterOcularDistance, 1, 3);
			this.tableLayoutPanel5.Controls.Add(this.chbDetectMasks, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.label17, 0, 4);
			this.tableLayoutPanel5.Controls.Add(this.nudConfThreshold, 1, 4);
			this.tableLayoutPanel5.Controls.Add(this.nudQuality, 1, 5);
			this.tableLayoutPanel5.Controls.Add(this.label18, 0, 5);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(3);
			this.tableLayoutPanel5.RowCount = 8;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.Size = new System.Drawing.Size(410, 147);
			this.tableLayoutPanel5.TabIndex = 63;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(6, 26);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(172, 27);
			this.label9.TabIndex = 26;
			this.label9.Text = "Template Size";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbTemplateSize
			// 
			this.tableLayoutPanel5.SetColumnSpan(this.cbTemplateSize, 2);
			this.cbTemplateSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTemplateSize.FormattingEnabled = true;
			this.cbTemplateSize.Location = new System.Drawing.Point(184, 29);
			this.cbTemplateSize.Name = "cbTemplateSize";
			this.cbTemplateSize.Size = new System.Drawing.Size(116, 21);
			this.cbTemplateSize.TabIndex = 27;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label16.Location = new System.Drawing.Point(6, 53);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(172, 26);
			this.label16.TabIndex = 104;
			this.label16.Text = "Faces Minimal Interocular Distance";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nudFacesMinInterOcularDistance
			// 
			this.nudFacesMinInterOcularDistance.Location = new System.Drawing.Point(184, 56);
			this.nudFacesMinInterOcularDistance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nudFacesMinInterOcularDistance.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudFacesMinInterOcularDistance.Name = "nudFacesMinInterOcularDistance";
			this.nudFacesMinInterOcularDistance.Size = new System.Drawing.Size(44, 20);
			this.nudFacesMinInterOcularDistance.TabIndex = 105;
			this.nudFacesMinInterOcularDistance.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// chbDetectMasks
			// 
			this.chbDetectMasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chbDetectMasks.AutoSize = true;
			this.chbDetectMasks.Checked = true;
			this.chbDetectMasks.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbDetectMasks.Location = new System.Drawing.Point(87, 6);
			this.chbDetectMasks.Name = "chbDetectMasks";
			this.chbDetectMasks.Size = new System.Drawing.Size(91, 17);
			this.chbDetectMasks.TabIndex = 106;
			this.chbDetectMasks.Text = "Detect masks";
			this.chbDetectMasks.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(67, 85);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(111, 13);
			this.label17.TabIndex = 110;
			this.label17.Text = "Confidence Threshold";
			// 
			// nudConfThreshold
			// 
			this.nudConfThreshold.Location = new System.Drawing.Point(184, 82);
			this.nudConfThreshold.Name = "nudConfThreshold";
			this.nudConfThreshold.Size = new System.Drawing.Size(44, 20);
			this.nudConfThreshold.TabIndex = 111;
			this.nudConfThreshold.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// nudQuality
			// 
			this.nudQuality.Location = new System.Drawing.Point(184, 108);
			this.nudQuality.Name = "nudQuality";
			this.nudQuality.Size = new System.Drawing.Size(44, 20);
			this.nudQuality.TabIndex = 112;
			// 
			// label18
			// 
			this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(89, 111);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(89, 13);
			this.label18.TabIndex = 113;
			this.label18.Text = "Quality Threshold";
			// 
			// gbPlates
			// 
			this.tableLayoutPanel7.SetColumnSpan(this.gbPlates, 2);
			this.gbPlates.Controls.Add(this.tableLayoutPanel3);
			this.gbPlates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbPlates.Location = new System.Drawing.Point(3, 206);
			this.gbPlates.Name = "gbPlates";
			this.gbPlates.Size = new System.Drawing.Size(416, 234);
			this.gbPlates.TabIndex = 108;
			this.gbPlates.TabStop = false;
			this.gbPlates.Text = "License Plates";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.cbPlatesScaling, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.nudPlatesThreshold, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.nudOcrThreshold, 1, 4);
			this.tableLayoutPanel3.Controls.Add(this.label6, 0, 4);
			this.tableLayoutPanel3.Controls.Add(this.chbInterpretOasZero, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.nudMinCharCount, 1, 3);
			this.tableLayoutPanel3.Controls.Add(this.chbLPTemplateMatching, 0, 6);
			this.tableLayoutPanel3.Controls.Add(this.lblPriorityCountries, 0, 7);
			this.tableLayoutPanel3.Controls.Add(this.btnEditPriorityCountries, 2, 7);
			this.tableLayoutPanel3.Controls.Add(this.tbPriorityCountries, 1, 7);
			this.tableLayoutPanel3.Controls.Add(this.chbLatinCharactersOnly, 1, 5);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 9;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(410, 215);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Detector Scale Count";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(22, 33);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Detector Threshold";
			// 
			// cbPlatesScaling
			// 
			this.cbPlatesScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlatesScaling.FormattingEnabled = true;
			this.cbPlatesScaling.Location = new System.Drawing.Point(126, 3);
			this.cbPlatesScaling.Name = "cbPlatesScaling";
			this.cbPlatesScaling.Size = new System.Drawing.Size(144, 21);
			this.cbPlatesScaling.TabIndex = 2;
			// 
			// nudPlatesThreshold
			// 
			this.nudPlatesThreshold.Location = new System.Drawing.Point(126, 30);
			this.nudPlatesThreshold.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudPlatesThreshold.Name = "nudPlatesThreshold";
			this.nudPlatesThreshold.Size = new System.Drawing.Size(72, 20);
			this.nudPlatesThreshold.TabIndex = 3;
			this.nudPlatesThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// nudOcrThreshold
			// 
			this.nudOcrThreshold.Location = new System.Drawing.Point(126, 105);
			this.nudOcrThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudOcrThreshold.Name = "nudOcrThreshold";
			this.nudOcrThreshold.Size = new System.Drawing.Size(72, 20);
			this.nudOcrThreshold.TabIndex = 4;
			this.nudOcrThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(46, 108);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Ocr Threshold";
			// 
			// chbInterpretOasZero
			// 
			this.chbInterpretOasZero.AutoSize = true;
			this.chbInterpretOasZero.Checked = true;
			this.chbInterpretOasZero.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbInterpretOasZero.Location = new System.Drawing.Point(126, 56);
			this.chbInterpretOasZero.Name = "chbInterpretOasZero";
			this.chbInterpretOasZero.Size = new System.Drawing.Size(113, 17);
			this.chbInterpretOasZero.TabIndex = 7;
			this.chbInterpretOasZero.Text = "Interpret O as zero";
			this.chbInterpretOasZero.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 82);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Min Character Count";
			// 
			// nudMinCharCount
			// 
			this.nudMinCharCount.Location = new System.Drawing.Point(126, 79);
			this.nudMinCharCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudMinCharCount.Name = "nudMinCharCount";
			this.nudMinCharCount.Size = new System.Drawing.Size(72, 20);
			this.nudMinCharCount.TabIndex = 9;
			this.nudMinCharCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// chbLPTemplateMatching
			// 
			this.chbLPTemplateMatching.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.chbLPTemplateMatching.AutoSize = true;
			this.chbLPTemplateMatching.Location = new System.Drawing.Point(3, 154);
			this.chbLPTemplateMatching.Name = "chbLPTemplateMatching";
			this.chbLPTemplateMatching.Size = new System.Drawing.Size(117, 17);
			this.chbLPTemplateMatching.TabIndex = 10;
			this.chbLPTemplateMatching.Text = "Template Matching";
			this.chbLPTemplateMatching.UseVisualStyleBackColor = true;
			this.chbLPTemplateMatching.CheckStateChanged += new System.EventHandler(this.ChbLPTemplateMatchingCheckStateChanged);
			// 
			// lblPriorityCountries
			// 
			this.lblPriorityCountries.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblPriorityCountries.AutoSize = true;
			this.lblPriorityCountries.Enabled = false;
			this.lblPriorityCountries.Location = new System.Drawing.Point(35, 182);
			this.lblPriorityCountries.Name = "lblPriorityCountries";
			this.lblPriorityCountries.Size = new System.Drawing.Size(85, 13);
			this.lblPriorityCountries.TabIndex = 11;
			this.lblPriorityCountries.Text = "Priority Countries";
			// 
			// btnEditPriorityCountries
			// 
			this.btnEditPriorityCountries.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnEditPriorityCountries.Location = new System.Drawing.Point(316, 177);
			this.btnEditPriorityCountries.Name = "btnEditPriorityCountries";
			this.btnEditPriorityCountries.Size = new System.Drawing.Size(67, 23);
			this.btnEditPriorityCountries.TabIndex = 13;
			this.btnEditPriorityCountries.Text = "&Edit";
			this.btnEditPriorityCountries.UseVisualStyleBackColor = true;
			this.btnEditPriorityCountries.Click += new System.EventHandler(this.BtnEditPriorityCountriesClick);
			// 
			// tbPriorityCountries
			// 
			this.tbPriorityCountries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPriorityCountries.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.tbPriorityCountries.Location = new System.Drawing.Point(126, 178);
			this.tbPriorityCountries.Name = "tbPriorityCountries";
			this.tbPriorityCountries.Size = new System.Drawing.Size(184, 20);
			this.tbPriorityCountries.TabIndex = 14;
			// 
			// chbLatinCharactersOnly
			// 
			this.chbLatinCharactersOnly.AutoSize = true;
			this.chbLatinCharactersOnly.Location = new System.Drawing.Point(126, 131);
			this.chbLatinCharactersOnly.Name = "chbLatinCharactersOnly";
			this.chbLatinCharactersOnly.Size = new System.Drawing.Size(124, 17);
			this.chbLatinCharactersOnly.TabIndex = 15;
			this.chbLatinCharactersOnly.Text = "Latin characters only";
			this.chbLatinCharactersOnly.UseVisualStyleBackColor = true;
			// 
			// gbVh
			// 
			this.tableLayoutPanel7.SetColumnSpan(this.gbVh, 2);
			this.gbVh.Controls.Add(this.tableLayoutPanel2);
			this.gbVh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbVh.Location = new System.Drawing.Point(3, 86);
			this.gbVh.Name = "gbVh";
			this.gbVh.Size = new System.Drawing.Size(416, 114);
			this.gbVh.TabIndex = 107;
			this.gbVh.TabStop = false;
			this.gbVh.Text = "Vehicle-Human ";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudVhThreshold, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.chbDetectClothingDetails, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.chbDetectVehicleDetails, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.chbEstimageAgeGroup, 1, 3);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(410, 95);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Detector Threshold";
			// 
			// nudVhThreshold
			// 
			this.nudVhThreshold.Location = new System.Drawing.Point(107, 3);
			this.nudVhThreshold.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudVhThreshold.Name = "nudVhThreshold";
			this.nudVhThreshold.Size = new System.Drawing.Size(72, 20);
			this.nudVhThreshold.TabIndex = 3;
			this.nudVhThreshold.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// chbDetectClothingDetails
			// 
			this.chbDetectClothingDetails.AutoSize = true;
			this.chbDetectClothingDetails.Checked = true;
			this.chbDetectClothingDetails.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbDetectClothingDetails.Location = new System.Drawing.Point(107, 29);
			this.chbDetectClothingDetails.Name = "chbDetectClothingDetails";
			this.chbDetectClothingDetails.Size = new System.Drawing.Size(134, 17);
			this.chbDetectClothingDetails.TabIndex = 7;
			this.chbDetectClothingDetails.Text = "Detect Clothing Details";
			this.chbDetectClothingDetails.UseVisualStyleBackColor = true;
			// 
			// chbDetectVehicleDetails
			// 
			this.chbDetectVehicleDetails.AutoSize = true;
			this.chbDetectVehicleDetails.Checked = true;
			this.chbDetectVehicleDetails.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbDetectVehicleDetails.Location = new System.Drawing.Point(107, 52);
			this.chbDetectVehicleDetails.Name = "chbDetectVehicleDetails";
			this.chbDetectVehicleDetails.Size = new System.Drawing.Size(131, 17);
			this.chbDetectVehicleDetails.TabIndex = 7;
			this.chbDetectVehicleDetails.Text = "Detect Vehicle Details";
			this.chbDetectVehicleDetails.UseVisualStyleBackColor = true;
			// 
			// chbEstimageAgeGroup
			// 
			this.chbEstimageAgeGroup.AutoSize = true;
			this.chbEstimageAgeGroup.Checked = true;
			this.chbEstimageAgeGroup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbEstimageAgeGroup.Location = new System.Drawing.Point(107, 75);
			this.chbEstimageAgeGroup.Name = "chbEstimageAgeGroup";
			this.chbEstimageAgeGroup.Size = new System.Drawing.Size(120, 17);
			this.chbEstimageAgeGroup.TabIndex = 8;
			this.chbEstimageAgeGroup.Text = "Estimate Age Group";
			this.chbEstimageAgeGroup.UseVisualStyleBackColor = true;
			// 
			// gbCommon
			// 
			this.tableLayoutPanel7.SetColumnSpan(this.gbCommon, 2);
			this.gbCommon.Controls.Add(this.tableLayoutPanel6);
			this.gbCommon.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbCommon.Location = new System.Drawing.Point(3, 32);
			this.gbCommon.Name = "gbCommon";
			this.gbCommon.Size = new System.Drawing.Size(416, 48);
			this.gbCommon.TabIndex = 110;
			this.gbCommon.TabStop = false;
			this.gbCommon.Text = "Common";
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.cbScaling, 1, 0);
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(410, 29);
			this.tableLayoutPanel6.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 116;
			this.label1.Text = "Detector Scale Count";
			// 
			// cbScaling
			// 
			this.cbScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbScaling.FormattingEnabled = true;
			this.cbScaling.Location = new System.Drawing.Point(118, 3);
			this.cbScaling.Name = "cbScaling";
			this.cbScaling.Size = new System.Drawing.Size(144, 21);
			this.cbScaling.TabIndex = 117;
			// 
			// btnEditPreset
			// 
			this.btnEditPreset.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnEditPreset.Location = new System.Drawing.Point(352, 3);
			this.btnEditPreset.Name = "btnEditPreset";
			this.btnEditPreset.Size = new System.Drawing.Size(67, 23);
			this.btnEditPreset.TabIndex = 111;
			this.btnEditPreset.Text = "Edit";
			this.btnEditPreset.UseVisualStyleBackColor = true;
			this.btnEditPreset.Click += new System.EventHandler(this.BtnEditPresetClick);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(286, 821);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(67, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(440, 850);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsFormClosed);
			this.Shown += new System.EventHandler(this.SettingsFormShown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.gbSample.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxNodeCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRetryFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMatchingThreshold)).EndInit();
			this.gbPreset.ResumeLayout(false);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.gbFaces.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudFacesMinInterOcularDistance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudConfThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudQuality)).EndInit();
			this.gbPlates.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPlatesThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudOcrThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinCharCount)).EndInit();
			this.gbVh.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudVhThreshold)).EndInit();
			this.gbCommon.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.NumericUpDown nudRetryFreq;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudMaxNodeCount;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox gbVh;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudVhThreshold;
		private System.Windows.Forms.CheckBox chbDetectClothingDetails;
		private System.Windows.Forms.CheckBox chbDetectVehicleDetails;
		private System.Windows.Forms.GroupBox gbPlates;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbPlatesScaling;
		private System.Windows.Forms.NumericUpDown nudPlatesThreshold;
		private System.Windows.Forms.NumericUpDown nudOcrThreshold;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox gbSample;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.CheckBox chbInterpretOasZero;
		private System.Windows.Forms.CheckBox chbUseGpu;
		private System.Windows.Forms.CheckBox chbSaveEvents;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown nudMinCharCount;
		private System.Windows.Forms.GroupBox gbFaces;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbTemplateSize;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown nudMatchingThreshold;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.NumericUpDown nudFacesMinInterOcularDistance;
		private System.Windows.Forms.CheckBox chbDetectMasks;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.NumericUpDown nudConfThreshold;
		private System.Windows.Forms.NumericUpDown nudQuality;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chbLowMemory;
		private System.Windows.Forms.ComboBox cbScaling;
		private System.Windows.Forms.CheckBox chbLPTemplateMatching;
		private System.Windows.Forms.Label lblPriorityCountries;
		private System.Windows.Forms.Button btnEditPriorityCountries;
		private System.Windows.Forms.TextBox tbPriorityCountries;
		private System.Windows.Forms.GroupBox gbCommon;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.GroupBox gbPreset;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.Button btnEditPreset;
		private System.Windows.Forms.ComboBox cbPreset;
		private System.Windows.Forms.CheckBox chbEstimageAgeGroup;
		private System.Windows.Forms.CheckBox chbLatinCharactersOnly;
	}
}
