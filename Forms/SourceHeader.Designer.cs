namespace Neurotec.Samples.Forms
{
	partial class SourceHeader
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.chbShowTrackLine = new System.Windows.Forms.CheckBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.chbSearchArea = new System.Windows.Forms.CheckBox();
			this.chbTriggers = new System.Windows.Forms.CheckBox();
			this.chbPin = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.chbShowTrackLine, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.chbSearchArea, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.chbTriggers, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.chbPin, 4, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 24);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// chbShowTrackLine
			// 
			this.chbShowTrackLine.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbShowTrackLine.AutoSize = true;
			this.chbShowTrackLine.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.chbShowTrackLine.Checked = true;
			this.chbShowTrackLine.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbShowTrackLine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chbShowTrackLine.FlatAppearance.BorderSize = 0;
			this.chbShowTrackLine.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.chbShowTrackLine.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
			this.chbShowTrackLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chbShowTrackLine.Image = global::Neurotec.Samples.Properties.Resources.line;
			this.chbShowTrackLine.Location = new System.Drawing.Point(273, 0);
			this.chbShowTrackLine.Margin = new System.Windows.Forms.Padding(0);
			this.chbShowTrackLine.Name = "chbShowTrackLine";
			this.chbShowTrackLine.Size = new System.Drawing.Size(114, 24);
			this.chbShowTrackLine.TabIndex = 4;
			this.chbShowTrackLine.Text = "Show Track Line";
			this.chbShowTrackLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.chbShowTrackLine, "Show Track Line (Ctrl+1)");
			this.chbShowTrackLine.UseVisualStyleBackColor = false;
			this.chbShowTrackLine.Visible = false;
			this.chbShowTrackLine.CheckedChanged += new System.EventHandler(this.ChbShowTrackLineCheckedChanged);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoEllipsis = true;
			this.lblTitle.AutoSize = true;
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.CausesValidation = false;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Location = new System.Drawing.Point(3, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(267, 24);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitleMouseDown);
			this.lblTitle.MouseLeave += new System.EventHandler(this.MouseLeftChild);
			// 
			// chbSearchArea
			// 
			this.chbSearchArea.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbSearchArea.AutoSize = true;
			this.chbSearchArea.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.chbSearchArea.Checked = true;
			this.chbSearchArea.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbSearchArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chbSearchArea.FlatAppearance.BorderSize = 0;
			this.chbSearchArea.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.chbSearchArea.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
			this.chbSearchArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chbSearchArea.Image = global::Neurotec.Samples.Properties.Resources.SearchArea;
			this.chbSearchArea.Location = new System.Drawing.Point(387, 0);
			this.chbSearchArea.Margin = new System.Windows.Forms.Padding(0);
			this.chbSearchArea.Name = "chbSearchArea";
			this.chbSearchArea.Size = new System.Drawing.Size(122, 24);
			this.chbSearchArea.TabIndex = 2;
			this.chbSearchArea.Text = "Show Search Area";
			this.chbSearchArea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.chbSearchArea, "Show Search Area (Ctrl+1)");
			this.chbSearchArea.UseVisualStyleBackColor = false;
			this.chbSearchArea.CheckedChanged += new System.EventHandler(this.ChbSearchAreaCheckedChanged);
			this.chbSearchArea.MouseLeave += new System.EventHandler(this.MouseLeftChild);
			// 
			// chbTriggers
			// 
			this.chbTriggers.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbTriggers.AutoSize = true;
			this.chbTriggers.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.chbTriggers.Checked = true;
			this.chbTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chbTriggers.FlatAppearance.BorderSize = 0;
			this.chbTriggers.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.chbTriggers.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
			this.chbTriggers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chbTriggers.Image = global::Neurotec.Samples.Properties.Resources.ShowTriggerOverlay;
			this.chbTriggers.Location = new System.Drawing.Point(509, 0);
			this.chbTriggers.Margin = new System.Windows.Forms.Padding(0);
			this.chbTriggers.Name = "chbTriggers";
			this.chbTriggers.Size = new System.Drawing.Size(101, 24);
			this.chbTriggers.TabIndex = 3;
			this.chbTriggers.Text = "Show Triggers";
			this.chbTriggers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.chbTriggers, "Show Tripwires and Regions (Ctrl+2)");
			this.chbTriggers.UseVisualStyleBackColor = false;
			this.chbTriggers.CheckedChanged += new System.EventHandler(this.ChbTriggersCheckedChanged);
			this.chbTriggers.MouseLeave += new System.EventHandler(this.MouseLeftChild);
			// 
			// chbPin
			// 
			this.chbPin.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbPin.AutoSize = true;
			this.chbPin.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.chbPin.Checked = true;
			this.chbPin.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbPin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chbPin.FlatAppearance.BorderSize = 0;
			this.chbPin.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.chbPin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
			this.chbPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chbPin.Image = global::Neurotec.Samples.Properties.Resources.Pin;
			this.chbPin.Location = new System.Drawing.Point(610, 0);
			this.chbPin.Margin = new System.Windows.Forms.Padding(0);
			this.chbPin.Name = "chbPin";
			this.chbPin.Size = new System.Drawing.Size(22, 24);
			this.chbPin.TabIndex = 1;
			this.chbPin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.chbPin, "Always show header (Ctrl+3)");
			this.chbPin.UseVisualStyleBackColor = false;
			this.chbPin.CheckedChanged += new System.EventHandler(this.ChbPinCheckedChanged);
			this.chbPin.MouseLeave += new System.EventHandler(this.MouseLeftChild);
			// 
			// SourceHeader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.CausesValidation = false;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SourceHeader";
			this.Size = new System.Drawing.Size(632, 24);
			this.MouseLeave += new System.EventHandler(this.MouseLeftChild);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.CheckBox chbPin;
		private System.Windows.Forms.CheckBox chbTriggers;
		private System.Windows.Forms.CheckBox chbSearchArea;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chbShowTrackLine;
	}
}
