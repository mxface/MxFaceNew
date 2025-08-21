namespace Neurotec.Samples.Forms
{
	partial class SourceControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceControl));
			this.lblName = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbStart = new System.Windows.Forms.ToolStripButton();
			this.tsbStop = new System.Windows.Forms.ToolStripButton();
			this.tsbShow = new System.Windows.Forms.ToolStripButton();
			this.tsbReplay = new System.Windows.Forms.ToolStripButton();
			this.tsbSettings = new System.Windows.Forms.ToolStripButton();
			this.tsbChangePassword = new System.Windows.Forms.ToolStripButton();
			this.toolStripModalities = new System.Windows.Forms.ToolStrip();
			this.tsbFaces = new System.Windows.Forms.ToolStripButton();
			this.tsbObjects = new System.Windows.Forms.ToolStripButton();
			this.tsbLpr = new System.Windows.Forms.ToolStripButton();
			this.pbWarning = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblPreset = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.toolStripModalities.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(322, 13);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "SourceName";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceControlMouseDown);
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
			this.toolStrip1.CanOverflow = false;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsbStart,
            this.tsbStop,
            this.tsbShow,
            this.tsbReplay,
            this.tsbSettings,
            this.tsbChangePassword});
			this.toolStrip1.Location = new System.Drawing.Point(0, 58);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(50, 0, 0, 5);
			this.toolStrip1.Size = new System.Drawing.Size(328, 28);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceControlMouseDown);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// tsbStart
			// 
			this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
			this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStart.Name = "tsbStart";
			this.tsbStart.Size = new System.Drawing.Size(23, 20);
			this.tsbStart.ToolTipText = "Start";
			this.tsbStart.Click += new System.EventHandler(this.TsbStartClick);
			// 
			// tsbStop
			// 
			this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbStop.Image = global::Neurotec.Samples.Properties.Resources.Stop;
			this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStop.Name = "tsbStop";
			this.tsbStop.Size = new System.Drawing.Size(23, 20);
			this.tsbStop.Text = "toolStripButton2";
			this.tsbStop.ToolTipText = "Stop";
			this.tsbStop.Click += new System.EventHandler(this.TsbStopClick);
			// 
			// tsbShow
			// 
			this.tsbShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbShow.Image = global::Neurotec.Samples.Properties.Resources.Eye;
			this.tsbShow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbShow.Name = "tsbShow";
			this.tsbShow.Size = new System.Drawing.Size(23, 20);
			this.tsbShow.Text = "toolStripButton3";
			this.tsbShow.ToolTipText = "Show";
			this.tsbShow.Click += new System.EventHandler(this.TsbShowClick);
			// 
			// tsbReplay
			// 
			this.tsbReplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbReplay.Image = global::Neurotec.Samples.Properties.Resources.Replay;
			this.tsbReplay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbReplay.Name = "tsbReplay";
			this.tsbReplay.Size = new System.Drawing.Size(23, 20);
			this.tsbReplay.Text = "Replay";
			this.tsbReplay.Click += new System.EventHandler(this.TsbReplayClick);
			// 
			// tsbSettings
			// 
			this.tsbSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSettings.Image = global::Neurotec.Samples.Properties.Resources.settings;
			this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSettings.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
			this.tsbSettings.Name = "tsbSettings";
			this.tsbSettings.Size = new System.Drawing.Size(23, 20);
			this.tsbSettings.Text = "Settings";
			this.tsbSettings.Click += new System.EventHandler(this.TsbSettingsClick);
			// 
			// tsbChangePassword
			// 
			this.tsbChangePassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbChangePassword.Image = global::Neurotec.Samples.Properties.Resources.key;
			this.tsbChangePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbChangePassword.Name = "tsbChangePassword";
			this.tsbChangePassword.Size = new System.Drawing.Size(23, 20);
			this.tsbChangePassword.Text = "Change username and password";
			this.tsbChangePassword.Click += new System.EventHandler(this.TsbChangePasswordClick);
			// 
			// toolStripModalities
			// 
			this.toolStripModalities.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.toolStripModalities.BackColor = System.Drawing.Color.Transparent;
			this.toolStripModalities.CanOverflow = false;
			this.toolStripModalities.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStripModalities.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripModalities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFaces,
            this.tsbObjects,
            this.tsbLpr});
			this.toolStripModalities.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStripModalities.Location = new System.Drawing.Point(53, 0);
			this.toolStripModalities.Name = "toolStripModalities";
			this.toolStripModalities.Size = new System.Drawing.Size(221, 23);
			this.toolStripModalities.TabIndex = 9;
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
			// pbWarning
			// 
			this.pbWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pbWarning.Image = global::Neurotec.Samples.Properties.Resources.Warning;
			this.pbWarning.Location = new System.Drawing.Point(0, 63);
			this.pbWarning.Name = "pbWarning";
			this.pbWarning.Size = new System.Drawing.Size(20, 20);
			this.pbWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbWarning.TabIndex = 9;
			this.pbWarning.TabStop = false;
			this.pbWarning.Visible = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.toolStripModalities, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 24);
			this.tableLayoutPanel1.TabIndex = 11;
			this.tableLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceControlMouseDown);
			// 
			// lblPreset
			// 
			this.lblPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPreset.BackColor = System.Drawing.Color.Transparent;
			this.lblPreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPreset.Location = new System.Drawing.Point(3, 16);
			this.lblPreset.Name = "lblPreset";
			this.lblPreset.Size = new System.Drawing.Size(322, 15);
			this.lblPreset.TabIndex = 13;
			this.lblPreset.Text = "Preset: Default";
			this.lblPreset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblPreset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceControlMouseDown);
			// 
			// SourceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblPreset);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.pbWarning);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.lblName);
			this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.Name = "SourceControl";
			this.Size = new System.Drawing.Size(328, 86);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourceControlMouseDown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStripModalities.ResumeLayout(false);
			this.toolStripModalities.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbStart;
		private System.Windows.Forms.ToolStripButton tsbStop;
		private System.Windows.Forms.ToolStripButton tsbShow;
		private System.Windows.Forms.ToolStripButton tsbReplay;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStripModalities;
		private System.Windows.Forms.ToolStripButton tsbObjects;
		private System.Windows.Forms.ToolStripButton tsbLpr;
		private System.Windows.Forms.PictureBox pbWarning;
		private System.Windows.Forms.ToolStripButton tsbSettings;
		private System.Windows.Forms.ToolStripButton tsbChangePassword;
		private System.Windows.Forms.ToolStripButton tsbFaces;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblPreset;
	}
}
