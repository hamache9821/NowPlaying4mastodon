using commonUtil.oAuth2.Model;
using spofity.api;
using spofity.api.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using TootNet;

namespace NowPlaying4mastodon
{
	public partial class mainForm : Form
	{
		private oAuth2Request spotifyoAuth2Request = null;
		private oAuth2Response spotifyoAuth2Response = null;

		private Tokens Tokens = null;

		private Dispatcher spotifyApi = null;

		private CurrentPlayback PrevPlayback = null;
		private CurrentPlayback CurrentPlayback = null;
		private AvailableDevices AvailableDevices = null;

		private string LastTootIds = "";

		private string repeatState = "off";

		private string playState = "";


		/// <summary>
		/// コンストラクタ
		/// 
		/// </summary>
		public mainForm()
		{
			InitializeComponent();

			//イベントハンドラ
			seekBarPlayPos.MouseUp += TrackBar1_MouseUp;
			trackBarVolume.MouseUp += TrackBarVolume_MouseUp;
			tsmConntctionSettings.Click += tsmConntctionSettings_Click;
			tsmPostSettings.Click += tsmPostSettings_Click;
			tsmReload.Click += TsmReload_Click;
			tsmNowPlaying.Click += TsmNowPlaying_Click;

			Load += MainForm_Load;
			Activated += MainForm_Activated;
			timer1.Tick += Timer1_Tick;

			timer1.Interval = 1000;

			//mastodon接続設定
			initMastodonSettings();

			//spotify接続設定
			initSpotifySettings();
		}

		#region"【form events】"
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			setSettings();

			if (spotifyApi == null)
			{
				tpsSpotifyApiStatus.Text = "UnAuthorized.";
				tpsSpotifyApiStatus.ForeColor = Color.Black;
				return;
			}

			setCurrentPlayback(0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Activated(object sender, EventArgs e)
		{
			//if (spotifyApi == null)
			//{
			//	tpsSpotifyApiStatus.Text = "認証まだ";
			//	return;
			//}

			//setCurrentPlayback(0);

			//SetPlaybackToResume();
		}

		/// <summary>
		/// seekbar制御
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer1_Tick(object sender, EventArgs e)
		{
			this.Invoke((Action)(() =>
			{
				//test
				//setCurrentPlayback(0);

				if (seekBarPlayPos.Value < seekBarPlayPos.Maximum - timer1.Interval)
				{
					//seek進める
					seekBarPlayPos.Value += timer1.Interval;
					lblTrackTime.Text = msToTime(seekBarPlayPos.Maximum);
					lblPlayPos.Text = msToTime(seekBarPlayPos.Value);
				}
				else
				{
					//次トラック情報取得
					setCurrentPlayback(100);
				}
			}));
		}
		#endregion

		#region"【button events】"
		/// <summary>
		/// spotify:次トラックへ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNext_Click(object sender, EventArgs e)
		{
			setSpotifyPlayerStatus(PlayerStatus.NEXT);
		}

		/// <summary>
		/// spotify:前トラックへ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrevious_Click(object sender, EventArgs e)
		{
			setSpotifyPlayerStatus(PlayerStatus.PREV);
		}

		/// <summary>
		/// 停止/再開
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPlayPause_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled)
			{
				setSpotifyPlayerStatus(PlayerStatus.PAUSE);
			}
			else
			{

			}
		}

		/// <summary>
		/// リピート設定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRepeat_Click(object sender, EventArgs e)
		{
			//ステータス送り
			switch (repeatState)
			{
				case "off":
					repeatState = "context";
					break;

				case "track":
					repeatState = "off";
					break;

				case "context":
					repeatState = "track";
					break;
			}

			//ボタン表示設定
			setRepeatButtonStyle(repeatState);

			//ステータス変更
			spotifyApi.SetRepeatStatus(repeatState);
		}

		/// <summary>
		/// 音量設定ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMute_Click(object sender, EventArgs e)
		{
			if (trackBarVolume.Value == 0)
			{
				trackBarVolume.Value = 50;
			}
			else if (trackBarVolume.Value <= 50)
			{
				trackBarVolume.Value = 100;
			}
			else
			{
				trackBarVolume.Value = 0;
			}

			setVolume();
			setMuteButtonStyle();
		}

		/// <summary>
		/// 再生デバイス切替ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSwitchDevice_Click(object sender, System.EventArgs e)
		{
			Device d = getDeviceByName(cmbDeviceList.Text);

			if (d == null) return;

			spotifyApi.SetTransferDevice(new TransferRequest() { device_ids = new List<string>() { d.id }, play = true });

			setAvailableDevices(1000);

		}


		#endregion

		#region"【menu events】"
		/// <summary>
		/// 接続設定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsmConntctionSettings_Click(object sender, System.EventArgs e)
		{
			try
			{
				using (dlgConnectionSettings c = new dlgConnectionSettings() { spotifyoAuth2Request = this.spotifyoAuth2Request, spotifyoAuth2Response = this.spotifyoAuth2Response })
				{
					c.ShowDialog(this);
					spotifyoAuth2Response = c.spotifyoAuth2Response;
					c.Dispose();
				}

			}
			finally
			{
				//mastodon接続設定
				initMastodonSettings();

				//spotify接続設定
				initSpotifySettings();

				if (spotifyoAuth2Request != null && spotifyoAuth2Response != null)
					spotifyApi = new Dispatcher(spotifyoAuth2Request, spotifyoAuth2Response);

				if (spotifyApi == null)
				{
					tpsSpotifyApiStatus.Text = "UnAuthorized.";
				}
				else
				{
					tpsSpotifyApiStatus.Text = "Connected.";

					//曲情報を更新
					setCurrentPlayback(100);
				}
			}
		}

		/// <summary>
		/// 投稿設定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsmPostSettings_Click(object sender, EventArgs e)
		{
			using (dlgPostSettings c = new dlgPostSettings())
			{
				c.ShowDialog(this);
				c.Dispose();
			}
			setSettings();
		}

		/// <summary>
		/// リロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TsmReload_Click(object sender, EventArgs e)
		{
			if (spotifyApi == null)
			{
				tpsSpotifyApiStatus.Text = "UnAuthorized.";
				tpsSpotifyApiStatus.ForeColor = Color.Red;
				return;
			}

			initPlayInfo();

			setCurrentPlayback(0);
		}

		/// <summary>
		/// 手動投稿
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TsmNowPlaying_Click(object sender, EventArgs e)
		{
			TootNowPlaying(true);
		}


		#endregion




		private void TrackBarVolume_MouseUp(object sender, MouseEventArgs e)
		{
			setVolume();
			setMuteButtonStyle();
		}




		private enum PlayerStatus
		{
			PREV,
			NEXT,
			PAUSE,
			SEEK

		}


		#region"【spotify api control method】"
		/// <summary>s
		/// spotify再生ステータス変更
		/// </summary>
		/// <param name="ps"></param>
		private void setSpotifyPlayerStatus(PlayerStatus ps)
		{
			Device d = getAvailableDevice();

			if (d == null) return;

			switch (ps)
			{
				case PlayerStatus.NEXT:
					spotifyApi.SetPlaybackToNextTrack(d);
					break;

				case PlayerStatus.PREV:
					spotifyApi.SetPlaybackToPreviousTrack(d);
					break;

				case PlayerStatus.PAUSE:
					spotifyApi.SetPlaybackToPause(d);
					break;

				case PlayerStatus.SEEK:
					spotifyApi.SetSeekPosition(d, seekBarPlayPos.Value);
					break;

				default:
					return;

			}

			//曲情報を更新
			setCurrentPlayback(1000);
		}


		/// <summary>
		/// 音量取得
		/// </summary>
		private void getVolume()
		{
			CurrentPlayback = spotifyApi.GetCurrentPlayback(Properties.Settings.Default.Spotify_Markets);

			if (CurrentPlayback == null) return;

			trackBarVolume.Value = CurrentPlayback.device.volume_percent;

			setMuteButtonStyle();
		}

		/// <summary>
		/// 音量設定
		/// </summary>
		private void setVolume()
		{
			Device d = getAvailableDevice();

			if (d == null) return;

			spotifyApi.SetVolume(d, trackBarVolume.Value);

			setMuteButtonStyle();
		}


		private void getShuffleState()
		{
			if (CurrentPlayback == null) return;

			//trackBarVolume.Value = CurrentPlayback.shuffle_state;

			setShuffleButtonStyle();

		}

		private void setShuffleState()
		{

		}

		#endregion




		/// <summary>
		/// 
		/// </summary>
		private void setSettings()
		{
			tpsVisiblity.Text = Properties.Settings.Default.Mastodon_Toot_Visiblity;
		}

		#region"【イベントハンドラ】"


		/// <summary>
		/// seek
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TrackBar1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			setSpotifyPlayerStatus(PlayerStatus.SEEK);
			lblPlayPos.Text = msToTime(seekBarPlayPos.Value);
		}
		#endregion

		#region"【mastodon処理】"
		/// <summary>
		/// 接続設定
		/// </summary>
		private void initMastodonSettings()
		{
			//
			if (!string.IsNullOrEmpty(Properties.Settings.Default.Mastodon_Userinfo) && !string.IsNullOrEmpty(Properties.Settings.Default.Mastodon_Access_token))
			{
				string[] s = Properties.Settings.Default.Mastodon_Userinfo.Split('@');

				if (s.Length != 2 || s[0] == string.Empty || s[1] == String.Empty)
					return;

				Tokens = new Tokens(s[1], Properties.Settings.Default.Mastodon_Access_token);

				if (Tokens != null)
				{
					tpsMastdonApiStatus.Text = "Connected.";
					tpsMastdonApiStatus.ForeColor = Color.Black;
				}
			}
		}

		/// <summary>
		/// なうぷれ投稿
		/// </summary>
		/// <param name="forcePost">連投する</param>
		private async void TootNowPlaying(bool forcePost)
		{
			try
			{

				if (Tokens == null)
				{
					tpsMastdonApiStatus.Text = "UnAuthorized.";
					tpsMastdonApiStatus.ForeColor = Color.Red;
					return;
				}

				//連投防止
				if (!forcePost && LastTootIds != "" && LastTootIds == CurrentPlayback.item.id) return;

				LastTootIds = CurrentPlayback.item.id;

				var stat = Properties.Settings.Default.Mastodon_Toot_Format
					.Replace("{trackArtist}", CurrentPlayback.item.artists[0].name)
					.Replace("{trackName}", CurrentPlayback.item.name)
					.Replace("{Links}", "Links:" + CurrentPlayback.item.album.external_urls.spotify)
					.Replace("{Preview}", (CurrentPlayback.item.preview_url == null) ? "" : "Preview:" + CurrentPlayback.item.preview_url);


				if (Properties.Settings.Default.Mastodon_Toot_PostArtwork)
				{
					var sFilename = string.Format(@"{0}{1}.png", Path.GetTempPath(), CurrentPlayback.item.id);
					pbArtwork.BackgroundImage.Save(sFilename);

					//アートワーク付
					using (var fs = new FileStream(sFilename, FileMode.Open, FileAccess.Read))
					{
						// toot with picture
						var attachment = await Tokens.Media.PostAsync(file => fs);
						await Tokens.Statuses.PostAsync(
							status => stat
							, media_ids => new List<long> { attachment.Id }
							, visibility => Properties.Settings.Default.Mastodon_Toot_Visiblity
							, sensitive => (Properties.Settings.Default.Mastodon_Toot_SetNSFW && lblExplicit.Visible) ? "true" : ""
							, spoiler_text => (Properties.Settings.Default.Mastodon_Toot_SetNSFW && lblExplicit.Visible) ? "Explicit" : ""
							);
					}

					//削除
					File.Delete(sFilename);

				}
				else
				{
					//本文のみ
					await Tokens.Statuses.PostAsync(
						status => stat
						, visibility => Properties.Settings.Default.Mastodon_Toot_Visiblity
						, sensitive => (Properties.Settings.Default.Mastodon_Toot_SetNSFW && lblExplicit.Visible) ? "true" : ""
						, spoiler_text => (Properties.Settings.Default.Mastodon_Toot_SetNSFW && lblExplicit.Visible) ? "Explicit" : ""
						);
				}

				tpsLastPostDate.Text = DateTime.Now.ToString();
			}
			catch
			{
			}
		}
		#endregion


		#region"【spotify処理】"

		/// <summary>
		/// spotify接続設定
		/// </summary>
		private void initSpotifySettings()
		{
			if (spotifyoAuth2Request == null)
			{
				spotifyoAuth2Request = new oAuth2Request()
				{
					auth_server_auth_endpoint = Properties.Settings.Default.Spotify_Endpoint_auth
					,
					auth_server_token_endpoint = Properties.Settings.Default.Spotify_Endpoint_token
					,
					client_id = Properties.Settings.Default.Spotify_ClientId
					,
					client_secret = Properties.Settings.Default.Spotify_ClientSecret
					,
					response_type = "code"
					,
					redirect_uri = Properties.Settings.Default.Spotify_Redirect_url
					,
					scope = Properties.Settings.Default.Spotify_oAuth_scope
				};
			}

			//接続設定
			if (!string.IsNullOrEmpty(Properties.Settings.Default.Spotify_Access_token) && !string.IsNullOrEmpty(Properties.Settings.Default.Spotify_Refresh_token))
			{
				spotifyoAuth2Response = new oAuth2Response()
				{
					access_token = Properties.Settings.Default.Spotify_Access_token
					,
					refresh_token = Properties.Settings.Default.Spotify_Refresh_token
					,
					token_type = "Bearer"
				};

				spotifyApi = new Dispatcher(spotifyoAuth2Request, spotifyoAuth2Response);

				if (spotifyApi != null)
				{
					tpsSpotifyApiStatus.Text = "Connected.";
					tpsSpotifyApiStatus.ForeColor = Color.Black;
				}

			}
		}

		/// <summary>
		/// spotify再生情報取得
		/// </summary>
		/// <param name="wait">取得開始までの待機時間(ms)</param>
		private async void setCurrentPlayback(Int32 wait)
		{
			try
			{
				if (wait != 0)
				{
					await Task.Delay(wait);
				}

				//再生情報を取得
				PrevPlayback = CurrentPlayback;
				CurrentPlayback = spotifyApi.GetCurrentPlayback(Properties.Settings.Default.Spotify_Markets);

				if (CurrentPlayback == null)
				{
					initPlayInfo();
					tpsSpotifyApiStatus.Text = "Error.";
					tpsSpotifyApiStatus.ForeColor = Color.Red;

					return;
				}

				tpsSpotifyApiStatus.Text = "Connected.";
				tpsSpotifyApiStatus.ForeColor = Color.Black;

				if (PrevPlayback == null || PrevPlayback.item.album.id != CurrentPlayback.item.album.id)
				{
					if (pbArtwork.BackgroundImage != null) pbArtwork.BackgroundImage.Dispose();
					pbArtwork.BackgroundImage = GetImage(CurrentPlayback.item.album.images[1].url);
				}

				if (lblAlubum.Text != CurrentPlayback.item.album.name)
					lblAlubum.Text = CurrentPlayback.item.album.name;

				if (lblAlbumArtist.Text != CurrentPlayback.item.album.artists[0].name)
					lblAlbumArtist.Text = CurrentPlayback.item.album.artists[0].name;

				if (lblReleaseDate.Text != CurrentPlayback.item.album.release_date)
					lblReleaseDate.Text = CurrentPlayback.item.album.release_date;

				lblTrackCount.Text = "";

				if (lblExplicit.Visible != CurrentPlayback.item.@explicit)
					lblExplicit.Visible = CurrentPlayback.item.@explicit;

				if (lblTrackName.Text != CurrentPlayback.item.name)
					lblTrackName.Text = CurrentPlayback.item.name;

				if (lblTrackArtist.Text != CurrentPlayback.item.artists[0].name)
					lblTrackArtist.Text = CurrentPlayback.item.artists[0].name;

				seekBarPlayPos.Minimum = 0;
				seekBarPlayPos.Maximum = CurrentPlayback.item.duration_ms;
				seekBarPlayPos.Value = CurrentPlayback.progress_ms;

				lblTrackTime.Text = msToTime(seekBarPlayPos.Maximum);
				lblPlayPos.Text = msToTime(seekBarPlayPos.Value);

				timer1.Enabled = CurrentPlayback.is_playing;

				setPlayButtonStyle(timer1.Enabled);

				//if (timer1.Enabled)
				//{
				//	timer1.Start();
				//}
				//else
				//{
				//	timer1.Stop();
				//}

				//リピート設定
				setRepeatButtonStyle(CurrentPlayback.repeat_state);

				//シャッフル設定

				//ボリューム設定
				trackBarVolume.Value = CurrentPlayback.device.volume_percent;
				setMuteButtonStyle();

				//再生デバイス
				setAvailableDevices(0);

				//title
				if (Properties.Settings.Default.ShowTitlebarInfo)
					Text = string.Format("{0} / {1} with {2}", lblTrackName.Text ,lblTrackArtist.Text, Properties.Settings.Default.AppName);

				//自動toot
				if (Properties.Settings.Default.Mastodon_Toot_TrackChangedAutoPost)
					TootNowPlaying(false);
			}
			catch
			{
			}
		}
		#endregion

		/// <summary>
		/// 再生情報のクリア
		/// </summary>
		private void initPlayInfo()
		{
			if (pbArtwork.BackgroundImage != null)
				pbArtwork.BackgroundImage.Dispose();

			lblAlubum.Text = "";
			lblTrackArtist.Text = "";

			lblReleaseDate.Text = "";
			lblTrackCount.Text = "";
			lblTrackTime.Text = "";

			lblTrackName.Text = "";
			lblTrackArtist.Text = "";
		}

		/// <summary>
		/// 時間表記変換
		/// </summary>
		/// <param name="ms"></param>
		/// <returns></returns>
		private string msToTime(double ms)
		{
			TimeSpan t = TimeSpan.FromMilliseconds(ms);
			return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
		}

		/// <summary>
		/// 画像を取得
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		private Image GetImage(string url)
		{
			int buffSize = 65536;
			MemoryStream imgStream = new MemoryStream();

			if (url == null || url.Trim().Length <= 0)
			{
				return null;
			}

			WebRequest req = WebRequest.Create(url);

			BinaryReader reader = new BinaryReader(req.GetResponse().GetResponseStream());

			while (true)
			{
				byte[] buff = new byte[buffSize];

				// 応答データの取得
				int readBytes = reader.Read(buff, 0, buffSize);
				if (readBytes <= 0)
				{
					// 最後まで取得した->ループを抜ける
					break;
				}

				// バッファに追加
				imgStream.Write(buff, 0, readBytes);
			}

			return new Bitmap(imgStream);
		}


		/// <summary>
		/// リピートボタン表示設定
		/// </summary>
		/// <param name="state"></param>
		private void setRepeatButtonStyle(string state)
		{
			switch (state)
			{
				case "off":
					btnRepeat.ForeColor = Color.DarkGray;
					btnRepeat.Text = "🔁";

					break;

				case "track":
					btnRepeat.ForeColor = Color.LimeGreen;
					btnRepeat.Text = "🔂 ";
					break;

				case "context":
					btnRepeat.ForeColor = Color.LimeGreen;
					btnRepeat.Text = "🔁";
					break;
			}
		}


		private void setPlayButtonStyle(bool state)
		{
			if (state)
			{
				timer1.Start();
				btnPlayPause.Text = "⏸️";
			}
			else
			{
				timer1.Stop();
				btnPlayPause.Text = "▶️";
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void setMuteButtonStyle()
		{
			if(trackBarVolume.Value == 0)
			{
				btnMute.Text = "🔇";

			}
			else if (trackBarVolume.Value < 50)
				{
				btnMute.Text = "🔉 ";
			}
			else
			{
				btnMute.Text = "🔊";
			}
		}




		private async void setAvailableDevices(Int32 wait)
		{
			cmbDeviceList.Items.Clear();

			if (wait != 0)
			{
				await Task.Delay(wait);
			}

			AvailableDevices = spotifyApi.GetAvailableDevices();

			if (AvailableDevices == null) return;

			foreach (Device dev in AvailableDevices.devices)
			{
				cmbDeviceList.Items.Add(dev.name);

				if (dev.is_active)
				{
					cmbDeviceList.Text = dev.name;
				}
			}
		}

		private Device getAvailableDevice()
		{
			foreach (Device dev in AvailableDevices.devices)
			{
				if (dev.is_active)
				{
					return dev;
				}
			}
			return null;
		}

		private Device getDeviceByName(string name)
		{
			foreach (Device dev in AvailableDevices.devices)
			{
				if (dev.name == name)
				{
					return dev;
				}
			}
			return null;
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			if (CurrentPlayback == null) return;

			CurrentPlayback.shuffle_state = !CurrentPlayback.shuffle_state;

			setShuffleButtonStyle();

			Device d = getAvailableDevice();

			if (d == null) return;

			spotifyApi.SetSuffleStatus(d,CurrentPlayback.shuffle_state);
		}

		/// <summary>
		/// シャッフルボタン表示設定
		/// </summary>
		private void setShuffleButtonStyle()
		{
			if (CurrentPlayback == null) return;

			if (CurrentPlayback.shuffle_state)
			{
				btnShuffle.ForeColor = Color.LimeGreen;
			}
			else
			{
				btnShuffle.ForeColor = Color.DarkGray;
			}
		}
	}
}