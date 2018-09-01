namespace NowPlaying4mastodon
{
	partial class dlgConnectionSettings
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.txtAuthorizeCode = new System.Windows.Forms.TextBox();
			this.btnOpenMastodonAuthorization = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMastodonInstanceDomain = new System.Windows.Forms.TextBox();
			this.btnOpenSpotifyAuthorization = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbTrackInfoRegin = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.btnOpenMastodonAuthorization);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtMastodonInstanceDomain);
			this.groupBox1.Location = new System.Drawing.Point(5, 13);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.groupBox1.Size = new System.Drawing.Size(616, 153);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mastodon";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.txtAuthorizeCode);
			this.panel1.Location = new System.Drawing.Point(153, 85);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(455, 61);
			this.panel1.TabIndex = 2;
			this.panel1.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(5, 31);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 26);
			this.button1.TabIndex = 1;
			this.button1.Text = "認証コードを確認";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnAuthorizeCodeVerify_Click);
			// 
			// txtAuthorizeCode
			// 
			this.txtAuthorizeCode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtAuthorizeCode.Location = new System.Drawing.Point(5, 6);
			this.txtAuthorizeCode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.txtAuthorizeCode.Name = "txtAuthorizeCode";
			this.txtAuthorizeCode.Size = new System.Drawing.Size(445, 23);
			this.txtAuthorizeCode.TabIndex = 0;
			// 
			// btnOpenMastodonAuthorization
			// 
			this.btnOpenMastodonAuthorization.Location = new System.Drawing.Point(12, 85);
			this.btnOpenMastodonAuthorization.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.btnOpenMastodonAuthorization.Name = "btnOpenMastodonAuthorization";
			this.btnOpenMastodonAuthorization.Size = new System.Drawing.Size(133, 34);
			this.btnOpenMastodonAuthorization.TabIndex = 1;
			this.btnOpenMastodonAuthorization.Text = "認証画面を開く";
			this.btnOpenMastodonAuthorization.UseVisualStyleBackColor = true;
			this.btnOpenMastodonAuthorization.Click += new System.EventHandler(this.btnOpenAuthorizeWindow_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 24);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "userid@domainで入力";
			// 
			// txtMastodonUserInfo
			// 
			this.txtMastodonInstanceDomain.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtMastodonInstanceDomain.Location = new System.Drawing.Point(10, 50);
			this.txtMastodonInstanceDomain.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.txtMastodonInstanceDomain.Name = "txtMastodonUserInfo";
			this.txtMastodonInstanceDomain.Size = new System.Drawing.Size(593, 23);
			this.txtMastodonInstanceDomain.TabIndex = 0;
			// 
			// btnOpenSpotifyAuthorization
			// 
			this.btnOpenSpotifyAuthorization.Location = new System.Drawing.Point(10, 28);
			this.btnOpenSpotifyAuthorization.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpenSpotifyAuthorization.Name = "btnOpenSpotifyAuthorization";
			this.btnOpenSpotifyAuthorization.Size = new System.Drawing.Size(135, 34);
			this.btnOpenSpotifyAuthorization.TabIndex = 0;
			this.btnOpenSpotifyAuthorization.Text = "認証画面を開く";
			this.btnOpenSpotifyAuthorization.UseVisualStyleBackColor = true;
			this.btnOpenSpotifyAuthorization.Click += new System.EventHandler(this.btnOpenSpotifyAuthorization_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbTrackInfoRegin);
			this.groupBox2.Controls.Add(this.btnOpenSpotifyAuthorization);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(5, 180);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(616, 78);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Spotify";
			// 
			// cmbTrackInfoRegin
			// 
			this.cmbTrackInfoRegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTrackInfoRegin.FormattingEnabled = true;
			this.cmbTrackInfoRegin.Items.AddRange(new object[] {
            "AD",
            "AR",
            "AT",
            "AU",
            "BE",
            "BG",
            "BO",
            "BR",
            "CA",
            "CH",
            "CL",
            "CO",
            "CR",
            "CY",
            "CZ",
            "DE",
            "DK",
            "DO",
            "EC",
            "EE",
            "ES",
            "FI",
            "FR",
            "GB",
            "GR",
            "GT",
            "HK",
            "HN",
            "HU",
            "ID",
            "IE",
            "IL",
            "IS",
            "IT",
            "JP",
            "LI",
            "LT",
            "LU",
            "LV",
            "MC",
            "MT",
            "MX",
            "MY",
            "NI",
            "NL",
            "NO",
            "NZ",
            "PA",
            "PE",
            "PH",
            "PL",
            "PT",
            "PY",
            "RO",
            "SE",
            "SG",
            "SK",
            "SV",
            "TH",
            "TR",
            "TW",
            "US",
            "UY",
            "VN",
            "ZA"});
			this.cmbTrackInfoRegin.Location = new System.Drawing.Point(297, 33);
			this.cmbTrackInfoRegin.Margin = new System.Windows.Forms.Padding(4);
			this.cmbTrackInfoRegin.Name = "cmbTrackInfoRegin";
			this.cmbTrackInfoRegin.Size = new System.Drawing.Size(154, 27);
			this.cmbTrackInfoRegin.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(163, 36);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "MarketRegion";
			// 
			// dlgConnectionSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(629, 266);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConnectionSettings";
			this.Text = "接続設定";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOpenMastodonAuthorization;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMastodonInstanceDomain;
		private System.Windows.Forms.Button btnOpenSpotifyAuthorization;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cmbTrackInfoRegin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtAuthorizeCode;
		private System.Windows.Forms.Button button1;
	}
}