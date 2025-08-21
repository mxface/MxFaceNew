namespace Neurotec.Samples.Forms
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			Neurotec.Samples.Config.Filter filter1 = new Neurotec.Samples.Config.Filter();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnEnroll = new System.Windows.Forms.Button();
			this.btnRotate = new System.Windows.Forms.Button();
			this.btnDetailFilter = new System.Windows.Forms.Button();
			this.btnFilter = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsbHideSources = new System.Windows.Forms.ToolStripButton();
			this.tsbShowSources = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbConnect = new System.Windows.Forms.ToolStripButton();
			this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparatorConnect = new System.Windows.Forms.ToolStripSeparator();
			this.toolLayout = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbHideDetails = new System.Windows.Forms.ToolStripButton();
			this.tsbShowDetails = new System.Windows.Forms.ToolStripButton();
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optimizeModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.watchlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.facesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enrollFromImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enrollFromDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.licensePlatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.sourcesPanel = new Neurotec.Samples.Forms.SourcesPanel();
			this.splitContainerHorizontal = new System.Windows.Forms.SplitContainer();
			this.splitContainerVertical = new System.Windows.Forms.SplitContainer();
			this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
			this.detailsView = new Neurotec.Samples.Forms.DetailsView();
			this.splitContainerViewAndDetails = new System.Windows.Forms.SplitContainer();
			this.expandPanel = new System.Windows.Forms.Panel();
			this.btnMinimize = new System.Windows.Forms.Button();
			this.viewsPanel = new Neurotec.Samples.Forms.ViewsPanel();
			this.tlpSubjects = new System.Windows.Forms.TableLayoutPanel();
			this.subjectsView = new Neurotec.Samples.Forms.SubjectsView();
			this.btnClear = new System.Windows.Forms.Button();
			this.chbAutoScroll = new System.Windows.Forms.CheckBox();
			this.lblFilter = new System.Windows.Forms.Label();
			this.tlpFilterButtons = new System.Windows.Forms.TableLayoutPanel();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tlpMain.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.mainMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).BeginInit();
			this.splitContainerHorizontal.Panel1.SuspendLayout();
			this.splitContainerHorizontal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).BeginInit();
			this.splitContainerVertical.Panel1.SuspendLayout();
			this.splitContainerVertical.Panel2.SuspendLayout();
			this.splitContainerVertical.SuspendLayout();
			this.tlpCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerViewAndDetails)).BeginInit();
			this.splitContainerViewAndDetails.Panel1.SuspendLayout();
			this.splitContainerViewAndDetails.Panel2.SuspendLayout();
			this.splitContainerViewAndDetails.SuspendLayout();
			this.expandPanel.SuspendLayout();
			this.tlpSubjects.SuspendLayout();
			this.tlpFilterButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 100;
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// btnEnroll
			// 
			this.btnEnroll.Enabled = false;
			this.btnEnroll.Location = new System.Drawing.Point(3, 3);
			this.btnEnroll.Name = "btnEnroll";
			this.btnEnroll.Size = new System.Drawing.Size(60, 23);
			this.btnEnroll.TabIndex = 12;
			this.btnEnroll.Text = "Enroll";
			this.toolTip1.SetToolTip(this.btnEnroll, "Enroll selected subject to watchlist");
			this.btnEnroll.UseVisualStyleBackColor = true;
			this.btnEnroll.Click += new System.EventHandler(this.BtnEnrollClick);
			// 
			// btnRotate
			// 
			this.btnRotate.BackgroundImage = global::Neurotec.Samples.Properties.Resources.rotate;
			this.btnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRotate.Location = new System.Drawing.Point(239, 3);
			this.btnRotate.Name = "btnRotate";
			this.btnRotate.Size = new System.Drawing.Size(26, 23);
			this.btnRotate.TabIndex = 11;
			this.toolTip1.SetToolTip(this.btnRotate, "Rotate view");
			this.btnRotate.UseVisualStyleBackColor = true;
			this.btnRotate.Click += new System.EventHandler(this.BtnRotateClick);
			// 
			// btnDetailFilter
			// 
			this.btnDetailFilter.AutoSize = true;
			this.btnDetailFilter.Image = global::Neurotec.Samples.Properties.Resources.SubjectVisualization;
			this.btnDetailFilter.Location = new System.Drawing.Point(3, 3);
			this.btnDetailFilter.Name = "btnDetailFilter";
			this.btnDetailFilter.Size = new System.Drawing.Size(23, 23);
			this.btnDetailFilter.TabIndex = 12;
			this.toolTip1.SetToolTip(this.btnDetailFilter, "Select shown details");
			this.btnDetailFilter.UseVisualStyleBackColor = true;
			this.btnDetailFilter.Click += new System.EventHandler(this.BtnFilterDetailsClick);
			// 
			// btnFilter
			// 
			this.btnFilter.Image = global::Neurotec.Samples.Properties.Resources.Filter;
			this.btnFilter.Location = new System.Drawing.Point(32, 3);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(23, 23);
			this.btnFilter.TabIndex = 9;
			this.toolTip1.SetToolTip(this.btnFilter, "Select which subjects to show");
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.BtnFilterClick);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "All files|*.*";
			this.openFileDialog.Multiselect = true;
			this.openFileDialog.Title = "Select image(s)";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 522);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.toolStrip2, 0, 1);
			this.tlpMain.Controls.Add(this.mainMenuStrip, 0, 0);
			this.tlpMain.Controls.Add(this.mainSplitContainer, 0, 2);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 4;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(1171, 668);
			this.tlpMain.TabIndex = 6;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideSources,
            this.tsbShowSources,
            this.toolStripSeparator5,
            this.tsbConnect,
            this.tsbDisconnect,
            this.tsbAdd,
            this.tsbRemove,
            this.toolStripSeparatorConnect,
            this.toolLayout,
            this.toolStripSeparator6,
            this.tsbHideDetails,
            this.tsbShowDetails});
			this.toolStrip2.Location = new System.Drawing.Point(0, 27);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(1171, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsbHideSources
			// 
			this.tsbHideSources.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbHideSources.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.tsbHideSources.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideSources.Image")));
			this.tsbHideSources.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbHideSources.Name = "tsbHideSources";
			this.tsbHideSources.Size = new System.Drawing.Size(99, 22);
			this.tsbHideSources.Text = "<< Hide Sources";
			this.tsbHideSources.Click += new System.EventHandler(this.TsbHideSourcesClick);
			// 
			// tsbShowSources
			// 
			this.tsbShowSources.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbShowSources.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.tsbShowSources.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowSources.Image")));
			this.tsbShowSources.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbShowSources.Name = "tsbShowSources";
			this.tsbShowSources.Size = new System.Drawing.Size(108, 22);
			this.tsbShowSources.Text = ">> Show Sources";
			this.tsbShowSources.Click += new System.EventHandler(this.TsbShowSourcesClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbConnect
			// 
			this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
			this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbConnect.Name = "tsbConnect";
			this.tsbConnect.Size = new System.Drawing.Size(65, 22);
			this.tsbConnect.Text = "Connect ..";
			this.tsbConnect.Click += new System.EventHandler(this.TsbConnectClick);
			// 
			// tsbDisconnect
			// 
			this.tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisconnect.Image")));
			this.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDisconnect.Name = "tsbDisconnect";
			this.tsbDisconnect.Size = new System.Drawing.Size(70, 22);
			this.tsbDisconnect.Text = "Disconnect";
			this.tsbDisconnect.Click += new System.EventHandler(this.TsbDisconnectClick);
			// 
			// tsbAdd
			// 
			this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(75, 22);
			this.tsbAdd.Text = "Add Video ..";
			this.tsbAdd.Click += new System.EventHandler(this.TsbAddClick);
			// 
			// tsbRemove
			// 
			this.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemove.Image")));
			this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRemove.Name = "tsbRemove";
			this.tsbRemove.Size = new System.Drawing.Size(54, 22);
			this.tsbRemove.Text = "Remove";
			this.tsbRemove.Click += new System.EventHandler(this.TsbRemoveClick);
			// 
			// toolStripSeparatorConnect
			// 
			this.toolStripSeparatorConnect.Name = "toolStripSeparatorConnect";
			this.toolStripSeparatorConnect.Size = new System.Drawing.Size(6, 25);
			// 
			// toolLayout
			// 
			this.toolLayout.Image = global::Neurotec.Samples.Properties.Resources.Layout1_1x1;
			this.toolLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolLayout.Name = "toolLayout";
			this.toolLayout.Size = new System.Drawing.Size(72, 22);
			this.toolLayout.Text = "Layout";
			this.toolLayout.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolLayoutDropDownItemClicked);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbHideDetails
			// 
			this.tsbHideDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbHideDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.tsbHideDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideDetails.Image")));
			this.tsbHideDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbHideDetails.Name = "tsbHideDetails";
			this.tsbHideDetails.Size = new System.Drawing.Size(114, 22);
			this.tsbHideDetails.Text = "Hide subject details";
			this.tsbHideDetails.Click += new System.EventHandler(this.TsbHideDetailsClick);
			// 
			// tsbShowDetails
			// 
			this.tsbShowDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbShowDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.tsbShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowDetails.Image")));
			this.tsbShowDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbShowDetails.Name = "tsbShowDetails";
			this.tsbShowDetails.Size = new System.Drawing.Size(124, 22);
			this.tsbShowDetails.Text = "Show subject details";
			this.tsbShowDetails.Click += new System.EventHandler(this.TsbShowDetailsClick);
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.watchlistsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(1171, 27);
			this.mainMenuStrip.TabIndex = 2;
			this.mainMenuStrip.Text = "Main";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.optimizeModelsToolStripMenuItem,
            this.exportEventsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.settingsToolStripMenuItem.Text = "&Settings...";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItemClick);
			// 
			// optimizeModelsToolStripMenuItem
			// 
			this.optimizeModelsToolStripMenuItem.Name = "optimizeModelsToolStripMenuItem";
			this.optimizeModelsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.optimizeModelsToolStripMenuItem.Text = "&Optimize Models";
			this.optimizeModelsToolStripMenuItem.Click += new System.EventHandler(this.OptimizeModelsToolStripMenuItemClick);
			// 
			// exportEventsToolStripMenuItem
			// 
			this.exportEventsToolStripMenuItem.Name = "exportEventsToolStripMenuItem";
			this.exportEventsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.exportEventsToolStripMenuItem.Text = "&Export Events";
			this.exportEventsToolStripMenuItem.Click += new System.EventHandler(this.ExportEventsToolStripMenuItemClick);
			// 
			// watchlistsToolStripMenuItem
			// 
			this.watchlistsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facesToolStripMenuItem,
            this.enrollFromImagesToolStripMenuItem,
            this.enrollFromDirectoryToolStripMenuItem,
            this.toolStripSeparator7,
            this.licensePlatesToolStripMenuItem});
			this.watchlistsToolStripMenuItem.Name = "watchlistsToolStripMenuItem";
			this.watchlistsToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
			this.watchlistsToolStripMenuItem.Text = "&Watchlists";
			// 
			// facesToolStripMenuItem
			// 
			this.facesToolStripMenuItem.Name = "facesToolStripMenuItem";
			this.facesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.facesToolStripMenuItem.Text = "&Faces";
			this.facesToolStripMenuItem.Click += new System.EventHandler(this.FacesToolStripMenuItemClick);
			// 
			// enrollFromImagesToolStripMenuItem
			// 
			this.enrollFromImagesToolStripMenuItem.Name = "enrollFromImagesToolStripMenuItem";
			this.enrollFromImagesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.enrollFromImagesToolStripMenuItem.Text = "&Enroll from Images";
			this.enrollFromImagesToolStripMenuItem.Click += new System.EventHandler(this.EnrollFromImagesToolStripMenuItemClick);
			// 
			// enrollFromDirectoryToolStripMenuItem
			// 
			this.enrollFromDirectoryToolStripMenuItem.Name = "enrollFromDirectoryToolStripMenuItem";
			this.enrollFromDirectoryToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.enrollFromDirectoryToolStripMenuItem.Text = "Enroll from &Directory";
			this.enrollFromDirectoryToolStripMenuItem.Click += new System.EventHandler(this.EnrollFromDirectoryToolStripMenuItemClick);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(181, 6);
			// 
			// licensePlatesToolStripMenuItem
			// 
			this.licensePlatesToolStripMenuItem.Name = "licensePlatesToolStripMenuItem";
			this.licensePlatesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.licensePlatesToolStripMenuItem.Text = "&License Plates";
			this.licensePlatesToolStripMenuItem.Click += new System.EventHandler(this.LicensePlatesToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.mainSplitContainer.Location = new System.Drawing.Point(3, 55);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.sourcesPanel);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.splitContainerHorizontal);
			this.mainSplitContainer.Size = new System.Drawing.Size(1165, 610);
			this.mainSplitContainer.SplitterDistance = 290;
			this.mainSplitContainer.TabIndex = 5;
			// 
			// sourcesPanel
			// 
			this.sourcesPanel.AutoScroll = true;
			this.sourcesPanel.BackColor = System.Drawing.Color.White;
			this.sourcesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sourcesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sourcesPanel.Location = new System.Drawing.Point(0, 0);
			this.sourcesPanel.Name = "sourcesPanel";
			this.sourcesPanel.Size = new System.Drawing.Size(290, 610);
			this.sourcesPanel.TabIndex = 1;
			// 
			// splitContainerHorizontal
			// 
			this.splitContainerHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerHorizontal.Location = new System.Drawing.Point(0, 0);
			this.splitContainerHorizontal.Name = "splitContainerHorizontal";
			this.splitContainerHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerHorizontal.Panel1
			// 
			this.splitContainerHorizontal.Panel1.Controls.Add(this.splitContainerVertical);
			this.splitContainerHorizontal.Size = new System.Drawing.Size(871, 610);
			this.splitContainerHorizontal.SplitterDistance = 302;
			this.splitContainerHorizontal.TabIndex = 5;
			// 
			// splitContainerVertical
			// 
			this.splitContainerVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainerVertical.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerVertical.Location = new System.Drawing.Point(0, 0);
			this.splitContainerVertical.Name = "splitContainerVertical";
			// 
			// splitContainerVertical.Panel1
			// 
			this.splitContainerVertical.Panel1.Controls.Add(this.tlpCenter);
			this.splitContainerVertical.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerVertical.Panel1MinSize = 100;
			// 
			// splitContainerVertical.Panel2
			// 
			this.splitContainerVertical.Panel2.BackColor = System.Drawing.Color.White;
			this.splitContainerVertical.Panel2.Controls.Add(this.tlpSubjects);
			this.splitContainerVertical.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerVertical.Panel2MinSize = 260;
			this.splitContainerVertical.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainerVertical.Size = new System.Drawing.Size(871, 302);
			this.splitContainerVertical.SplitterDistance = 597;
			this.splitContainerVertical.TabIndex = 4;
			this.splitContainerVertical.TabStop = false;
			// 
			// tlpCenter
			// 
			this.tlpCenter.ColumnCount = 2;
			this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
			this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpCenter.Controls.Add(this.detailsView, 1, 0);
			this.tlpCenter.Controls.Add(this.splitContainerViewAndDetails, 0, 0);
			this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCenter.Location = new System.Drawing.Point(0, 0);
			this.tlpCenter.Name = "tlpCenter";
			this.tlpCenter.RowCount = 1;
			this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCenter.Size = new System.Drawing.Size(595, 300);
			this.tlpCenter.TabIndex = 3;
			// 
			// detailsView
			// 
			this.detailsView.AnalyticEventMode = Neurotec.Samples.Forms.DetailsView.EventSelectionMode.Link;
			this.detailsView.AnalyticEventsShowBest = false;
			this.detailsView.AutoScroll = true;
			this.detailsView.BackColor = System.Drawing.Color.White;
			this.detailsView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailsView.Filter = Neurotec.Samples.Forms.DetailsView.DetailsType.None;
			this.detailsView.Info = null;
			this.detailsView.Location = new System.Drawing.Point(368, 3);
			this.detailsView.Name = "detailsView";
			this.detailsView.Size = new System.Drawing.Size(224, 294);
			this.detailsView.TabIndex = 7;
			this.detailsView.ShowTriggerDetails += new System.EventHandler<Neurotec.Samples.Forms.DetailsView.ShowArgs>(this.DetailsViewShowTriggerDetails);
			// 
			// splitContainerViewAndDetails
			// 
			this.splitContainerViewAndDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerViewAndDetails.Location = new System.Drawing.Point(3, 3);
			this.splitContainerViewAndDetails.Name = "splitContainerViewAndDetails";
			// 
			// splitContainerViewAndDetails.Panel1
			// 
			this.splitContainerViewAndDetails.Panel1.Controls.Add(this.expandPanel);
			this.splitContainerViewAndDetails.Panel1Collapsed = true;
			// 
			// splitContainerViewAndDetails.Panel2
			// 
			this.splitContainerViewAndDetails.Panel2.Controls.Add(this.viewsPanel);
			this.splitContainerViewAndDetails.Size = new System.Drawing.Size(359, 294);
			this.splitContainerViewAndDetails.SplitterDistance = 119;
			this.splitContainerViewAndDetails.TabIndex = 8;
			// 
			// expandPanel
			// 
			this.expandPanel.Controls.Add(this.btnMinimize);
			this.expandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.expandPanel.Location = new System.Drawing.Point(0, 0);
			this.expandPanel.Name = "expandPanel";
			this.expandPanel.Size = new System.Drawing.Size(119, 100);
			this.expandPanel.TabIndex = 1;
			// 
			// btnMinimize
			// 
			this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMinimize.Image = global::Neurotec.Samples.Properties.Resources.ExitFullScreen;
			this.btnMinimize.Location = new System.Drawing.Point(87, 0);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new System.Drawing.Size(32, 32);
			this.btnMinimize.TabIndex = 0;
			this.btnMinimize.UseVisualStyleBackColor = true;
			this.btnMinimize.Click += new System.EventHandler(this.BtnMinimizeClick);
			// 
			// viewsPanel
			// 
			this.viewsPanel.AllowDrop = true;
			this.viewsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.viewsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewsPanel.Location = new System.Drawing.Point(0, 0);
			this.viewsPanel.Name = "viewsPanel";
			this.viewsPanel.Size = new System.Drawing.Size(359, 294);
			this.viewsPanel.TabIndex = 3;
			this.viewsPanel.ViewsLayout = null;
			// 
			// tlpSubjects
			// 
			this.tlpSubjects.BackColor = System.Drawing.Color.White;
			this.tlpSubjects.ColumnCount = 6;
			this.tlpSubjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSubjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSubjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSubjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSubjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSubjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSubjects.Controls.Add(this.subjectsView, 0, 2);
			this.tlpSubjects.Controls.Add(this.btnClear, 1, 0);
			this.tlpSubjects.Controls.Add(this.chbAutoScroll, 2, 0);
			this.tlpSubjects.Controls.Add(this.lblFilter, 1, 1);
			this.tlpSubjects.Controls.Add(this.btnRotate, 5, 0);
			this.tlpSubjects.Controls.Add(this.btnEnroll, 0, 0);
			this.tlpSubjects.Controls.Add(this.tlpFilterButtons, 0, 1);
			this.tlpSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpSubjects.Location = new System.Drawing.Point(0, 0);
			this.tlpSubjects.Name = "tlpSubjects";
			this.tlpSubjects.RowCount = 3;
			this.tlpSubjects.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSubjects.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSubjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSubjects.Size = new System.Drawing.Size(268, 300);
			this.tlpSubjects.TabIndex = 6;
			// 
			// subjectsView
			// 
			this.subjectsView.AutoScroll = true;
			this.subjectsView.AutoScrollMinSize = new System.Drawing.Size(238, 0);
			this.subjectsView.AutoScrollToEnd = true;
			this.subjectsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tlpSubjects.SetColumnSpan(this.subjectsView, 6);
			this.subjectsView.Dock = System.Windows.Forms.DockStyle.Fill;
			filter1.Color = Neurotec.Surveillance.NSurveillanceObjectColor.None;
			filter1.ColorConfidence = 0.5F;
			filter1.Direction = Neurotec.Surveillance.NSurveillanceObjectDirection.None;
			filter1.DirectionConfidence = 0.3F;
			filter1.MustHaveFace = false;
			filter1.MustHaveLicensePlate = false;
			filter1.Type = Neurotec.Surveillance.NSurveillanceObjectType.None;
			filter1.TypeConfidence = 0.5F;
			filter1.WatchlistFilter = null;
			this.subjectsView.Filter = filter1;
			this.subjectsView.HorizontalSize = 250;
			this.subjectsView.Location = new System.Drawing.Point(3, 62);
			this.subjectsView.MaxImageHeight = 60;
			this.subjectsView.MaxLicensePlateHeight = 35;
			this.subjectsView.MaxNodes = 100;
			this.subjectsView.Name = "subjectsView";
			this.subjectsView.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.subjectsView.Size = new System.Drawing.Size(262, 235);
			this.subjectsView.SubjectsMargin = 5;
			this.subjectsView.TabIndex = 7;
			this.subjectsView.SubjectDoubleClick += new System.EventHandler<Neurotec.Samples.Code.SubjectInfo>(this.SubjectsViewDoubleClick);
			this.subjectsView.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.SubjectsViewPropertyChanged);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(69, 3);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(60, 23);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearInactiveClick);
			// 
			// chbAutoScroll
			// 
			this.chbAutoScroll.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chbAutoScroll.AutoSize = true;
			this.chbAutoScroll.Checked = true;
			this.chbAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbAutoScroll.Location = new System.Drawing.Point(135, 6);
			this.chbAutoScroll.Name = "chbAutoScroll";
			this.chbAutoScroll.Size = new System.Drawing.Size(77, 17);
			this.chbAutoScroll.TabIndex = 8;
			this.chbAutoScroll.Text = "Auto Scroll";
			this.chbAutoScroll.UseVisualStyleBackColor = true;
			this.chbAutoScroll.CheckedChanged += new System.EventHandler(this.ChbAutoScrollCheckedChanged);
			// 
			// lblFilter
			// 
			this.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblFilter.AutoSize = true;
			this.tlpSubjects.SetColumnSpan(this.lblFilter, 5);
			this.lblFilter.Location = new System.Drawing.Point(69, 37);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(33, 13);
			this.lblFilter.TabIndex = 10;
			this.lblFilter.Text = "None";
			this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tlpFilterButtons
			// 
			this.tlpFilterButtons.ColumnCount = 2;
			this.tlpFilterButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpFilterButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpFilterButtons.Controls.Add(this.btnDetailFilter, 0, 0);
			this.tlpFilterButtons.Controls.Add(this.btnFilter, 1, 0);
			this.tlpFilterButtons.Location = new System.Drawing.Point(0, 29);
			this.tlpFilterButtons.Margin = new System.Windows.Forms.Padding(0);
			this.tlpFilterButtons.Name = "tlpFilterButtons";
			this.tlpFilterButtons.RowCount = 1;
			this.tlpFilterButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpFilterButtons.Size = new System.Drawing.Size(60, 30);
			this.tlpFilterButtons.TabIndex = 13;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1171, 668);
			this.Controls.Add(this.tlpMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(480, 320);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Surveillance Sample";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.splitContainerHorizontal.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).EndInit();
			this.splitContainerHorizontal.ResumeLayout(false);
			this.splitContainerVertical.Panel1.ResumeLayout(false);
			this.splitContainerVertical.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).EndInit();
			this.splitContainerVertical.ResumeLayout(false);
			this.tlpCenter.ResumeLayout(false);
			this.splitContainerViewAndDetails.Panel1.ResumeLayout(false);
			this.splitContainerViewAndDetails.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerViewAndDetails)).EndInit();
			this.splitContainerViewAndDetails.ResumeLayout(false);
			this.expandPanel.ResumeLayout(false);
			this.tlpSubjects.ResumeLayout(false);
			this.tlpSubjects.PerformLayout();
			this.tlpFilterButtons.ResumeLayout(false);
			this.tlpFilterButtons.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private SourcesPanel sourcesPanel;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton tsbHideSources;
		private System.Windows.Forms.ToolStripButton tsbShowSources;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbConnect;
		private System.Windows.Forms.ToolStripButton tsbAdd;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportEventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparatorConnect;
		private System.Windows.Forms.SplitContainer splitContainerVertical;
		private System.Windows.Forms.TableLayoutPanel tlpSubjects;
		private SubjectsView subjectsView;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.CheckBox chbAutoScroll;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.Button btnDetailFilter;
		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.Button btnRotate;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private DetailsView detailsView;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton tsbHideDetails;
		private System.Windows.Forms.ToolStripButton tsbShowDetails;
		private System.Windows.Forms.TableLayoutPanel tlpCenter;
		private System.Windows.Forms.Button btnEnroll;
		private System.Windows.Forms.ToolStripMenuItem optimizeModelsToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tlpFilterButtons;
		private ViewsPanel viewsPanel;
		public System.Windows.Forms.SplitContainer splitContainerViewAndDetails;
		public System.Windows.Forms.ToolStripDropDownButton toolLayout;
		public System.Windows.Forms.ToolStripButton tsbRemove;
		public System.Windows.Forms.ToolStripButton tsbDisconnect;
		private System.Windows.Forms.Button btnMinimize;
		public System.Windows.Forms.Panel expandPanel;
		private System.Windows.Forms.SplitContainer splitContainerHorizontal;
		private System.Windows.Forms.ToolStripMenuItem watchlistsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem facesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enrollFromImagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enrollFromDirectoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem licensePlatesToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList1;
	}
}
