namespace Neurotec.Samples.Data.Forms
{
	partial class LicensePlateWatchlistForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicensePlateWatchlistForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.tbSearchAndAdd = new System.Windows.Forms.TextBox();
			this.listViewPlates = new System.Windows.Forms.ListView();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.lblTotal = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbOwner = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbSearchAndAdd, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.listViewPlates, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnDelete, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.btnClear, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblTotal, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbOwner, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnAdd, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnClose, 4, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 553);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "License Plate Value";
			// 
			// tbSearchAndAdd
			// 
			this.tbSearchAndAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.tbSearchAndAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.tableLayoutPanel1.SetColumnSpan(this.tbSearchAndAdd, 3);
			this.tbSearchAndAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSearchAndAdd.Location = new System.Drawing.Point(110, 3);
			this.tbSearchAndAdd.Name = "tbSearchAndAdd";
			this.tbSearchAndAdd.Size = new System.Drawing.Size(640, 20);
			this.tbSearchAndAdd.TabIndex = 3;
			this.tbSearchAndAdd.TextChanged += new System.EventHandler(this.TbSearchTextChanged);
			// 
			// listViewPlates
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.listViewPlates, 5);
			this.listViewPlates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewPlates.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listViewPlates.FullRowSelect = true;
			this.listViewPlates.HideSelection = false;
			this.listViewPlates.Location = new System.Drawing.Point(3, 58);
			this.listViewPlates.MultiSelect = false;
			this.listViewPlates.Name = "listViewPlates";
			this.listViewPlates.Size = new System.Drawing.Size(828, 463);
			this.listViewPlates.TabIndex = 6;
			this.listViewPlates.UseCompatibleStateImageBehavior = false;
			this.listViewPlates.View = System.Windows.Forms.View.List;
			this.listViewPlates.SelectedIndexChanged += new System.EventHandler(this.ListViewPlatesSelectedIndexChanged);
			this.listViewPlates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewPlatesMouseDoubleClick);
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(594, 527);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 7;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(675, 527);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// lblTotal
			// 
			this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblTotal.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblTotal, 2);
			this.lblTotal.Location = new System.Drawing.Point(3, 532);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(74, 13);
			this.lblTotal.TabIndex = 5;
			this.lblTotal.Text = "Subject Count";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(66, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Owner";
			// 
			// tbOwner
			// 
			this.tbOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.tbOwner, 3);
			this.tbOwner.Location = new System.Drawing.Point(110, 30);
			this.tbOwner.Name = "tbOwner";
			this.tbOwner.Size = new System.Drawing.Size(640, 20);
			this.tbOwner.TabIndex = 4;
			// 
			// btnAdd
			// 
			this.btnAdd.Enabled = false;
			this.btnAdd.Location = new System.Drawing.Point(756, 29);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "&Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(756, 527);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// LicensePlateWatchlistForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 553);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "LicensePlateWatchlistForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "License Plates Watchlist";
			this.Shown += new System.EventHandler(this.LicensePlateWatchlistFormShown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbSearchAndAdd;
		private System.Windows.Forms.ListView listViewPlates;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbOwner;
		private System.Windows.Forms.Button btnClose;
	}
}
