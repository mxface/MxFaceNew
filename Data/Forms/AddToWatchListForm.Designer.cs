namespace Neurotec.Samples.Data.Forms
{
	partial class AddToWatchListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToWatchListForm));
			this.textBoxSubjectId = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelSubjectId = new System.Windows.Forms.Label();
			this.view = new Neurotec.Biometrics.Gui.NFaceView();
			this.SuspendLayout();
			// 
			// textBoxSubjectId
			// 
			this.textBoxSubjectId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSubjectId.Location = new System.Drawing.Point(196, 405);
			this.textBoxSubjectId.Name = "textBoxSubjectId";
			this.textBoxSubjectId.Size = new System.Drawing.Size(444, 20);
			this.textBoxSubjectId.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(484, 431);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(565, 431);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelSubjectId
			// 
			this.labelSubjectId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelSubjectId.AutoSize = true;
			this.labelSubjectId.Location = new System.Drawing.Point(12, 408);
			this.labelSubjectId.Name = "labelSubjectId";
			this.labelSubjectId.Size = new System.Drawing.Size(178, 13);
			this.labelSubjectId.TabIndex = 4;
			this.labelSubjectId.Text = "Enter subject id for the located face:";
			// 
			// view
			// 
			this.view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.view.Face = null;
			this.view.FaceIds = null;
			this.view.IcaoArrowsColor = System.Drawing.Color.Red;
			this.view.Location = new System.Drawing.Point(12, 3);
			this.view.Name = "view";
			this.view.ShowFaceConfidence = false;
			this.view.ShowIcaoArrows = true;
			this.view.ShowTokenImageRectangle = true;
			this.view.Size = new System.Drawing.Size(628, 402);
			this.view.TabIndex = 5;
			this.view.TokenImageRectangleColor = System.Drawing.Color.White;
			// 
			// AddToWatchListForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(652, 466);
			this.Controls.Add(this.view);
			this.Controls.Add(this.labelSubjectId);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxSubjectId);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddToWatchListForm";
			this.Text = "Add To Watch List";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxSubjectId;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelSubjectId;
		private Neurotec.Biometrics.Gui.NFaceView view;
	}
}
