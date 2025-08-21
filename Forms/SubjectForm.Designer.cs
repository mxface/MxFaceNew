namespace Neurotec.Samples.Forms
{
	partial class SubjectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectForm));
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
			this.thumbBox = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.pbLicensePlate = new System.Windows.Forms.PictureBox();
			this.lblLicensePlate = new System.Windows.Forms.Label();
			this.lblOrigin = new System.Windows.Forms.Label();
			this.lblLprDetectionConf = new System.Windows.Forms.Label();
			this.lblOcrConf = new System.Windows.Forms.Label();
			this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
			this.objectView = new Neurotec.Samples.Forms.ImageView();
			this.pbGalery = new System.Windows.Forms.PictureBox();
			this.zoomSlider = new Neurotec.Gui.NViewZoomSlider();
			this.lblBestMatch = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.lblMatches = new System.Windows.Forms.Label();
			this.cbBestMatches = new System.Windows.Forms.ComboBox();
			this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
			this.toolStripSave = new System.Windows.Forms.ToolStrip();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.save2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sourceHeader = new Neurotec.Samples.Forms.SourceHeader();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnPrev = new System.Windows.Forms.Button();
			this.lblDetectionConf = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.detailsView1 = new Neurotec.Samples.Forms.DetailsView();
			this.button1 = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tlpLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumbBox)).BeginInit();
			this.tableLayoutPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLicensePlate)).BeginInit();
			this.tlpCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbGalery)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.tlpHeader.SuspendLayout();
			this.toolStripSave.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 2;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
			this.tlpMain.Controls.Add(this.splitContainer1, 0, 0);
			this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tlpMain.Controls.Add(this.detailsView1, 1, 0);
			this.tlpMain.Controls.Add(this.button1, 1, 2);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 7;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(1389, 775);
			this.tlpMain.TabIndex = 4;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tlpLeft);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tlpCenter);
			this.splitContainer1.Size = new System.Drawing.Size(1153, 718);
			this.splitContainer1.SplitterDistance = 381;
			this.splitContainer1.TabIndex = 5;
			this.splitContainer1.TabStop = false;
			// 
			// tlpLeft
			// 
			this.tlpLeft.ColumnCount = 1;
			this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpLeft.Controls.Add(this.thumbBox, 0, 0);
			this.tlpLeft.Controls.Add(this.tableLayoutPanel5, 0, 1);
			this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpLeft.Location = new System.Drawing.Point(0, 0);
			this.tlpLeft.Name = "tlpLeft";
			this.tlpLeft.RowCount = 2;
			this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
			this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpLeft.Size = new System.Drawing.Size(379, 716);
			this.tlpLeft.TabIndex = 0;
			// 
			// thumbBox
			// 
			this.thumbBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thumbBox.Location = new System.Drawing.Point(3, 3);
			this.thumbBox.Name = "thumbBox";
			this.thumbBox.Size = new System.Drawing.Size(373, 471);
			this.thumbBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.thumbBox.TabIndex = 0;
			this.thumbBox.TabStop = false;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.Controls.Add(this.pbLicensePlate, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.lblLicensePlate, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.lblOrigin, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.lblLprDetectionConf, 0, 3);
			this.tableLayoutPanel5.Controls.Add(this.lblOcrConf, 0, 4);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 480);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 5;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.Size = new System.Drawing.Size(373, 233);
			this.tableLayoutPanel5.TabIndex = 2;
			// 
			// pbLicensePlate
			// 
			this.pbLicensePlate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbLicensePlate.Location = new System.Drawing.Point(3, 3);
			this.pbLicensePlate.Name = "pbLicensePlate";
			this.pbLicensePlate.Size = new System.Drawing.Size(367, 151);
			this.pbLicensePlate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLicensePlate.TabIndex = 1;
			this.pbLicensePlate.TabStop = false;
			// 
			// lblLicensePlate
			// 
			this.lblLicensePlate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblLicensePlate.AutoSize = true;
			this.lblLicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblLicensePlate.Location = new System.Drawing.Point(139, 157);
			this.lblLicensePlate.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.lblLicensePlate.Name = "lblLicensePlate";
			this.lblLicensePlate.Size = new System.Drawing.Size(92, 16);
			this.lblLicensePlate.TabIndex = 2;
			this.lblLicensePlate.Text = "License Plate:";
			// 
			// lblOrigin
			// 
			this.lblOrigin.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblOrigin.AutoSize = true;
			this.lblOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblOrigin.Location = new System.Drawing.Point(162, 176);
			this.lblOrigin.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.lblOrigin.Name = "lblOrigin";
			this.lblOrigin.Size = new System.Drawing.Size(46, 16);
			this.lblOrigin.TabIndex = 3;
			this.lblOrigin.Text = "Origin:";
			// 
			// lblLprDetectionConf
			// 
			this.lblLprDetectionConf.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblLprDetectionConf.AutoSize = true;
			this.lblLprDetectionConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblLprDetectionConf.Location = new System.Drawing.Point(116, 195);
			this.lblLprDetectionConf.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.lblLprDetectionConf.Name = "lblLprDetectionConf";
			this.lblLprDetectionConf.Size = new System.Drawing.Size(137, 16);
			this.lblLprDetectionConf.TabIndex = 4;
			this.lblLprDetectionConf.Text = "Detection confidence:";
			// 
			// lblOcrConf
			// 
			this.lblOcrConf.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblOcrConf.AutoSize = true;
			this.lblOcrConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblOcrConf.Location = new System.Drawing.Point(130, 214);
			this.lblOcrConf.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.lblOcrConf.Name = "lblOcrConf";
			this.lblOcrConf.Size = new System.Drawing.Size(109, 16);
			this.lblOcrConf.TabIndex = 5;
			this.lblOcrConf.Text = "OCR confidence:";
			// 
			// tlpCenter
			// 
			this.tlpCenter.ColumnCount = 2;
			this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpCenter.Controls.Add(this.objectView, 0, 1);
			this.tlpCenter.Controls.Add(this.pbGalery, 1, 1);
			this.tlpCenter.Controls.Add(this.zoomSlider, 0, 2);
			this.tlpCenter.Controls.Add(this.lblBestMatch, 1, 2);
			this.tlpCenter.Controls.Add(this.tableLayoutPanel3, 1, 3);
			this.tlpCenter.Controls.Add(this.tlpHeader, 0, 0);
			this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCenter.Location = new System.Drawing.Point(0, 0);
			this.tlpCenter.Name = "tlpCenter";
			this.tlpCenter.RowCount = 4;
			this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpCenter.Size = new System.Drawing.Size(766, 716);
			this.tlpCenter.TabIndex = 15;
			// 
			// objectView
			// 
			this.objectView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.objectView.CheckState = null;
			this.objectView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objectView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.objectView.Image = null;
			this.objectView.Info = null;
			this.objectView.Location = new System.Drawing.Point(3, 34);
			this.objectView.Name = "objectView";
			this.objectView.SelectedEvent = null;
			this.objectView.Size = new System.Drawing.Size(377, 630);
			this.objectView.State = null;
			this.objectView.TabIndex = 14;
			// 
			// pbGalery
			// 
			this.pbGalery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbGalery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbGalery.Location = new System.Drawing.Point(386, 34);
			this.pbGalery.Name = "pbGalery";
			this.pbGalery.Size = new System.Drawing.Size(377, 630);
			this.pbGalery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbGalery.TabIndex = 15;
			this.pbGalery.TabStop = false;
			// 
			// zoomSlider
			// 
			this.zoomSlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.zoomSlider.Location = new System.Drawing.Point(3, 674);
			this.zoomSlider.Name = "zoomSlider";
			this.tlpCenter.SetRowSpan(this.zoomSlider, 2);
			this.zoomSlider.Size = new System.Drawing.Size(320, 34);
			this.zoomSlider.TabIndex = 7;
			this.zoomSlider.View = this.objectView;
			// 
			// lblBestMatch
			// 
			this.lblBestMatch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblBestMatch.AutoSize = true;
			this.lblBestMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblBestMatch.Location = new System.Drawing.Point(532, 667);
			this.lblBestMatch.Name = "lblBestMatch";
			this.lblBestMatch.Size = new System.Drawing.Size(84, 16);
			this.lblBestMatch.TabIndex = 17;
			this.lblBestMatch.Text = "Best Match";
			this.lblBestMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.lblMatches, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.cbBestMatches, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(386, 686);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(377, 27);
			this.tableLayoutPanel3.TabIndex = 20;
			// 
			// lblMatches
			// 
			this.lblMatches.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblMatches.AutoSize = true;
			this.lblMatches.Location = new System.Drawing.Point(3, 7);
			this.lblMatches.Name = "lblMatches";
			this.lblMatches.Size = new System.Drawing.Size(51, 13);
			this.lblMatches.TabIndex = 0;
			this.lblMatches.Text = "Matches:";
			// 
			// cbBestMatches
			// 
			this.cbBestMatches.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbBestMatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBestMatches.FormattingEnabled = true;
			this.cbBestMatches.Location = new System.Drawing.Point(60, 3);
			this.cbBestMatches.Name = "cbBestMatches";
			this.cbBestMatches.Size = new System.Drawing.Size(314, 21);
			this.cbBestMatches.TabIndex = 1;
			this.cbBestMatches.SelectedIndexChanged += new System.EventHandler(this.CbBestMatchesSelectedIndexChanged);
			// 
			// tlpHeader
			// 
			this.tlpHeader.AutoSize = true;
			this.tlpHeader.ColumnCount = 2;
			this.tlpCenter.SetColumnSpan(this.tlpHeader, 2);
			this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpHeader.Controls.Add(this.toolStripSave, 0, 0);
			this.tlpHeader.Controls.Add(this.sourceHeader, 1, 0);
			this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpHeader.Location = new System.Drawing.Point(3, 3);
			this.tlpHeader.Name = "tlpHeader";
			this.tlpHeader.RowCount = 1;
			this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpHeader.Size = new System.Drawing.Size(760, 25);
			this.tlpHeader.TabIndex = 22;
			// 
			// toolStripSave
			// 
			this.toolStripSave.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
			this.toolStripSave.Location = new System.Drawing.Point(0, 0);
			this.toolStripSave.Name = "toolStripSave";
			this.toolStripSave.Size = new System.Drawing.Size(102, 25);
			this.toolStripSave.TabIndex = 0;
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.save2ToolStripMenuItem});
			this.toolStripSplitButton1.Image = global::Neurotec.Samples.Properties.Resources.save;
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(99, 22);
			this.toolStripSplitButton1.Text = "Save Image";
			this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.ToolStripButtonClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.saveToolStripMenuItem.Text = "Save Image with Overlay";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// save2ToolStripMenuItem
			// 
			this.save2ToolStripMenuItem.Name = "save2ToolStripMenuItem";
			this.save2ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.save2ToolStripMenuItem.Text = "Save Original Image";
			this.save2ToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripWithoutOverlayClick);
			// 
			// sourceHeader
			// 
			this.sourceHeader.ActiveColor = System.Drawing.SystemColors.InactiveCaption;
			this.sourceHeader.ActiveSecondaryColor = System.Drawing.Color.Transparent;
			this.sourceHeader.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.sourceHeader.BackColor = System.Drawing.Color.Transparent;
			this.sourceHeader.CausesValidation = false;
			this.sourceHeader.CheckState = null;
			this.sourceHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sourceHeader.Location = new System.Drawing.Point(102, 0);
			this.sourceHeader.Margin = new System.Windows.Forms.Padding(0);
			this.sourceHeader.Name = "sourceHeader";
			this.sourceHeader.PassiveColor = System.Drawing.SystemColors.InactiveCaption;
			this.sourceHeader.PassiveSecondaryColor = System.Drawing.Color.Transparent;
			this.sourceHeader.ShowExpandedButtons = true;
			this.sourceHeader.ShowPinButton = false;
			this.sourceHeader.ShowTitle = false;
			this.sourceHeader.ShowTrackLineButton = true;
			this.sourceHeader.Size = new System.Drawing.Size(658, 25);
			this.sourceHeader.State = null;
			this.sourceHeader.TabIndex = 21;
			this.sourceHeader.Title = "";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.btnPrev, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblDetectionConf, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnNext, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 727);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(1153, 45);
			this.tableLayoutPanel2.TabIndex = 14;
			// 
			// btnPrev
			// 
			this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnPrev.Image = global::Neurotec.Samples.Properties.Resources.Previous;
			this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrev.Location = new System.Drawing.Point(408, 10);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(82, 25);
			this.btnPrev.TabIndex = 16;
			this.btnPrev.Text = "Previous";
			this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.BtnPrevClick);
			// 
			// lblDetectionConf
			// 
			this.lblDetectionConf.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblDetectionConf.AutoSize = true;
			this.lblDetectionConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblDetectionConf.Location = new System.Drawing.Point(496, 16);
			this.lblDetectionConf.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.lblDetectionConf.Name = "lblDetectionConf";
			this.lblDetectionConf.Size = new System.Drawing.Size(161, 13);
			this.lblDetectionConf.TabIndex = 14;
			this.lblDetectionConf.Text = "Detection Confidence: N/A";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnNext.Image = global::Neurotec.Samples.Properties.Resources.Next;
			this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNext.Location = new System.Drawing.Point(663, 10);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(89, 25);
			this.btnNext.TabIndex = 15;
			this.btnNext.Text = "Next";
			this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
			// 
			// detailsView1
			// 
			this.detailsView1.AnalyticEventMode = Neurotec.Samples.Forms.DetailsView.EventSelectionMode.Selection;
			this.detailsView1.AnalyticEventsShowBest = true;
			this.detailsView1.AutoScroll = true;
			this.detailsView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailsView1.Filter = Neurotec.Samples.Forms.DetailsView.DetailsType.None;
			this.detailsView1.Info = null;
			this.detailsView1.Location = new System.Drawing.Point(1162, 3);
			this.detailsView1.Name = "detailsView1";
			this.detailsView1.Size = new System.Drawing.Size(224, 718);
			this.detailsView1.TabIndex = 15;
			this.detailsView1.ShowTriggerDetails += new System.EventHandler<Neurotec.Samples.Forms.DetailsView.ShowArgs>(this.DetailsViewShowTriggerDetails);
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(1311, 738);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Png Image|*.png|Jpeg Image|*.jpg|Bitmap Image|*.bmp";
			// 
			// SubjectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1389, 775);
			this.Controls.Add(this.tlpMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "SubjectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SubjectForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubjectFormFormClosing);
			this.Load += new System.EventHandler(this.SubjectFormLoad);
			this.tlpMain.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tlpLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.thumbBox)).EndInit();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLicensePlate)).EndInit();
			this.tlpCenter.ResumeLayout(false);
			this.tlpCenter.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbGalery)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tlpHeader.ResumeLayout(false);
			this.tlpHeader.PerformLayout();
			this.toolStripSave.ResumeLayout(false);
			this.toolStripSave.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox thumbBox;
		private System.Windows.Forms.TableLayoutPanel tlpLeft;
		private System.Windows.Forms.PictureBox pbLicensePlate;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Label lblLicensePlate;
		private System.Windows.Forms.Label lblOrigin;
		private System.Windows.Forms.Label lblLprDetectionConf;
		private System.Windows.Forms.Label lblOcrConf;
		private System.Windows.Forms.Label lblDetectionConf;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private DetailsView detailsView1;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.TableLayoutPanel tlpCenter;
		private ImageView objectView;
		private System.Windows.Forms.PictureBox pbGalery;
		private Gui.NViewZoomSlider zoomSlider;
		private System.Windows.Forms.Label lblBestMatch;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label lblMatches;
		private System.Windows.Forms.ComboBox cbBestMatches;
		private System.Windows.Forms.TableLayoutPanel tlpHeader;
		private System.Windows.Forms.ToolStrip toolStripSave;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem save2ToolStripMenuItem;
		private SourceHeader sourceHeader;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}
