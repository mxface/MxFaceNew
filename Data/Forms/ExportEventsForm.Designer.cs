namespace Neurotec.Samples.Data.Forms
{
	partial class ExportEventsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportEventsForm));
			this.exportBtn = new System.Windows.Forms.Button();
			this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lblFromTime = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.orderCmbBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.typeCmbBox = new System.Windows.Forms.ComboBox();
			this.lblClass = new System.Windows.Forms.Label();
			this.classCmbBox = new System.Windows.Forms.ComboBox();
			this.btnExportCsv = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblWatchlist = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnExportClick = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cbSource = new System.Windows.Forms.ComboBox();
			this.lblExportStatus = new System.Windows.Forms.Label();
			this.cbWatchlist = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// exportBtn
			// 
			this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exportBtn.Location = new System.Drawing.Point(312, 5);
			this.exportBtn.Name = "exportBtn";
			this.exportBtn.Size = new System.Drawing.Size(128, 23);
			this.exportBtn.TabIndex = 0;
			this.exportBtn.Text = "&Export to Images";
			this.exportBtn.UseVisualStyleBackColor = true;
			this.exportBtn.Click += new System.EventHandler(this.BtnExportAllClick);
			// 
			// fromDateTimePicker
			// 
			this.fromDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fromDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.fromDateTimePicker.Location = new System.Drawing.Point(278, 30);
			this.fromDateTimePicker.Name = "fromDateTimePicker";
			this.fromDateTimePicker.Size = new System.Drawing.Size(302, 20);
			this.fromDateTimePicker.TabIndex = 5;
			// 
			// lblFromTime
			// 
			this.lblFromTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblFromTime.AutoSize = true;
			this.lblFromTime.Location = new System.Drawing.Point(239, 33);
			this.lblFromTime.Name = "lblFromTime";
			this.lblFromTime.Size = new System.Drawing.Size(33, 13);
			this.lblFromTime.TabIndex = 7;
			this.lblFromTime.Text = "From:";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(236, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Order:";
			// 
			// orderCmbBox
			// 
			this.orderCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.orderCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.orderCmbBox.FormattingEnabled = true;
			this.orderCmbBox.Location = new System.Drawing.Point(278, 56);
			this.orderCmbBox.Name = "orderCmbBox";
			this.orderCmbBox.Size = new System.Drawing.Size(302, 21);
			this.orderCmbBox.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(238, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Type:";
			// 
			// typeCmbBox
			// 
			this.typeCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.typeCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeCmbBox.FormattingEnabled = true;
			this.typeCmbBox.Location = new System.Drawing.Point(278, 83);
			this.typeCmbBox.Name = "typeCmbBox";
			this.typeCmbBox.Size = new System.Drawing.Size(302, 21);
			this.typeCmbBox.TabIndex = 11;
			this.typeCmbBox.SelectedValueChanged += new System.EventHandler(this.OnTypeChanged);
			// 
			// lblClass
			// 
			this.lblClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblClass.AutoSize = true;
			this.lblClass.Location = new System.Drawing.Point(237, 141);
			this.lblClass.Name = "lblClass";
			this.lblClass.Size = new System.Drawing.Size(35, 13);
			this.lblClass.TabIndex = 14;
			this.lblClass.Text = "Class:";
			this.lblClass.Visible = false;
			// 
			// classCmbBox
			// 
			this.classCmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.classCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.classCmbBox.FormattingEnabled = true;
			this.classCmbBox.Location = new System.Drawing.Point(278, 137);
			this.classCmbBox.Name = "classCmbBox";
			this.classCmbBox.Size = new System.Drawing.Size(302, 21);
			this.classCmbBox.TabIndex = 15;
			this.classCmbBox.Visible = false;
			// 
			// btnExportCsv
			// 
			this.btnExportCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExportCsv.Location = new System.Drawing.Point(178, 5);
			this.btnExportCsv.Name = "btnExportCsv";
			this.btnExportCsv.Size = new System.Drawing.Size(128, 23);
			this.btnExportCsv.TabIndex = 16;
			this.btnExportCsv.Text = "Export to &CSV";
			this.btnExportCsv.UseVisualStyleBackColor = true;
			this.btnExportCsv.Click += new System.EventHandler(this.ButtonExportCsvClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.lblWatchlist, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.lblFromTime, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.classCmbBox, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.typeCmbBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblClass, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.orderCmbBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.fromDateTimePicker, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbSource, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblExportStatus, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.cbWatchlist, 1, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 228);
			this.tableLayoutPanel1.TabIndex = 17;
			// 
			// lblWatchlist
			// 
			this.lblWatchlist.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblWatchlist.AutoSize = true;
			this.lblWatchlist.Location = new System.Drawing.Point(206, 114);
			this.lblWatchlist.Name = "lblWatchlist";
			this.lblWatchlist.Size = new System.Drawing.Size(66, 13);
			this.lblWatchlist.TabIndex = 20;
			this.lblWatchlist.Text = "In Watchlist:";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.btnExportClick, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnExportCsv, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.exportBtn, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 194);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(577, 31);
			this.tableLayoutPanel2.TabIndex = 18;
			// 
			// btnExportClick
			// 
			this.btnExportClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExportClick.Location = new System.Drawing.Point(446, 5);
			this.btnExportClick.Name = "btnExportClick";
			this.btnExportClick.Size = new System.Drawing.Size(128, 23);
			this.btnExportClick.TabIndex = 17;
			this.btnExportClick.Text = "Export to &Single Images";
			this.btnExportClick.UseVisualStyleBackColor = true;
			this.btnExportClick.Click += new System.EventHandler(this.BtnExportImagesSingleClick);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(228, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Source:";
			// 
			// cbSource
			// 
			this.cbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSource.FormattingEnabled = true;
			this.cbSource.Location = new System.Drawing.Point(278, 3);
			this.cbSource.Name = "cbSource";
			this.cbSource.Size = new System.Drawing.Size(302, 21);
			this.cbSource.TabIndex = 16;
			this.cbSource.SelectedIndexChanged += new System.EventHandler(this.CbSourceSelectedIndexChanged);
			// 
			// lblExportStatus
			// 
			this.lblExportStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblExportStatus.AutoSize = true;
			this.lblExportStatus.Location = new System.Drawing.Point(496, 161);
			this.lblExportStatus.Name = "lblExportStatus";
			this.lblExportStatus.Size = new System.Drawing.Size(84, 13);
			this.lblExportStatus.TabIndex = 19;
			this.lblExportStatus.Text = "Export All Status";
			// 
			// cbWatchlist
			// 
			this.cbWatchlist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbWatchlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWatchlist.FormattingEnabled = true;
			this.cbWatchlist.Location = new System.Drawing.Point(278, 110);
			this.cbWatchlist.Name = "cbWatchlist";
			this.cbWatchlist.Size = new System.Drawing.Size(302, 21);
			this.cbWatchlist.TabIndex = 21;
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Select directory where exported images will be placed";
			// 
			// ExportEventsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(583, 228);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(300, 200);
			this.Name = "ExportEventsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportEventsFormFormClosing);
			this.Shown += new System.EventHandler(this.ExportEventsFormShown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button exportBtn;
		private System.Windows.Forms.DateTimePicker fromDateTimePicker;
		private System.Windows.Forms.Label lblFromTime;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox orderCmbBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox typeCmbBox;
		private System.Windows.Forms.Label lblClass;
		private System.Windows.Forms.ComboBox classCmbBox;
		private System.Windows.Forms.Button btnExportCsv;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbSource;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnExportClick;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label lblExportStatus;
		private System.Windows.Forms.Label lblWatchlist;
		private System.Windows.Forms.ComboBox cbWatchlist;
	}
}
