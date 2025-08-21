namespace Neurotec.Samples.Config.Forms
{
	partial class SourceConfigurationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceConfigurationForm));
			this.lblHint = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panelImage = new Neurotec.Samples.Forms.DoubleBufferedPanel();
			this.panel1 = new Neurotec.Samples.Forms.DoubleBufferedPanel();
			this.tlpTools = new System.Windows.Forms.TableLayoutPanel();
			this.btnGeneral = new System.Windows.Forms.Button();
			this.tlpAreas = new System.Windows.Forms.TableLayoutPanel();
			this.rbToolRegions = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudRows = new System.Windows.Forms.NumericUpDown();
			this.nudColumns = new System.Windows.Forms.NumericUpDown();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbIncludeRect = new System.Windows.Forms.ToolStripButton();
			this.tsbExcludeRect = new System.Windows.Forms.ToolStripButton();
			this.tsbIncludePolygon = new System.Windows.Forms.ToolStripButton();
			this.tsbExcludePolygon = new System.Windows.Forms.ToolStripButton();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnUndo = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.chbAreaByCenter = new System.Windows.Forms.CheckBox();
			this.rbGridTool = new System.Windows.Forms.RadioButton();
			this.tlpTriggers = new System.Windows.Forms.TableLayoutPanel();
			this.toolStripTriggerTools = new System.Windows.Forms.ToolStrip();
			this.tsbNewTripwire = new System.Windows.Forms.ToolStripButton();
			this.tsbNewRegion = new System.Windows.Forms.ToolStripButton();
			this.tsbNewRegionRect = new System.Windows.Forms.ToolStripButton();
			this.label4 = new System.Windows.Forms.Label();
			this.lvTriggers = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblProperties = new System.Windows.Forms.Label();
			this.tlpProperties = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbOrigin = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnSelectColor = new System.Windows.Forms.Button();
			this.btnInvertTripwire = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.chbEventAppeared = new System.Windows.Forms.CheckBox();
			this.chbEventIn = new System.Windows.Forms.CheckBox();
			this.chbEventOut = new System.Windows.Forms.CheckBox();
			this.chbEventDisappeared = new System.Windows.Forms.CheckBox();
			this.chbEventTimer = new System.Windows.Forms.CheckBox();
			this.lblEventMinDuration = new System.Windows.Forms.Label();
			this.nudEventMinumDuration = new System.Windows.Forms.NumericUpDown();
			this.lblEventDuration = new System.Windows.Forms.Label();
			this.nudEventDuration = new System.Windows.Forms.NumericUpDown();
			this.btnDeleteTrigger = new System.Windows.Forms.Button();
			this.btnSearchAreas = new System.Windows.Forms.Button();
			this.btnTriggers = new System.Windows.Forms.Button();
			this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbFormats = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbPreset = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tlpTools.SuspendLayout();
			this.tlpAreas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tlpTriggers.SuspendLayout();
			this.toolStripTriggerTools.SuspendLayout();
			this.tlpProperties.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudEventMinumDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEventDuration)).BeginInit();
			this.tlpGeneral.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblHint
			// 
			this.lblHint.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblHint.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblHint, 3);
			this.lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblHint.Location = new System.Drawing.Point(632, 17);
			this.lblHint.Margin = new System.Windows.Forms.Padding(5);
			this.lblHint.Name = "lblHint";
			this.lblHint.Size = new System.Drawing.Size(44, 16);
			this.lblHint.TabIndex = 0;
			this.lblHint.Text = "HINT";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(929, 730);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(1010, 730);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.lblHint, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnOk, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.panelImage, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1088, 756);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Tripwire.png");
			this.imageList.Images.SetKeyName(1, "Polygon.png");
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// panelImage
			// 
			this.panelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.panelImage, 2);
			this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelImage.Location = new System.Drawing.Point(223, 53);
			this.panelImage.Name = "panelImage";
			this.panelImage.Size = new System.Drawing.Size(862, 671);
			this.panelImage.TabIndex = 7;
			this.panelImage.SizeChanged += new System.EventHandler(this.PanelImageSizeChanged);
			this.panelImage.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelImagePaint);
			this.panelImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelImageMouseDown);
			this.panelImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelImageMouseMove);
			this.panelImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelImageMouseUp);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tlpTools);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 53);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(214, 671);
			this.panel1.TabIndex = 9;
			// 
			// tlpTools
			// 
			this.tlpTools.BackColor = System.Drawing.SystemColors.Control;
			this.tlpTools.ColumnCount = 1;
			this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpTools.Controls.Add(this.btnGeneral, 0, 4);
			this.tlpTools.Controls.Add(this.tlpAreas, 0, 3);
			this.tlpTools.Controls.Add(this.tlpTriggers, 0, 1);
			this.tlpTools.Controls.Add(this.btnSearchAreas, 0, 2);
			this.tlpTools.Controls.Add(this.btnTriggers, 0, 0);
			this.tlpTools.Controls.Add(this.tlpGeneral, 0, 5);
			this.tlpTools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpTools.Location = new System.Drawing.Point(0, 0);
			this.tlpTools.Name = "tlpTools";
			this.tlpTools.RowCount = 6;
			this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTools.Size = new System.Drawing.Size(214, 671);
			this.tlpTools.TabIndex = 8;
			// 
			// btnGeneral
			// 
			this.btnGeneral.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGeneral.FlatAppearance.BorderSize = 0;
			this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGeneral.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnGeneral.Location = new System.Drawing.Point(3, 511);
			this.btnGeneral.Name = "btnGeneral";
			this.btnGeneral.Size = new System.Drawing.Size(208, 27);
			this.btnGeneral.TabIndex = 10;
			this.btnGeneral.Text = "General ?";
			this.btnGeneral.UseVisualStyleBackColor = false;
			this.btnGeneral.Click += new System.EventHandler(this.BtnGeneralClick);
			// 
			// tlpAreas
			// 
			this.tlpAreas.BackColor = System.Drawing.SystemColors.Control;
			this.tlpAreas.ColumnCount = 3;
			this.tlpAreas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpAreas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpAreas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAreas.Controls.Add(this.rbToolRegions, 0, 3);
			this.tlpAreas.Controls.Add(this.label1, 1, 1);
			this.tlpAreas.Controls.Add(this.label2, 1, 2);
			this.tlpAreas.Controls.Add(this.nudRows, 2, 1);
			this.tlpAreas.Controls.Add(this.nudColumns, 2, 2);
			this.tlpAreas.Controls.Add(this.toolStrip1, 1, 4);
			this.tlpAreas.Controls.Add(this.tableLayoutPanel3, 0, 5);
			this.tlpAreas.Controls.Add(this.label3, 0, 6);
			this.tlpAreas.Controls.Add(this.chbAreaByCenter, 1, 7);
			this.tlpAreas.Controls.Add(this.rbGridTool, 0, 0);
			this.tlpAreas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpAreas.Location = new System.Drawing.Point(3, 288);
			this.tlpAreas.Name = "tlpAreas";
			this.tlpAreas.RowCount = 9;
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAreas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpAreas.Size = new System.Drawing.Size(208, 217);
			this.tlpAreas.TabIndex = 6;
			// 
			// rbToolRegions
			// 
			this.rbToolRegions.AutoSize = true;
			this.tlpAreas.SetColumnSpan(this.rbToolRegions, 3);
			this.rbToolRegions.Location = new System.Drawing.Point(3, 78);
			this.rbToolRegions.Name = "rbToolRegions";
			this.rbToolRegions.Size = new System.Drawing.Size(64, 17);
			this.rbToolRegions.TabIndex = 1;
			this.rbToolRegions.Text = "Regions";
			this.rbToolRegions.UseVisualStyleBackColor = true;
			this.rbToolRegions.CheckedChanged += new System.EventHandler(this.RadioBoxSelectionToolCheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(13, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = "Rows:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(13, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 26);
			this.label2.TabIndex = 2;
			this.label2.Text = "Columns:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nudRows
			// 
			this.nudRows.Location = new System.Drawing.Point(69, 26);
			this.nudRows.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.nudRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudRows.Name = "nudRows";
			this.nudRows.Size = new System.Drawing.Size(45, 20);
			this.nudRows.TabIndex = 3;
			this.nudRows.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.nudRows.ValueChanged += new System.EventHandler(this.NudGridValueChanged);
			// 
			// nudColumns
			// 
			this.nudColumns.Location = new System.Drawing.Point(69, 52);
			this.nudColumns.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.nudColumns.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudColumns.Name = "nudColumns";
			this.nudColumns.Size = new System.Drawing.Size(45, 20);
			this.nudColumns.TabIndex = 4;
			this.nudColumns.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.nudColumns.ValueChanged += new System.EventHandler(this.NudGridValueChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
			this.tlpAreas.SetColumnSpan(this.toolStrip1, 2);
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbIncludeRect,
            this.tsbExcludeRect,
            this.tsbIncludePolygon,
            this.tsbExcludePolygon});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStrip1.Location = new System.Drawing.Point(10, 98);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(198, 92);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbIncludeRect
			// 
			this.tsbIncludeRect.Checked = true;
			this.tsbIncludeRect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbIncludeRect.Image = global::Neurotec.Samples.Properties.Resources.Rectangle;
			this.tsbIncludeRect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbIncludeRect.Name = "tsbIncludeRect";
			this.tsbIncludeRect.Size = new System.Drawing.Size(121, 20);
			this.tsbIncludeRect.Text = "Include Rectangle";
			this.tsbIncludeRect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbIncludeRect.ToolTipText = "Draw recangle where search should be performed.\r\nPress \"1\" to select.";
			this.tsbIncludeRect.Click += new System.EventHandler(this.ToolStripButtonClick);
			// 
			// tsbExcludeRect
			// 
			this.tsbExcludeRect.Image = global::Neurotec.Samples.Properties.Resources.RectangleRed;
			this.tsbExcludeRect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbExcludeRect.Name = "tsbExcludeRect";
			this.tsbExcludeRect.Size = new System.Drawing.Size(123, 20);
			this.tsbExcludeRect.Text = "Exclude Rectangle";
			this.tsbExcludeRect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbExcludeRect.ToolTipText = "Draw recangle where search should NOT be performed.\r\nPress \"2\" to select.\r\n";
			this.tsbExcludeRect.Click += new System.EventHandler(this.ToolStripButtonClick);
			// 
			// tsbIncludePolygon
			// 
			this.tsbIncludePolygon.Image = global::Neurotec.Samples.Properties.Resources.Polygon;
			this.tsbIncludePolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbIncludePolygon.Name = "tsbIncludePolygon";
			this.tsbIncludePolygon.Size = new System.Drawing.Size(113, 20);
			this.tsbIncludePolygon.Text = "Include Polygon";
			this.tsbIncludePolygon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbIncludePolygon.ToolTipText = "Draw polygon where search should be performed.\r\nPress \"3\" to select.\r\n";
			this.tsbIncludePolygon.Click += new System.EventHandler(this.ToolStripButtonClick);
			// 
			// tsbExcludePolygon
			// 
			this.tsbExcludePolygon.Image = global::Neurotec.Samples.Properties.Resources.PolygonRed;
			this.tsbExcludePolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbExcludePolygon.Name = "tsbExcludePolygon";
			this.tsbExcludePolygon.Size = new System.Drawing.Size(115, 20);
			this.tsbExcludePolygon.Text = "Exclude Polygon";
			this.tsbExcludePolygon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbExcludePolygon.ToolTipText = "Draw polygon where search should NOT be performed.\r\nPress \"4\" to select.";
			this.tsbExcludePolygon.Click += new System.EventHandler(this.ToolStripButtonClick);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tlpAreas.SetColumnSpan(this.tableLayoutPanel3, 3);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.btnReset, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnUndo, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 193);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(202, 29);
			this.tableLayoutPanel3.TabIndex = 7;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(104, 3);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(53, 23);
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "&Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// btnUndo
			// 
			this.btnUndo.Enabled = false;
			this.btnUndo.Location = new System.Drawing.Point(3, 3);
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(57, 23);
			this.btnUndo.TabIndex = 6;
			this.btnUndo.Text = "&Undo";
			this.btnUndo.UseVisualStyleBackColor = true;
			this.btnUndo.Click += new System.EventHandler(this.BtnUndoClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.tlpAreas.SetColumnSpan(this.label3, 3);
			this.label3.Location = new System.Drawing.Point(3, 225);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Options:";
			// 
			// chbAreaByCenter
			// 
			this.chbAreaByCenter.AutoSize = true;
			this.chbAreaByCenter.Checked = true;
			this.chbAreaByCenter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpAreas.SetColumnSpan(this.chbAreaByCenter, 2);
			this.chbAreaByCenter.Location = new System.Drawing.Point(13, 241);
			this.chbAreaByCenter.Name = "chbAreaByCenter";
			this.chbAreaByCenter.Size = new System.Drawing.Size(133, 30);
			this.chbAreaByCenter.TabIndex = 9;
			this.chbAreaByCenter.Text = "Check search area by \r\nobject center";
			this.toolTip1.SetToolTip(this.chbAreaByCenter, "Checks if object is in area by its center.\r\nOtherwise entire object must be insid" +
        "e area.");
			this.chbAreaByCenter.UseVisualStyleBackColor = true;
			// 
			// rbGridTool
			// 
			this.rbGridTool.AutoSize = true;
			this.rbGridTool.Checked = true;
			this.tlpAreas.SetColumnSpan(this.rbGridTool, 3);
			this.rbGridTool.Location = new System.Drawing.Point(3, 3);
			this.rbGridTool.Name = "rbGridTool";
			this.rbGridTool.Size = new System.Drawing.Size(44, 17);
			this.rbGridTool.TabIndex = 0;
			this.rbGridTool.TabStop = true;
			this.rbGridTool.Text = "Grid";
			this.rbGridTool.UseVisualStyleBackColor = true;
			this.rbGridTool.CheckedChanged += new System.EventHandler(this.RadioBoxSelectionToolCheckedChanged);
			// 
			// tlpTriggers
			// 
			this.tlpTriggers.BackColor = System.Drawing.SystemColors.Control;
			this.tlpTriggers.ColumnCount = 1;
			this.tlpTriggers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpTriggers.Controls.Add(this.toolStripTriggerTools, 0, 0);
			this.tlpTriggers.Controls.Add(this.label4, 0, 1);
			this.tlpTriggers.Controls.Add(this.lvTriggers, 0, 3);
			this.tlpTriggers.Controls.Add(this.lblProperties, 0, 4);
			this.tlpTriggers.Controls.Add(this.tlpProperties, 0, 5);
			this.tlpTriggers.Controls.Add(this.btnDeleteTrigger, 0, 2);
			this.tlpTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpTriggers.Location = new System.Drawing.Point(3, 36);
			this.tlpTriggers.Name = "tlpTriggers";
			this.tlpTriggers.RowCount = 6;
			this.tlpTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTriggers.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpTriggers.Size = new System.Drawing.Size(208, 217);
			this.tlpTriggers.TabIndex = 9;
			// 
			// toolStripTriggerTools
			// 
			this.toolStripTriggerTools.BackColor = System.Drawing.Color.Transparent;
			this.toolStripTriggerTools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripTriggerTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewTripwire,
            this.tsbNewRegion,
            this.tsbNewRegionRect});
			this.toolStripTriggerTools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this.toolStripTriggerTools.Location = new System.Drawing.Point(0, 0);
			this.toolStripTriggerTools.Name = "toolStripTriggerTools";
			this.toolStripTriggerTools.Size = new System.Drawing.Size(208, 88);
			this.toolStripTriggerTools.TabIndex = 6;
			// 
			// tsbNewTripwire
			// 
			this.tsbNewTripwire.Checked = true;
			this.tsbNewTripwire.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbNewTripwire.Image = global::Neurotec.Samples.Properties.Resources.Tripwire;
			this.tsbNewTripwire.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNewTripwire.Name = "tsbNewTripwire";
			this.tsbNewTripwire.Size = new System.Drawing.Size(95, 20);
			this.tsbNewTripwire.Text = "New Tripwire";
			this.tsbNewTripwire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbNewTripwire.ToolTipText = "Create new tripwire by drawing single line.\r\nAnalytic events are generated if sub" +
    "ject passes through drawed line.";
			this.tsbNewTripwire.Click += new System.EventHandler(this.TsbTriggerClick);
			// 
			// tsbNewRegion
			// 
			this.tsbNewRegion.Image = global::Neurotec.Samples.Properties.Resources.Polygon;
			this.tsbNewRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNewRegion.Name = "tsbNewRegion";
			this.tsbNewRegion.Size = new System.Drawing.Size(91, 20);
			this.tsbNewRegion.Text = "New Region";
			this.tsbNewRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbNewRegion.ToolTipText = "Create new region by selecting its points.\r\nAnalytic events are generated if subj" +
    "ect crosses inside or outside the region, or stays in it for specific amount of " +
    "time.";
			this.tsbNewRegion.Click += new System.EventHandler(this.TsbTriggerClick);
			// 
			// tsbNewRegionRect
			// 
			this.tsbNewRegionRect.Image = global::Neurotec.Samples.Properties.Resources.Rectangle;
			this.tsbNewRegionRect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNewRegionRect.Name = "tsbNewRegionRect";
			this.tsbNewRegionRect.Size = new System.Drawing.Size(91, 20);
			this.tsbNewRegionRect.Text = "New Region";
			this.tsbNewRegionRect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbNewRegionRect.ToolTipText = "Create new region by drawing rectangle.\r\nAnalytic events are generated if subject" +
    " crosses inside or outside the region, or stays in it for specific amount of tim" +
    "e.";
			this.tsbNewRegionRect.Click += new System.EventHandler(this.TsbTriggerClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Triggers";
			// 
			// lvTriggers
			// 
			this.lvTriggers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvTriggers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvTriggers.FullRowSelect = true;
			this.lvTriggers.HideSelection = false;
			this.lvTriggers.Location = new System.Drawing.Point(3, 134);
			this.lvTriggers.MultiSelect = false;
			this.lvTriggers.Name = "lvTriggers";
			this.lvTriggers.Size = new System.Drawing.Size(202, 1);
			this.lvTriggers.SmallImageList = this.imageList;
			this.lvTriggers.TabIndex = 8;
			this.lvTriggers.UseCompatibleStateImageBehavior = false;
			this.lvTriggers.View = System.Windows.Forms.View.Details;
			this.lvTriggers.SelectedIndexChanged += new System.EventHandler(this.LvTriggersSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Type";
			this.columnHeader1.Width = 37;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 128;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = " Color";
			this.columnHeader3.Width = 10;
			// 
			// lblProperties
			// 
			this.lblProperties.AutoSize = true;
			this.lblProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProperties.Location = new System.Drawing.Point(3, -112);
			this.lblProperties.Name = "lblProperties";
			this.lblProperties.Size = new System.Drawing.Size(86, 13);
			this.lblProperties.TabIndex = 9;
			this.lblProperties.Text = "Confirugration";
			// 
			// tlpProperties
			// 
			this.tlpProperties.AutoSize = true;
			this.tlpProperties.ColumnCount = 3;
			this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpProperties.Controls.Add(this.label5, 0, 0);
			this.tlpProperties.Controls.Add(this.tbName, 1, 0);
			this.tlpProperties.Controls.Add(this.label6, 0, 1);
			this.tlpProperties.Controls.Add(this.cbOrigin, 1, 1);
			this.tlpProperties.Controls.Add(this.label7, 0, 2);
			this.tlpProperties.Controls.Add(this.btnSelectColor, 1, 2);
			this.tlpProperties.Controls.Add(this.btnInvertTripwire, 1, 13);
			this.tlpProperties.Controls.Add(this.label8, 0, 3);
			this.tlpProperties.Controls.Add(this.chbEventAppeared, 1, 4);
			this.tlpProperties.Controls.Add(this.chbEventIn, 1, 5);
			this.tlpProperties.Controls.Add(this.chbEventOut, 1, 6);
			this.tlpProperties.Controls.Add(this.chbEventDisappeared, 1, 7);
			this.tlpProperties.Controls.Add(this.chbEventTimer, 1, 8);
			this.tlpProperties.Controls.Add(this.lblEventMinDuration, 1, 9);
			this.tlpProperties.Controls.Add(this.nudEventMinumDuration, 2, 10);
			this.tlpProperties.Controls.Add(this.lblEventDuration, 1, 11);
			this.tlpProperties.Controls.Add(this.nudEventDuration, 2, 12);
			this.tlpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpProperties.Location = new System.Drawing.Point(3, -96);
			this.tlpProperties.Name = "tlpProperties";
			this.tlpProperties.RowCount = 13;
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProperties.Size = new System.Drawing.Size(202, 310);
			this.tlpProperties.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Name";
			// 
			// tbName
			// 
			this.tlpProperties.SetColumnSpan(this.tbName, 2);
			this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbName.Enabled = false;
			this.tbName.Location = new System.Drawing.Point(44, 3);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(155, 20);
			this.tbName.TabIndex = 1;
			this.toolTip1.SetToolTip(this.tbName, "Name used for event description");
			this.tbName.TextChanged += new System.EventHandler(this.TbNameTextChanged);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Origin";
			// 
			// cbOrigin
			// 
			this.tlpProperties.SetColumnSpan(this.cbOrigin, 2);
			this.cbOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOrigin.Enabled = false;
			this.cbOrigin.FormattingEnabled = true;
			this.cbOrigin.Location = new System.Drawing.Point(44, 29);
			this.cbOrigin.Name = "cbOrigin";
			this.cbOrigin.Size = new System.Drawing.Size(155, 21);
			this.cbOrigin.TabIndex = 3;
			this.toolTip1.SetToolTip(this.cbOrigin, "Determine which point of object rectangle is used to test triggers");
			this.cbOrigin.SelectedIndexChanged += new System.EventHandler(this.CbOriginSelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 57);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Color";
			// 
			// btnSelectColor
			// 
			this.btnSelectColor.BackColor = System.Drawing.Color.Red;
			this.tlpProperties.SetColumnSpan(this.btnSelectColor, 2);
			this.btnSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSelectColor.FlatAppearance.BorderSize = 0;
			this.btnSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectColor.Location = new System.Drawing.Point(44, 56);
			this.btnSelectColor.Name = "btnSelectColor";
			this.btnSelectColor.Size = new System.Drawing.Size(155, 15);
			this.btnSelectColor.TabIndex = 5;
			this.toolTip1.SetToolTip(this.btnSelectColor, "Display color of trigger");
			this.btnSelectColor.UseVisualStyleBackColor = false;
			this.btnSelectColor.Click += new System.EventHandler(this.BtnSelectColorClick);
			// 
			// btnInvertTripwire
			// 
			this.btnInvertTripwire.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tlpProperties.SetColumnSpan(this.btnInvertTripwire, 3);
			this.btnInvertTripwire.Enabled = false;
			this.btnInvertTripwire.FlatAppearance.BorderSize = 0;
			this.btnInvertTripwire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInvertTripwire.Image = global::Neurotec.Samples.Properties.Resources.Tripwire;
			this.btnInvertTripwire.Location = new System.Drawing.Point(23, 283);
			this.btnInvertTripwire.Name = "btnInvertTripwire";
			this.btnInvertTripwire.Size = new System.Drawing.Size(155, 24);
			this.btnInvertTripwire.TabIndex = 6;
			this.btnInvertTripwire.Text = "Change Tripwire Direction";
			this.btnInvertTripwire.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnInvertTripwire, "Change Tripwire Direction");
			this.btnInvertTripwire.UseVisualStyleBackColor = true;
			this.btnInvertTripwire.Click += new System.EventHandler(this.BtnInvertTripwireClick);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.tlpProperties.SetColumnSpan(this.label8, 3);
			this.label8.Location = new System.Drawing.Point(3, 74);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Event Types:";
			// 
			// chbEventAppeared
			// 
			this.chbEventAppeared.AutoSize = true;
			this.chbEventAppeared.Checked = true;
			this.chbEventAppeared.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpProperties.SetColumnSpan(this.chbEventAppeared, 2);
			this.chbEventAppeared.Enabled = false;
			this.chbEventAppeared.Location = new System.Drawing.Point(44, 90);
			this.chbEventAppeared.Name = "chbEventAppeared";
			this.chbEventAppeared.Size = new System.Drawing.Size(84, 17);
			this.chbEventAppeared.TabIndex = 8;
			this.chbEventAppeared.Text = "Appeared In";
			this.toolTip1.SetToolTip(this.chbEventAppeared, "Event is generated if subjects begins tracking inside region");
			this.chbEventAppeared.UseVisualStyleBackColor = true;
			this.chbEventAppeared.CheckedChanged += new System.EventHandler(this.ChbEventAppearedCheckedChanged);
			// 
			// chbEventIn
			// 
			this.chbEventIn.AutoSize = true;
			this.chbEventIn.Checked = true;
			this.chbEventIn.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpProperties.SetColumnSpan(this.chbEventIn, 2);
			this.chbEventIn.Enabled = false;
			this.chbEventIn.Location = new System.Drawing.Point(44, 113);
			this.chbEventIn.Name = "chbEventIn";
			this.chbEventIn.Size = new System.Drawing.Size(76, 17);
			this.chbEventIn.TabIndex = 9;
			this.chbEventIn.Text = "Crossed In";
			this.toolTip1.SetToolTip(this.chbEventIn, "Event is generated if subject crosses tripwire with IN direction or enters region" +
        "");
			this.chbEventIn.UseVisualStyleBackColor = true;
			this.chbEventIn.CheckedChanged += new System.EventHandler(this.ChbEventInCheckedChanged);
			// 
			// chbEventOut
			// 
			this.chbEventOut.AutoSize = true;
			this.chbEventOut.Checked = true;
			this.chbEventOut.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpProperties.SetColumnSpan(this.chbEventOut, 2);
			this.chbEventOut.Enabled = false;
			this.chbEventOut.Location = new System.Drawing.Point(44, 136);
			this.chbEventOut.Name = "chbEventOut";
			this.chbEventOut.Size = new System.Drawing.Size(84, 17);
			this.chbEventOut.TabIndex = 10;
			this.chbEventOut.Text = "Crossed Out";
			this.toolTip1.SetToolTip(this.chbEventOut, "Event is generated if subject crosses tripwire with OUT direction or leaves regio" +
        "n");
			this.chbEventOut.UseVisualStyleBackColor = true;
			this.chbEventOut.CheckedChanged += new System.EventHandler(this.ChbEventOutCheckedChanged);
			// 
			// chbEventDisappeared
			// 
			this.chbEventDisappeared.AutoSize = true;
			this.chbEventDisappeared.Checked = true;
			this.chbEventDisappeared.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpProperties.SetColumnSpan(this.chbEventDisappeared, 2);
			this.chbEventDisappeared.Enabled = false;
			this.chbEventDisappeared.Location = new System.Drawing.Point(44, 159);
			this.chbEventDisappeared.Name = "chbEventDisappeared";
			this.chbEventDisappeared.Size = new System.Drawing.Size(98, 17);
			this.chbEventDisappeared.TabIndex = 11;
			this.chbEventDisappeared.Text = "Disappeared In";
			this.toolTip1.SetToolTip(this.chbEventDisappeared, "Event is generated if subject ends tracking inside region (Leaves outside visible" +
        " area, gets obstructed by other objects or becomes stationary)");
			this.chbEventDisappeared.UseVisualStyleBackColor = true;
			this.chbEventDisappeared.CheckedChanged += new System.EventHandler(this.ChbEventDisappearedCheckedChanged);
			// 
			// chbEventTimer
			// 
			this.chbEventTimer.AutoSize = true;
			this.chbEventTimer.Checked = true;
			this.chbEventTimer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tlpProperties.SetColumnSpan(this.chbEventTimer, 2);
			this.chbEventTimer.Enabled = false;
			this.chbEventTimer.Location = new System.Drawing.Point(44, 182);
			this.chbEventTimer.Name = "chbEventTimer";
			this.chbEventTimer.Size = new System.Drawing.Size(88, 17);
			this.chbEventTimer.TabIndex = 12;
			this.chbEventTimer.Text = "Timer Events";
			this.toolTip1.SetToolTip(this.chbEventTimer, "Generate events when subject to time subject staying inside region.");
			this.chbEventTimer.UseVisualStyleBackColor = true;
			this.chbEventTimer.CheckedChanged += new System.EventHandler(this.ChbEventTimerCheckedChanged);
			// 
			// lblEventMinDuration
			// 
			this.lblEventMinDuration.AutoSize = true;
			this.tlpProperties.SetColumnSpan(this.lblEventMinDuration, 2);
			this.lblEventMinDuration.Enabled = false;
			this.lblEventMinDuration.Location = new System.Drawing.Point(44, 202);
			this.lblEventMinDuration.Name = "lblEventMinDuration";
			this.lblEventMinDuration.Size = new System.Drawing.Size(142, 13);
			this.lblEventMinDuration.TabIndex = 14;
			this.lblEventMinDuration.Text = "Minimum Duration (Seconds)";
			// 
			// nudEventMinumDuration
			// 
			this.nudEventMinumDuration.Enabled = false;
			this.nudEventMinumDuration.Location = new System.Drawing.Point(64, 218);
			this.nudEventMinumDuration.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.nudEventMinumDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudEventMinumDuration.Name = "nudEventMinumDuration";
			this.nudEventMinumDuration.Size = new System.Drawing.Size(64, 20);
			this.nudEventMinumDuration.TabIndex = 13;
			this.toolTip1.SetToolTip(this.nudEventMinumDuration, "Minimum time subject needs to stay in rectangle to generate timer events (start, " +
        "timer, end)");
			this.nudEventMinumDuration.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudEventMinumDuration.ValueChanged += new System.EventHandler(this.NudEventMinumDurationValueChanged);
			// 
			// lblEventDuration
			// 
			this.lblEventDuration.AutoSize = true;
			this.tlpProperties.SetColumnSpan(this.lblEventDuration, 2);
			this.lblEventDuration.Enabled = false;
			this.lblEventDuration.Location = new System.Drawing.Point(44, 241);
			this.lblEventDuration.Name = "lblEventDuration";
			this.lblEventDuration.Size = new System.Drawing.Size(129, 13);
			this.lblEventDuration.TabIndex = 15;
			this.lblEventDuration.Text = "Event Duration (Seconds)";
			// 
			// nudEventDuration
			// 
			this.nudEventDuration.Enabled = false;
			this.nudEventDuration.Location = new System.Drawing.Point(64, 257);
			this.nudEventDuration.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.nudEventDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudEventDuration.Name = "nudEventDuration";
			this.nudEventDuration.Size = new System.Drawing.Size(64, 20);
			this.nudEventDuration.TabIndex = 16;
			this.toolTip1.SetToolTip(this.nudEventDuration, "Generate event when subject stays in region for specified amount of time.");
			this.nudEventDuration.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudEventDuration.ValueChanged += new System.EventHandler(this.NudEventDurationValueChanged);
			// 
			// btnDeleteTrigger
			// 
			this.btnDeleteTrigger.AutoSize = true;
			this.btnDeleteTrigger.FlatAppearance.BorderSize = 0;
			this.btnDeleteTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeleteTrigger.Image = global::Neurotec.Samples.Properties.Resources.Delete;
			this.btnDeleteTrigger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDeleteTrigger.Location = new System.Drawing.Point(3, 104);
			this.btnDeleteTrigger.Name = "btnDeleteTrigger";
			this.btnDeleteTrigger.Size = new System.Drawing.Size(24, 24);
			this.btnDeleteTrigger.TabIndex = 11;
			this.btnDeleteTrigger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnDeleteTrigger, "Delete Trigger");
			this.btnDeleteTrigger.UseVisualStyleBackColor = true;
			this.btnDeleteTrigger.Click += new System.EventHandler(this.BtnDeleteTriggerClick);
			// 
			// btnSearchAreas
			// 
			this.btnSearchAreas.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSearchAreas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSearchAreas.FlatAppearance.BorderSize = 0;
			this.btnSearchAreas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchAreas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearchAreas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnSearchAreas.Location = new System.Drawing.Point(3, 259);
			this.btnSearchAreas.Name = "btnSearchAreas";
			this.btnSearchAreas.Size = new System.Drawing.Size(208, 23);
			this.btnSearchAreas.TabIndex = 7;
			this.btnSearchAreas.Text = "Search Areas ?";
			this.btnSearchAreas.UseVisualStyleBackColor = false;
			this.btnSearchAreas.Click += new System.EventHandler(this.BtnSearchAreasClick);
			// 
			// btnTriggers
			// 
			this.btnTriggers.BackColor = System.Drawing.SystemColors.Highlight;
			this.btnTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnTriggers.FlatAppearance.BorderSize = 0;
			this.btnTriggers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTriggers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTriggers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnTriggers.Location = new System.Drawing.Point(3, 3);
			this.btnTriggers.Name = "btnTriggers";
			this.btnTriggers.Size = new System.Drawing.Size(208, 27);
			this.btnTriggers.TabIndex = 8;
			this.btnTriggers.Text = "Analytic Triggers ?";
			this.btnTriggers.UseVisualStyleBackColor = false;
			this.btnTriggers.Click += new System.EventHandler(this.BtnTriggersClick);
			// 
			// tlpGeneral
			// 
			this.tlpGeneral.ColumnCount = 1;
			this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpGeneral.Controls.Add(this.groupBox2, 0, 1);
			this.tlpGeneral.Controls.Add(this.groupBox1, 0, 0);
			this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpGeneral.Location = new System.Drawing.Point(3, 544);
			this.tlpGeneral.Name = "tlpGeneral";
			this.tlpGeneral.RowCount = 3;
			this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpGeneral.Size = new System.Drawing.Size(208, 124);
			this.tlpGeneral.TabIndex = 11;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbFormats);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 58);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(202, 49);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Format";
			// 
			// cbFormats
			// 
			this.cbFormats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFormats.FormattingEnabled = true;
			this.cbFormats.Location = new System.Drawing.Point(3, 16);
			this.cbFormats.Name = "cbFormats";
			this.cbFormats.Size = new System.Drawing.Size(196, 21);
			this.cbFormats.TabIndex = 0;
			this.cbFormats.SelectedIndexChanged += new System.EventHandler(this.CbFormatsSelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbPreset);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(202, 49);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings Preset";
			// 
			// cbPreset
			// 
			this.cbPreset.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPreset.FormattingEnabled = true;
			this.cbPreset.Location = new System.Drawing.Point(3, 16);
			this.cbPreset.Name = "cbPreset";
			this.cbPreset.Size = new System.Drawing.Size(196, 21);
			this.cbPreset.TabIndex = 0;
			// 
			// SourceConfigurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1088, 756);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "SourceConfigurationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configure source settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectRegionOfInterestFormClosing);
			this.Shown += new System.EventHandler(this.SelectRegionOfInterestFormShown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tlpTools.ResumeLayout(false);
			this.tlpAreas.ResumeLayout(false);
			this.tlpAreas.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tlpTriggers.ResumeLayout(false);
			this.tlpTriggers.PerformLayout();
			this.toolStripTriggerTools.ResumeLayout(false);
			this.toolStripTriggerTools.PerformLayout();
			this.tlpProperties.ResumeLayout(false);
			this.tlpProperties.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudEventMinumDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEventDuration)).EndInit();
			this.tlpGeneral.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblHint;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rbToolRegions;
		private System.Windows.Forms.TableLayoutPanel tlpAreas;
		private System.Windows.Forms.RadioButton rbGridTool;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudRows;
		private System.Windows.Forms.NumericUpDown nudColumns;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbIncludeRect;
		private System.Windows.Forms.ToolStripButton tsbExcludeRect;
		private System.Windows.Forms.ToolStripButton tsbIncludePolygon;
		private System.Windows.Forms.ToolStripButton tsbExcludePolygon;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnUndo;
		private Neurotec.Samples.Forms.DoubleBufferedPanel panelImage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chbAreaByCenter;
		private System.Windows.Forms.TableLayoutPanel tlpTools;
		private System.Windows.Forms.Button btnSearchAreas;
		private System.Windows.Forms.Button btnTriggers;
		private System.Windows.Forms.TableLayoutPanel tlpTriggers;
		private System.Windows.Forms.ToolStrip toolStripTriggerTools;
		private System.Windows.Forms.ToolStripButton tsbNewTripwire;
		private System.Windows.Forms.ToolStripButton tsbNewRegion;
		private Neurotec.Samples.Forms.DoubleBufferedPanel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListView lvTriggers;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label lblProperties;
		private System.Windows.Forms.TableLayoutPanel tlpProperties;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbOrigin;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnSelectColor;
		private System.Windows.Forms.Button btnDeleteTrigger;
		private System.Windows.Forms.ToolStripButton tsbNewRegionRect;
		private System.Windows.Forms.Button btnGeneral;
		private System.Windows.Forms.TableLayoutPanel tlpGeneral;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbPreset;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbFormats;
		private System.Windows.Forms.Button btnInvertTripwire;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chbEventAppeared;
		private System.Windows.Forms.CheckBox chbEventIn;
		private System.Windows.Forms.CheckBox chbEventOut;
		private System.Windows.Forms.CheckBox chbEventDisappeared;
		private System.Windows.Forms.CheckBox chbEventTimer;
		private System.Windows.Forms.NumericUpDown nudEventMinumDuration;
		private System.Windows.Forms.Label lblEventMinDuration;
		private System.Windows.Forms.Label lblEventDuration;
		private System.Windows.Forms.NumericUpDown nudEventDuration;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}
