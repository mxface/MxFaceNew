namespace Neurotec.Samples.Forms
{
	partial class SurveillanceView
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.sourceHeader = new Neurotec.Samples.Forms.SourceHeader();
			this.drawPanel = new Neurotec.Samples.Forms.DoubleBufferedPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.sourceHeader, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.drawPanel, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 232);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// sourceHeader
			// 
			this.sourceHeader.ActiveColor = System.Drawing.SystemColors.ActiveCaption;
			this.sourceHeader.ActiveSecondaryColor = System.Drawing.SystemColors.InactiveCaption;
			this.sourceHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sourceHeader.AutoSize = true;
			this.sourceHeader.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.sourceHeader.BackColor = System.Drawing.Color.DarkGray;
			this.sourceHeader.CausesValidation = false;
			this.sourceHeader.CheckState = null;
			this.sourceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sourceHeader.Location = new System.Drawing.Point(0, 0);
			this.sourceHeader.Margin = new System.Windows.Forms.Padding(0);
			this.sourceHeader.Name = "sourceHeader";
			this.sourceHeader.PassiveColor = System.Drawing.Color.DarkGray;
			this.sourceHeader.PassiveSecondaryColor = System.Drawing.Color.LightGray;
			this.sourceHeader.ShowExpandedButtons = false;
			this.sourceHeader.ShowPinButton = true;
			this.sourceHeader.ShowTitle = true;
			this.sourceHeader.ShowTrackLineButton = false;
			this.sourceHeader.Size = new System.Drawing.Size(305, 24);
			this.sourceHeader.State = null;
			this.sourceHeader.TabIndex = 0;
			this.sourceHeader.Title = "Title";
			this.sourceHeader.HeaderMouseLeft += new System.EventHandler(this.SourceHeaderMouseLeft);
			// 
			// drawPanel
			// 
			this.drawPanel.BackColor = System.Drawing.SystemColors.Control;
			this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.drawPanel.Location = new System.Drawing.Point(0, 24);
			this.drawPanel.Margin = new System.Windows.Forms.Padding(0);
			this.drawPanel.Name = "drawPanel";
			this.drawPanel.Size = new System.Drawing.Size(305, 208);
			this.drawPanel.TabIndex = 1;
			this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanelPaint);
			this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanelMouseDown);
			this.drawPanel.MouseLeave += new System.EventHandler(this.DrawPanelMouseLeave);
			this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanelMouseMove);
			// 
			// SurveillanceView
			// 
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SurveillanceView";
			this.Size = new System.Drawing.Size(305, 232);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private SourceHeader sourceHeader;
		private DoubleBufferedPanel drawPanel;
	}
}
