namespace Neurotec.Samples.Forms
{
	partial class VideoForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Selected Files", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Recently Opened (Double Click to Add)", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoForm));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbFilter = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.chbPreferVlc = new System.Windows.Forms.CheckBox();
			this.lvVideos = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnReset = new System.Windows.Forms.Button();
			this.toolStripModalities = new System.Windows.Forms.ToolStrip();
			this.tsbFaces = new System.Windows.Forms.ToolStripButton();
			this.tsbObjects = new System.Windows.Forms.ToolStripButton();
			this.tsbLpr = new System.Windows.Forms.ToolStripButton();
			this.lblModalities = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tlpMain.SuspendLayout();
			this.toolStripModalities.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(910, 450);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "&OK";
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(991, 450);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Search:";
			// 
			// tbFilter
			// 
			this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpMain.SetColumnSpan(this.tbFilter, 3);
			this.tbFilter.Location = new System.Drawing.Point(53, 4);
			this.tbFilter.Name = "tbFilter";
			this.tbFilter.Size = new System.Drawing.Size(851, 20);
			this.tbFilter.TabIndex = 0;
			this.tbFilter.TextChanged += new System.EventHandler(this.TbFileNameTextChanged);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(910, 3);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "&Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "All files|*.*|AVI files|*.avi|MP4 files|*.mp4|MPEG files|*.mpeg";
			this.openFileDialog.Multiselect = true;
			this.openFileDialog.Title = "Select video files";
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 6;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.Controls.Add(this.label1, 0, 0);
			this.tlpMain.Controls.Add(this.tbFilter, 1, 0);
			this.tlpMain.Controls.Add(this.btnBrowse, 4, 0);
			this.tlpMain.Controls.Add(this.chbPreferVlc, 1, 1);
			this.tlpMain.Controls.Add(this.lvVideos, 0, 2);
			this.tlpMain.Controls.Add(this.btnReset, 5, 0);
			this.tlpMain.Controls.Add(this.btnCancel, 5, 3);
			this.tlpMain.Controls.Add(this.btnOk, 4, 3);
			this.tlpMain.Controls.Add(this.toolStripModalities, 3, 3);
			this.tlpMain.Controls.Add(this.lblModalities, 2, 3);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 4;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Size = new System.Drawing.Size(1069, 476);
			this.tlpMain.TabIndex = 12;
			// 
			// chbPreferVlc
			// 
			this.chbPreferVlc.AutoSize = true;
			this.chbPreferVlc.Location = new System.Drawing.Point(53, 32);
			this.chbPreferVlc.Name = "chbPreferVlc";
			this.chbPreferVlc.Size = new System.Drawing.Size(72, 17);
			this.chbPreferVlc.TabIndex = 3;
			this.chbPreferVlc.Text = "Prefer Vlc";
			this.toolTip.SetToolTip(this.chbPreferVlc, "Prefer to read video file using Vlc framework.");
			this.chbPreferVlc.UseVisualStyleBackColor = true;
			// 
			// lvVideos
			// 
			this.lvVideos.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvVideos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.tlpMain.SetColumnSpan(this.lvVideos, 6);
			this.lvVideos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvVideos.FullRowSelect = true;
			this.lvVideos.GridLines = true;
			listViewGroup1.Header = "Selected Files";
			listViewGroup1.Name = "lvgSelected";
			listViewGroup2.Header = "Recently Opened (Double Click to Add)";
			listViewGroup2.Name = "lvgRecent";
			this.lvVideos.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.lvVideos.HideSelection = false;
			this.lvVideos.Location = new System.Drawing.Point(3, 55);
			this.lvVideos.Name = "lvVideos";
			this.lvVideos.ShowItemToolTips = true;
			this.lvVideos.Size = new System.Drawing.Size(1063, 389);
			this.lvVideos.TabIndex = 4;
			this.lvVideos.UseCompatibleStateImageBehavior = false;
			this.lvVideos.View = System.Windows.Forms.View.Details;
			this.lvVideos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvVideosMouseDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File Name";
			this.columnHeader1.Width = 650;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Resolution";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Length";
			this.columnHeader4.Width = 100;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(991, 3);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// toolStripModalities
			// 
			this.toolStripModalities.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.toolStripModalities.BackColor = System.Drawing.Color.Transparent;
			this.toolStripModalities.CanOverflow = false;
			this.toolStripModalities.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStripModalities.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripModalities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFaces,
            this.tsbObjects,
            this.tsbLpr});
			this.toolStripModalities.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStripModalities.Location = new System.Drawing.Point(191, 450);
			this.toolStripModalities.Name = "toolStripModalities";
			this.toolStripModalities.Size = new System.Drawing.Size(221, 23);
			this.toolStripModalities.TabIndex = 15;
			this.toolStripModalities.Text = "toolStrip2";
			// 
			// tsbFaces
			// 
			this.tsbFaces.Checked = true;
			this.tsbFaces.CheckOnClick = true;
			this.tsbFaces.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbFaces.Image = global::Neurotec.Samples.Properties.Resources.face;
			this.tsbFaces.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFaces.Name = "tsbFaces";
			this.tsbFaces.Size = new System.Drawing.Size(56, 20);
			this.tsbFaces.Text = "Faces";
			this.tsbFaces.Click += new System.EventHandler(this.TsbFacesClick);
			// 
			// tsbObjects
			// 
			this.tsbObjects.Checked = true;
			this.tsbObjects.CheckOnClick = true;
			this.tsbObjects.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbObjects.Image = global::Neurotec.Samples.Properties.Resources.Objects;
			this.tsbObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbObjects.Name = "tsbObjects";
			this.tsbObjects.Size = new System.Drawing.Size(109, 20);
			this.tsbObjects.Text = "Vehicle/Human";
			this.tsbObjects.Click += new System.EventHandler(this.TsbObjectsClick);
			// 
			// tsbLpr
			// 
			this.tsbLpr.Checked = true;
			this.tsbLpr.CheckOnClick = true;
			this.tsbLpr.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbLpr.Image = global::Neurotec.Samples.Properties.Resources.LicensePlate;
			this.tsbLpr.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLpr.Name = "tsbLpr";
			this.tsbLpr.Size = new System.Drawing.Size(55, 20);
			this.tsbLpr.Text = "ALPR";
			this.tsbLpr.Click += new System.EventHandler(this.TsbLprClick);
			// 
			// lblModalities
			// 
			this.lblModalities.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblModalities.AutoSize = true;
			this.lblModalities.Location = new System.Drawing.Point(131, 455);
			this.lblModalities.Name = "lblModalities";
			this.lblModalities.Size = new System.Drawing.Size(57, 13);
			this.lblModalities.TabIndex = 16;
			this.lblModalities.Text = "Modalities:";
			// 
			// VideoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1069, 476);
			this.Controls.Add(this.tlpMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VideoForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose Video Files";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoFormFormClosing);
			this.Shown += new System.EventHandler(this.VideoFormShown);
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.toolStripModalities.ResumeLayout(false);
			this.toolStripModalities.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbFilter;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.CheckBox chbPreferVlc;
		private System.Windows.Forms.ListView lvVideos;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.ToolStrip toolStripModalities;
		private System.Windows.Forms.ToolStripButton tsbFaces;
		private System.Windows.Forms.ToolStripButton tsbObjects;
		private System.Windows.Forms.ToolStripButton tsbLpr;
		private System.Windows.Forms.Label lblModalities;
	}
}
