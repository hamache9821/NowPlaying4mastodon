using commonUtil.oAuth2;
using commonUtil.oAuth2.Model;
using System;
using System.Windows.Forms;
using TootNet;

namespace NowPlaying4mastodon
{
	public partial class dlgConnectionSettings : Form
	{
		Authorize _Authorize = null;
		oAuth2Request _spotifyoAuth2Request = null;
		oAuth2Response _spotifyoAuth2Response = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public dlgConnectionSettings()
		{
			InitializeComponent();
			Load += dlgConnectionSettings_Load;
			FormClosing += dlgConnectionSettings_FormClosing;

			txtMastodonInstanceDomain.Text = Properties.Settings.Default.Mastodon_Userinfo;
		}

		#region"【property】"
		/// <summary>
		/// 
		/// </summary>
		public oAuth2Request spotifyoAuth2Request
		{
			get { return _spotifyoAuth2Request; }
			set { _spotifyoAuth2Request = value; }

		}

		/// <summary>
		/// 
		/// </summary>
		public oAuth2Response spotifyoAuth2Response
		{
			get { return _spotifyoAuth2Response; }
			set { _spotifyoAuth2Response = value; }

		}
		#endregion

		#region"【event handler】"
		private void dlgConnectionSettings_Load(object sender, EventArgs e)
		{
			cmbTrackInfoRegin.Text = Properties.Settings.Default.Spotify_Markets;
		}

		private void dlgConnectionSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Mastodon_Userinfo = txtMastodonInstanceDomain.Text;
			Properties.Settings.Default.Spotify_Markets = cmbTrackInfoRegin.Text;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// mastodon認証ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnOpenAuthorizeWindow_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMastodonInstanceDomain.Text.Trim())) return;

			_Authorize = new Authorize()
			{
				ClientId = Properties.Settings.Default.Mastodon_ClientKey
			,
				ClientSecret = Properties.Settings.Default.Mastodon_ClientSecret
			};

			try
			{
				await _Authorize.CreateApp(txtMastodonInstanceDomain.Text.Trim(), Properties.Settings.Default.AppName, Scope.Write);

				System.Diagnostics.Process.Start(_Authorize.GetAuthorizeUri());

				panel1.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), this.Name, MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// mastodon認証コード確認ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnAuthorizeCodeVerify_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtAuthorizeCode.Text == "") return;

				Tokens Tokens = await _Authorize.AuthorizeWithCode(txtAuthorizeCode.Text);

				if (Tokens != null)
				{
					Properties.Settings.Default.Mastodon_Access_token = Tokens.AccessToken;
					Properties.Settings.Default.Save();

					txtAuthorizeCode.Text = "";
					panel1.Visible = false;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// spotify認証ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenSpotifyAuthorization_Click(object sender, EventArgs e)
		{
			using (Client c = new Client(_spotifyoAuth2Request))
			{
				c.ShowDialog(this);
				_spotifyoAuth2Response = c.oAuth2Response;
				c.Dispose();
			}

			if (_spotifyoAuth2Response != null)
			{
				//設定保存
				Properties.Settings.Default.Spotify_Refresh_token = _spotifyoAuth2Response.refresh_token;
				Properties.Settings.Default.Spotify_Access_token = _spotifyoAuth2Response.access_token;
				Properties.Settings.Default.Save();
			}
		}
		#endregion
	}
}