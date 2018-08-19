namespace NowPlaying4mastodon
{
	partial class dlgPostSettings
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
			this.cmbTootVisibility = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkPostArtwork = new System.Windows.Forms.CheckBox();
			this.chkExplictNSFW = new System.Windows.Forms.CheckBox();
			this.chkAutoPost = new System.Windows.Forms.CheckBox();
			this.chkShowTitlebarTrackInfo = new System.Windows.Forms.CheckBox();
			this.txtPostFormat = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbTootVisibility
			// 
			this.cmbTootVisibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTootVisibility.FormattingEnabled = true;
			this.cmbTootVisibility.Items.AddRange(new object[] {
            "public",
            "unlisted",
            "private",
            "direct"});
			this.cmbTootVisibility.Location = new System.Drawing.Point(167, 33);
			this.cmbTootVisibility.Margin = new System.Windows.Forms.Padding(4);
			this.cmbTootVisibility.Name = "cmbTootVisibility";
			this.cmbTootVisibility.Size = new System.Drawing.Size(131, 25);
			this.cmbTootVisibility.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 37);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "トっート公開範囲";
			// 
			// chkPostArtwork
			// 
			this.chkPostArtwork.AutoSize = true;
			this.chkPostArtwork.Checked = true;
			this.chkPostArtwork.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPostArtwork.Location = new System.Drawing.Point(19, 88);
			this.chkPostArtwork.Margin = new System.Windows.Forms.Padding(4);
			this.chkPostArtwork.Name = "chkPostArtwork";
			this.chkPostArtwork.Size = new System.Drawing.Size(144, 21);
			this.chkPostArtwork.TabIndex = 11;
			this.chkPostArtwork.Text = "アートワークを投稿する";
			this.chkPostArtwork.UseVisualStyleBackColor = true;
			// 
			// chkExplictNSFW
			// 
			this.chkExplictNSFW.AutoSize = true;
			this.chkExplictNSFW.Location = new System.Drawing.Point(19, 128);
			this.chkExplictNSFW.Margin = new System.Windows.Forms.Padding(4);
			this.chkExplictNSFW.Name = "chkExplictNSFW";
			this.chkExplictNSFW.Size = new System.Drawing.Size(211, 21);
			this.chkExplictNSFW.TabIndex = 12;
			this.chkExplictNSFW.Text = "explicitトラックにNSFW設定をする";
			this.chkExplictNSFW.UseVisualStyleBackColor = true;
			// 
			// chkAutoPost
			// 
			this.chkAutoPost.AutoSize = true;
			this.chkAutoPost.Location = new System.Drawing.Point(19, 168);
			this.chkAutoPost.Margin = new System.Windows.Forms.Padding(4);
			this.chkAutoPost.Name = "chkAutoPost";
			this.chkAutoPost.Size = new System.Drawing.Size(212, 21);
			this.chkAutoPost.TabIndex = 12;
			this.chkAutoPost.Text = "曲が切り替わった時に自動Tootする";
			this.chkAutoPost.UseVisualStyleBackColor = true;
			// 
			// chkShowTitlebarTrackInfo
			// 
			this.chkShowTitlebarTrackInfo.AutoSize = true;
			this.chkShowTitlebarTrackInfo.Location = new System.Drawing.Point(19, 209);
			this.chkShowTitlebarTrackInfo.Margin = new System.Windows.Forms.Padding(4);
			this.chkShowTitlebarTrackInfo.Name = "chkShowTitlebarTrackInfo";
			this.chkShowTitlebarTrackInfo.Size = new System.Drawing.Size(170, 21);
			this.chkShowTitlebarTrackInfo.TabIndex = 12;
			this.chkShowTitlebarTrackInfo.Text = "タイトルバーに曲名表示する";
			this.chkShowTitlebarTrackInfo.UseVisualStyleBackColor = true;
			// 
			// txtPostFormat
			// 
			this.txtPostFormat.Location = new System.Drawing.Point(331, 61);
			this.txtPostFormat.Multiline = true;
			this.txtPostFormat.Name = "txtPostFormat";
			this.txtPostFormat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPostFormat.Size = new System.Drawing.Size(419, 169);
			this.txtPostFormat.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(328, 41);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "トっート書式設定";
			// 
			// dlgPostSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 248);
			this.Controls.Add(this.txtPostFormat);
			this.Controls.Add(this.chkShowTitlebarTrackInfo);
			this.Controls.Add(this.chkAutoPost);
			this.Controls.Add(this.chkExplictNSFW);
			this.Controls.Add(this.chkPostArtwork);
			this.Controls.Add(this.cmbTootVisibility);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPostSettings";
			this.Text = "投稿設定";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbTootVisibility;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkPostArtwork;
		private System.Windows.Forms.CheckBox chkExplictNSFW;
		private System.Windows.Forms.CheckBox chkAutoPost;
		private System.Windows.Forms.CheckBox chkShowTitlebarTrackInfo;
		private System.Windows.Forms.TextBox txtPostFormat;
		private System.Windows.Forms.Label label1;
	}
}