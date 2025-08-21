namespace Neurotec.Samples.Forms
{
	partial class OptimizationDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptimizationDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tlpModalities = new System.Windows.Forms.TableLayoutPanel();
			this.chbLpr = new System.Windows.Forms.CheckBox();
			this.chbVh = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chbFaces = new System.Windows.Forms.CheckBox();
			this.chbLowMemory = new System.Windows.Forms.CheckBox();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnOptimize = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblProgress = new System.Windows.Forms.Label();
			this.tlpModalities.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
			this.label1.Location = new System.Drawing.Point(23, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(494, 39);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// label2
			// 
			this.label2.Image = global::Neurotec.Samples.Properties.Resources.Help;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 24);
			this.label2.TabIndex = 1;
			// 
			// tlpModalities
			// 
			this.tlpModalities.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tlpModalities, 4);
			this.tlpModalities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpModalities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpModalities.Controls.Add(this.chbLpr, 1, 3);
			this.tlpModalities.Controls.Add(this.chbVh, 1, 2);
			this.tlpModalities.Controls.Add(this.label3, 0, 0);
			this.tlpModalities.Controls.Add(this.chbFaces, 1, 1);
			this.tlpModalities.Location = new System.Drawing.Point(3, 42);
			this.tlpModalities.Name = "tlpModalities";
			this.tlpModalities.RowCount = 5;
			this.tlpModalities.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpModalities.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpModalities.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpModalities.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpModalities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpModalities.Size = new System.Drawing.Size(270, 86);
			this.tlpModalities.TabIndex = 2;
			// 
			// chbLpr
			// 
			this.chbLpr.AutoSize = true;
			this.chbLpr.Location = new System.Drawing.Point(23, 62);
			this.chbLpr.Name = "chbLpr";
			this.chbLpr.Size = new System.Drawing.Size(150, 17);
			this.chbLpr.TabIndex = 3;
			this.chbLpr.Text = "License Plate Recognition";
			this.chbLpr.UseVisualStyleBackColor = true;
			this.chbLpr.CheckedChanged += new System.EventHandler(this.ChbLprCheckedChanged);
			// 
			// chbVh
			// 
			this.chbVh.AutoSize = true;
			this.chbVh.Location = new System.Drawing.Point(23, 39);
			this.chbVh.Name = "chbVh";
			this.chbVh.Size = new System.Drawing.Size(98, 17);
			this.chbVh.TabIndex = 2;
			this.chbVh.Text = "Vehicle Human";
			this.chbVh.UseVisualStyleBackColor = true;
			this.chbVh.CheckedChanged += new System.EventHandler(this.ChbVhCheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.tlpModalities.SetColumnSpan(this.label3, 2);
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Modalities";
			// 
			// chbFaces
			// 
			this.chbFaces.AutoSize = true;
			this.chbFaces.Location = new System.Drawing.Point(23, 16);
			this.chbFaces.Name = "chbFaces";
			this.chbFaces.Size = new System.Drawing.Size(55, 17);
			this.chbFaces.TabIndex = 1;
			this.chbFaces.Text = "Faces";
			this.chbFaces.UseVisualStyleBackColor = true;
			this.chbFaces.CheckedChanged += new System.EventHandler(this.ChbFacesCheckedChanged);
			// 
			// chbLowMemory
			// 
			this.chbLowMemory.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.chbLowMemory, 3);
			this.chbLowMemory.Location = new System.Drawing.Point(23, 157);
			this.chbLowMemory.Name = "chbLowMemory";
			this.chbLowMemory.Size = new System.Drawing.Size(133, 17);
			this.chbLowMemory.TabIndex = 4;
			this.chbLowMemory.Text = "Gpu low memory mode";
			this.chbLowMemory.UseVisualStyleBackColor = true;
			// 
			// rbAll
			// 
			this.rbAll.AutoSize = true;
			this.rbAll.Checked = true;
			this.tableLayoutPanel1.SetColumnSpan(this.rbAll, 2);
			this.rbAll.Location = new System.Drawing.Point(3, 134);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(75, 17);
			this.rbAll.TabIndex = 3;
			this.rbAll.TabStop = true;
			this.rbAll.Text = "All settings";
			this.rbAll.UseVisualStyleBackColor = true;
			this.rbAll.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.radioButton2, 2);
			this.radioButton2.Location = new System.Drawing.Point(3, 180);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(106, 17);
			this.radioButton2.TabIndex = 4;
			this.radioButton2.Text = "Selected settings";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
			// 
			// pbProgress
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.pbProgress, 4);
			this.pbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbProgress.Location = new System.Drawing.Point(3, 218);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(601, 23);
			this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbProgress.TabIndex = 5;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.btnOptimize, 2, 9);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 9);
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.pbProgress, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.chbLowMemory, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.tlpModalities, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.radioButton2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.rbAll, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblProgress, 0, 7);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 10;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 273);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// btnOptimize
			// 
			this.btnOptimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOptimize.Location = new System.Drawing.Point(448, 247);
			this.btnOptimize.Name = "btnOptimize";
			this.btnOptimize.Size = new System.Drawing.Size(75, 23);
			this.btnOptimize.TabIndex = 7;
			this.btnOptimize.Text = "&Optimize";
			this.btnOptimize.UseVisualStyleBackColor = true;
			this.btnOptimize.Click += new System.EventHandler(this.BtnOptimizeClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(529, 247);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// lblProgress
			// 
			this.lblProgress.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblProgress, 4);
			this.lblProgress.Location = new System.Drawing.Point(3, 202);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(111, 13);
			this.lblProgress.TabIndex = 9;
			this.lblProgress.Text = "Optimization Progress:";
			// 
			// OptimizationDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(607, 273);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptimizationDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Model Optimization";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptimizationDialogFormClosing);
			this.Load += new System.EventHandler(this.OptimizationDialogLoad);
			this.tlpModalities.ResumeLayout(false);
			this.tlpModalities.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnOptimize;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ProgressBar pbProgress;
		private System.Windows.Forms.TableLayoutPanel tlpModalities;
		private System.Windows.Forms.CheckBox chbLpr;
		private System.Windows.Forms.CheckBox chbVh;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chbFaces;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.CheckBox chbLowMemory;
		private System.Windows.Forms.Label lblProgress;
	}
}
