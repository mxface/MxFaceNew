namespace Neurotec.Samples.Data.Forms
{
	partial class FacesWatchlistForms
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacesWatchlistForms));
			this.label1 = new System.Windows.Forms.Label();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.splitButtonMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.option1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aAAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblSubjectCount = new System.Windows.Forms.Label();
			this.lblPage = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnEnrollDirectory = new System.Windows.Forms.Button();
			this.btnEnrollImages = new System.Windows.Forms.Button();
			this.listView = new System.Windows.Forms.ListView();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.splitButtonMenu.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Search:";
			// 
			// tbSearch
			// 
			this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.tableLayoutPanel1.SetColumnSpan(this.tbSearch, 2);
			this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSearch.Location = new System.Drawing.Point(53, 3);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(774, 20);
			this.tbSearch.TabIndex = 1;
			this.tbSearch.TextChanged += new System.EventHandler(this.TbSearchTextChanged);
			// 
			// splitButtonMenu
			// 
			this.splitButtonMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.option1ToolStripMenuItem,
            this.aAAToolStripMenuItem});
			this.splitButtonMenu.Name = "contextMenuStrip1";
			this.splitButtonMenu.Size = new System.Drawing.Size(118, 48);
			// 
			// option1ToolStripMenuItem
			// 
			this.option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
			this.option1ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.option1ToolStripMenuItem.Text = "Option1";
			// 
			// aAAToolStripMenuItem
			// 
			this.aAAToolStripMenuItem.Name = "aAAToolStripMenuItem";
			this.aAAToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.aAAToolStripMenuItem.Text = "AAA";
			// 
			// lblSubjectCount
			// 
			this.lblSubjectCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblSubjectCount.AutoSize = true;
			this.lblSubjectCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSubjectCount.Location = new System.Drawing.Point(143, 8);
			this.lblSubjectCount.Name = "lblSubjectCount";
			this.lblSubjectCount.Size = new System.Drawing.Size(89, 13);
			this.lblSubjectCount.TabIndex = 7;
			this.lblSubjectCount.Text = "Total Subjects";
			// 
			// lblPage
			// 
			this.lblPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblPage.AutoSize = true;
			this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPage.Location = new System.Drawing.Point(39, 8);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(62, 13);
			this.lblPage.TabIndex = 8;
			this.lblPage.Text = "1 out of 1";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNext.FlatAppearance.BorderSize = 0;
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(107, 3);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(30, 24);
			this.btnNext.TabIndex = 9;
			this.btnNext.Text = ">";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
			// 
			// btnPrev
			// 
			this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrev.FlatAppearance.BorderSize = 0;
			this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrev.Location = new System.Drawing.Point(3, 3);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(30, 24);
			this.btnPrev.TabIndex = 10;
			this.btnPrev.Text = "<";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.BtnPrevClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbSearch, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.listView, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 552);
			this.tableLayoutPanel1.TabIndex = 13;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Controls.Add(this.btnClose, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnDelete, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnClear, 2, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 519);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(824, 30);
			this.tableLayoutPanel3.TabIndex = 14;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(746, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 11;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(584, 3);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 12;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(665, 3);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 13;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 11;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.lblSubjectCount, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnPrev, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnNext, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblPage, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnEnrollDirectory, 6, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnEnrollImages, 5, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 473);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(824, 30);
			this.tableLayoutPanel2.TabIndex = 14;
			// 
			// btnEnrollDirectory
			// 
			this.btnEnrollDirectory.Location = new System.Drawing.Point(703, 3);
			this.btnEnrollDirectory.Name = "btnEnrollDirectory";
			this.btnEnrollDirectory.Size = new System.Drawing.Size(118, 23);
			this.btnEnrollDirectory.TabIndex = 5;
			this.btnEnrollDirectory.Text = "E&nroll From Directory";
			this.btnEnrollDirectory.UseVisualStyleBackColor = true;
			this.btnEnrollDirectory.Click += new System.EventHandler(this.BtnEnrollDirectoryClick);
			// 
			// btnEnrollImages
			// 
			this.btnEnrollImages.Location = new System.Drawing.Point(579, 3);
			this.btnEnrollImages.Name = "btnEnrollImages";
			this.btnEnrollImages.Size = new System.Drawing.Size(118, 23);
			this.btnEnrollImages.TabIndex = 4;
			this.btnEnrollImages.Text = "&Enroll From Images";
			this.btnEnrollImages.UseVisualStyleBackColor = true;
			this.btnEnrollImages.Click += new System.EventHandler(this.BtnEnrollImagesClick);
			// 
			// listView
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.listView, 3);
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(3, 29);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(824, 438);
			this.listView.TabIndex = 15;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
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
			// FacesWatchlistForms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(830, 552);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "FacesWatchlistForms";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Faces Watchlist";
			this.Shown += new System.EventHandler(this.FacesWatchlistFormsShown);
			this.splitButtonMenu.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.ContextMenuStrip splitButtonMenu;
		private System.Windows.Forms.ToolStripMenuItem option1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aAAToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label lblSubjectCount;
		private System.Windows.Forms.Label lblPage;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnEnrollDirectory;
		private System.Windows.Forms.Button btnEnrollImages;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
	}
}
