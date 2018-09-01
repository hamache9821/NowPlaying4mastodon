namespace NowPlaying4mastodon
{
	partial class mainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lblExplicit = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.seekBarPlayPos = new System.Windows.Forms.TrackBar();
			this.lblPlayPos = new System.Windows.Forms.Label();
			this.lblTrackTime = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnShuffle = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnRepeat = new System.Windows.Forms.Button();
			this.btnPlayPause = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.lblTrackCount = new System.Windows.Forms.Label();
			this.lblReleaseDate = new System.Windows.Forms.Label();
			this.lblTrackArtist = new System.Windows.Forms.Label();
			this.lblAlbumArtist = new System.Windows.Forms.Label();
			this.lblTrackName = new System.Windows.Forms.Label();
			this.lblAlubum = new System.Windows.Forms.Label();
			this.pbArtwork = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ToolStripMenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmConntctionSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmPostSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmReload = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmNowPlaying = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tpsMastdonApiStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tpsSpotifyApiStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tpsVisiblity = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tpsLastPostDate = new System.Windows.Forms.ToolStripStatusLabel();
			this.trackBarVolume = new System.Windows.Forms.TrackBar();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnMute = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cmbDeviceList = new System.Windows.Forms.ComboBox();
			this.btnSwitchDevice = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.seekBarPlayPos)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbArtwork)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(0, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(807, 367);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.panel4);
			this.tabPage1.Controls.Add(this.panel3);
			this.tabPage1.Controls.Add(this.lblExplicit);
			this.tabPage1.Controls.Add(this.panel2);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.lblTrackCount);
			this.tabPage1.Controls.Add(this.lblReleaseDate);
			this.tabPage1.Controls.Add(this.lblTrackArtist);
			this.tabPage1.Controls.Add(this.lblAlbumArtist);
			this.tabPage1.Controls.Add(this.lblTrackName);
			this.tabPage1.Controls.Add(this.lblAlubum);
			this.tabPage1.Controls.Add(this.pbArtwork);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(799, 340);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Spotify";
			// 
			// lblExplicit
			// 
			this.lblExplicit.AutoSize = true;
			this.lblExplicit.BackColor = System.Drawing.SystemColors.Info;
			this.lblExplicit.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblExplicit.ForeColor = System.Drawing.Color.Black;
			this.lblExplicit.Location = new System.Drawing.Point(215, 118);
			this.lblExplicit.Name = "lblExplicit";
			this.lblExplicit.Size = new System.Drawing.Size(52, 17);
			this.lblExplicit.TabIndex = 13;
			this.lblExplicit.Text = "explicit";
			this.lblExplicit.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.seekBarPlayPos);
			this.panel2.Controls.Add(this.lblPlayPos);
			this.panel2.Controls.Add(this.lblTrackTime);
			this.panel2.Location = new System.Drawing.Point(8, 223);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(785, 50);
			this.panel2.TabIndex = 12;
			// 
			// seekBarPlayPos
			// 
			this.seekBarPlayPos.AutoSize = false;
			this.seekBarPlayPos.Location = new System.Drawing.Point(82, 3);
			this.seekBarPlayPos.Name = "seekBarPlayPos";
			this.seekBarPlayPos.Size = new System.Drawing.Size(599, 45);
			this.seekBarPlayPos.SmallChange = 1000;
			this.seekBarPlayPos.TabIndex = 10;
			this.seekBarPlayPos.TickFrequency = 60000;
			this.seekBarPlayPos.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// lblPlayPos
			// 
			this.lblPlayPos.AutoSize = true;
			this.lblPlayPos.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblPlayPos.Location = new System.Drawing.Point(13, 3);
			this.lblPlayPos.Name = "lblPlayPos";
			this.lblPlayPos.Size = new System.Drawing.Size(68, 17);
			this.lblPlayPos.TabIndex = 8;
			this.lblPlayPos.Text = "00:00:00";
			// 
			// lblTrackTime
			// 
			this.lblTrackTime.AutoSize = true;
			this.lblTrackTime.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTrackTime.Location = new System.Drawing.Point(687, 3);
			this.lblTrackTime.Name = "lblTrackTime";
			this.lblTrackTime.Size = new System.Drawing.Size(68, 17);
			this.lblTrackTime.TabIndex = 8;
			this.lblTrackTime.Text = "00:00:00";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnShuffle);
			this.panel1.Controls.Add(this.btnPrevious);
			this.panel1.Controls.Add(this.btnRepeat);
			this.panel1.Controls.Add(this.btnPlayPause);
			this.panel1.Controls.Add(this.btnNext);
			this.panel1.Location = new System.Drawing.Point(178, 278);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(285, 44);
			this.panel1.TabIndex = 11;
			// 
			// btnShuffle
			// 
			this.btnShuffle.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnShuffle.Location = new System.Drawing.Point(0, 0);
			this.btnShuffle.Name = "btnShuffle";
			this.btnShuffle.Size = new System.Drawing.Size(40, 40);
			this.btnShuffle.TabIndex = 9;
			this.btnShuffle.Text = "🔀";
			this.btnShuffle.UseVisualStyleBackColor = true;
			this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnPrevious.Location = new System.Drawing.Point(60, 0);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(40, 40);
			this.btnPrevious.TabIndex = 9;
			this.btnPrevious.Text = "⏮";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnRepeat
			// 
			this.btnRepeat.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnRepeat.ForeColor = System.Drawing.Color.DarkGray;
			this.btnRepeat.Location = new System.Drawing.Point(240, 0);
			this.btnRepeat.Name = "btnRepeat";
			this.btnRepeat.Size = new System.Drawing.Size(40, 40);
			this.btnRepeat.TabIndex = 9;
			this.btnRepeat.Text = "🔁";
			this.btnRepeat.UseVisualStyleBackColor = true;
			this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnPlayPause.Location = new System.Drawing.Point(120, 0);
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(40, 40);
			this.btnPlayPause.TabIndex = 9;
			this.btnPlayPause.Text = "⏸";
			this.btnPlayPause.UseVisualStyleBackColor = true;
			this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
			// 
			// btnNext
			// 
			this.btnNext.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnNext.Location = new System.Drawing.Point(180, 0);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(40, 40);
			this.btnNext.TabIndex = 9;
			this.btnNext.Text = "⏭";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// lblTrackCount
			// 
			this.lblTrackCount.AutoSize = true;
			this.lblTrackCount.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTrackCount.Location = new System.Drawing.Point(318, 92);
			this.lblTrackCount.Name = "lblTrackCount";
			this.lblTrackCount.Size = new System.Drawing.Size(80, 17);
			this.lblTrackCount.TabIndex = 8;
			this.lblTrackCount.Text = "TrackCount";
			// 
			// lblReleaseDate
			// 
			this.lblReleaseDate.AutoSize = true;
			this.lblReleaseDate.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblReleaseDate.Location = new System.Drawing.Point(214, 92);
			this.lblReleaseDate.Name = "lblReleaseDate";
			this.lblReleaseDate.Size = new System.Drawing.Size(89, 17);
			this.lblReleaseDate.TabIndex = 8;
			this.lblReleaseDate.Text = "ReleaseDate";
			// 
			// lblTrackArtist
			// 
			this.lblTrackArtist.AutoSize = true;
			this.lblTrackArtist.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTrackArtist.Location = new System.Drawing.Point(213, 180);
			this.lblTrackArtist.Name = "lblTrackArtist";
			this.lblTrackArtist.Size = new System.Drawing.Size(92, 20);
			this.lblTrackArtist.TabIndex = 8;
			this.lblTrackArtist.Text = "TrackArtist";
			// 
			// lblAlbumArtist
			// 
			this.lblAlbumArtist.AutoSize = true;
			this.lblAlbumArtist.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblAlbumArtist.Location = new System.Drawing.Point(212, 56);
			this.lblAlbumArtist.Name = "lblAlbumArtist";
			this.lblAlbumArtist.Size = new System.Drawing.Size(101, 20);
			this.lblAlbumArtist.TabIndex = 8;
			this.lblAlbumArtist.Text = "AlbumArtist";
			// 
			// lblTrackName
			// 
			this.lblTrackName.AutoSize = true;
			this.lblTrackName.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTrackName.Location = new System.Drawing.Point(211, 135);
			this.lblTrackName.Name = "lblTrackName";
			this.lblTrackName.Size = new System.Drawing.Size(127, 26);
			this.lblTrackName.TabIndex = 8;
			this.lblTrackName.Text = "TrackName";
			// 
			// lblAlubum
			// 
			this.lblAlubum.AutoSize = true;
			this.lblAlubum.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblAlubum.Location = new System.Drawing.Point(212, 17);
			this.lblAlubum.Name = "lblAlubum";
			this.lblAlubum.Size = new System.Drawing.Size(90, 26);
			this.lblAlubum.TabIndex = 8;
			this.lblAlubum.Text = "Alubum";
			// 
			// pbArtwork
			// 
			this.pbArtwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pbArtwork.Location = new System.Drawing.Point(6, 17);
			this.pbArtwork.Name = "pbArtwork";
			this.pbArtwork.Size = new System.Drawing.Size(200, 200);
			this.pbArtwork.TabIndex = 0;
			this.pbArtwork.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Settings,
            this.tsmReload,
            this.tsmNowPlaying});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(806, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ToolStripMenuItem_Settings
			// 
			this.ToolStripMenuItem_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConntctionSettings,
            this.tsmPostSettings});
			this.ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings";
			this.ToolStripMenuItem_Settings.Size = new System.Drawing.Size(43, 20);
			this.ToolStripMenuItem_Settings.Text = "設定";
			// 
			// tsmConntctionSettings
			// 
			this.tsmConntctionSettings.Name = "tsmConntctionSettings";
			this.tsmConntctionSettings.Size = new System.Drawing.Size(122, 22);
			this.tsmConntctionSettings.Text = "接続設定";
			// 
			// tsmPostSettings
			// 
			this.tsmPostSettings.Name = "tsmPostSettings";
			this.tsmPostSettings.Size = new System.Drawing.Size(122, 22);
			this.tsmPostSettings.Text = "投稿設定";
			// 
			// tsmReload
			// 
			this.tsmReload.Name = "tsmReload";
			this.tsmReload.Size = new System.Drawing.Size(34, 20);
			this.tsmReload.Text = "🔄 ";
			// 
			// tsmNowPlaying
			// 
			this.tsmNowPlaying.Name = "tsmNowPlaying";
			this.tsmNowPlaying.Size = new System.Drawing.Size(31, 20);
			this.tsmNowPlaying.Text = "♬";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.tpsMastdonApiStatus,
            this.toolStripStatusLabel2,
            this.tpsSpotifyApiStatus,
            this.toolStripStatusLabel3,
            this.tpsVisiblity,
            this.toolStripStatusLabel1,
            this.tpsLastPostDate});
			this.statusStrip1.Location = new System.Drawing.Point(0, 394);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(806, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 10;
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(85, 17);
			this.toolStripStatusLabel.Text = "Mastodon Api:";
			// 
			// tpsMastdonApiStatus
			// 
			this.tpsMastdonApiStatus.AutoSize = false;
			this.tpsMastdonApiStatus.Name = "tpsMastdonApiStatus";
			this.tpsMastdonApiStatus.Size = new System.Drawing.Size(80, 17);
			this.tpsMastdonApiStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
			this.toolStripStatusLabel2.Text = "Spotify Api:";
			// 
			// tpsSpotifyApiStatus
			// 
			this.tpsSpotifyApiStatus.AutoSize = false;
			this.tpsSpotifyApiStatus.Name = "tpsSpotifyApiStatus";
			this.tpsSpotifyApiStatus.Size = new System.Drawing.Size(120, 17);
			this.tpsSpotifyApiStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(74, 17);
			this.toolStripStatusLabel3.Text = "TootVisiblity:";
			// 
			// tpsVisiblity
			// 
			this.tpsVisiblity.Name = "tpsVisiblity";
			this.tpsVisiblity.Size = new System.Drawing.Size(40, 17);
			this.tpsVisiblity.Text = "public";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
			this.toolStripStatusLabel1.Text = "LastPosted:";
			// 
			// tpsLastPostDate
			// 
			this.tpsLastPostDate.AutoSize = false;
			this.tpsLastPostDate.Name = "tpsLastPostDate";
			this.tpsLastPostDate.Size = new System.Drawing.Size(120, 17);
			this.tpsLastPostDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBarVolume
			// 
			this.trackBarVolume.Location = new System.Drawing.Point(49, 12);
			this.trackBarVolume.Maximum = 100;
			this.trackBarVolume.Name = "trackBarVolume";
			this.trackBarVolume.Size = new System.Drawing.Size(115, 45);
			this.trackBarVolume.TabIndex = 14;
			this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarVolume.Value = 95;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnMute);
			this.panel3.Controls.Add(this.trackBarVolume);
			this.panel3.Location = new System.Drawing.Point(8, 279);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(164, 45);
			this.panel3.TabIndex = 15;
			// 
			// btnMute
			// 
			this.btnMute.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnMute.Location = new System.Drawing.Point(3, 3);
			this.btnMute.Name = "btnMute";
			this.btnMute.Size = new System.Drawing.Size(40, 40);
			this.btnMute.TabIndex = 9;
			this.btnMute.Text = "🔊";
			this.btnMute.UseVisualStyleBackColor = true;
			this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.cmbDeviceList);
			this.panel4.Controls.Add(this.btnSwitchDevice);
			this.panel4.Location = new System.Drawing.Point(514, 291);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(276, 33);
			this.panel4.TabIndex = 16;
			// 
			// cmbDeviceList
			// 
			this.cmbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDeviceList.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cmbDeviceList.FormattingEnabled = true;
			this.cmbDeviceList.Location = new System.Drawing.Point(0, 0);
			this.cmbDeviceList.Name = "cmbDeviceList";
			this.cmbDeviceList.Size = new System.Drawing.Size(180, 27);
			this.cmbDeviceList.TabIndex = 1;
			// 
			// btnSwitchDevice
			// 
			this.btnSwitchDevice.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnSwitchDevice.Location = new System.Drawing.Point(186, 0);
			this.btnSwitchDevice.Name = "btnSwitchDevice";
			this.btnSwitchDevice.Size = new System.Drawing.Size(40, 27);
			this.btnSwitchDevice.TabIndex = 9;
			this.btnSwitchDevice.Text = "→";
			this.btnSwitchDevice.UseVisualStyleBackColor = true;
			this.btnSwitchDevice.Click += btnSwitchDevice_Click;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 416);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "mainForm";
			this.Text = "なうぷれ for  Mastodon";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.seekBarPlayPos)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbArtwork)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tsmReload;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Settings;
		private System.Windows.Forms.ToolStripMenuItem tsmConntctionSettings;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnRepeat;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPlayPause;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnShuffle;
		private System.Windows.Forms.Label lblTrackTime;
		private System.Windows.Forms.Label lblTrackCount;
		private System.Windows.Forms.Label lblReleaseDate;
		private System.Windows.Forms.Label lblTrackArtist;
		private System.Windows.Forms.Label lblAlbumArtist;
		private System.Windows.Forms.Label lblTrackName;
		private System.Windows.Forms.Label lblAlubum;
		private System.Windows.Forms.PictureBox pbArtwork;
		private System.Windows.Forms.TrackBar seekBarPlayPos;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblPlayPos;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel tpsMastdonApiStatus;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel tpsLastPostDate;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel tpsSpotifyApiStatus;
		private System.Windows.Forms.ToolStripMenuItem tsmPostSettings;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel tpsVisiblity;
		private System.Windows.Forms.Label lblExplicit;
		private System.Windows.Forms.ToolStripMenuItem tsmNowPlaying;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnMute;
		private System.Windows.Forms.TrackBar trackBarVolume;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cmbDeviceList;
		private System.Windows.Forms.Button btnSwitchDevice;
	}
}

