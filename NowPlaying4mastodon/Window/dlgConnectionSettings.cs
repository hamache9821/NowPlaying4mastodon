using commonUtil.oAuth2;
using commonUtil.oAuth2.Model;
using System;
using System.Windows.Forms;
using TootNet;

namespace NowPlaying4mastodon
{
	public partial class dlgConfig : Form
	{
		Authorize _Authorize = null;

		oAuth2Request _spotifyoAuth2Request = null;
		oAuth2Response _spotifyoAuth2Response = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public dlgConfig()
		{
			InitializeComponent();
			Load += DlgConfig_Load;
			FormClosing += DlgConfig_FormClosing;

			txtMastodonUserInfo.Text = Properties.Settings.Default.Mastodon_Userinfo;
		}

		private void DlgConfig_FormClosing(object sender, FormClosingEventArgs e)
		{

			Properties.Settings.Default.Mastodon_Userinfo = txtMastodonUserInfo.Text;
			Properties.Settings.Default.Spotify_Markets = cmbTrackInfoRegin.Text;
			Properties.Settings.Default.Save();
		}

		private void DlgConfig_Load(object sender, EventArgs e)
		{
			cmbTrackInfoRegin.Text = Properties.Settings.Default.Spotify_Markets;

		}

		public oAuth2Request spotifyoAuth2Request
		{
			get { return _spotifyoAuth2Request; }
			set { _spotifyoAuth2Request = value; }

		}

		public oAuth2Response spotifyoAuth2Response
		{
			get { return _spotifyoAuth2Response; }
			set { _spotifyoAuth2Response = value; }

		}

		/// <summary>
		/// ますとどん認証ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnOpenAuthorizeWindow_Click(object sender, EventArgs e)
		{
			string[] s = txtMastodonUserInfo.Text.Split('@');

			if (s.Length != 2 || s[0] == string.Empty || s[1] == String.Empty)
				return;


			_Authorize = new Authorize()
			{
				ClientId = Properties.Settings.Default.Mastodon_ClientKey
			,
				ClientSecret = Properties.Settings.Default.Mastodon_ClientSecret
			};
			try
			{
				await _Authorize.CreateApp(s[1], s[0], Scope.Write);


				System.Diagnostics.Process.Start(_Authorize.GetAuthorizeUri());

				panel1.Visible = true;


				//oAuth2Request req = new oAuth2Request()
				//{
				//	auth_server_auth_endpoint = _Authorize.GetAuthorizeUri()
				//	,redirect_uri =""
				//};

				//using (dlgWebBrowser c = new dlgWebBrowser(req))
				//{
				//	c.ShowDialog(this);
				//}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), this.Name, MessageBoxButtons.OK);
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

		private void dlgConfig_Load(object sender, EventArgs e)
		{

		}

		private async void btnAuthorizeCodeVerify_Click(object sender, EventArgs e)
		{
			try
			{
				Tokens Tokens = await _Authorize.AuthorizeWithCode(txtAuthorizeCode.Text);

				if (Tokens != null)
				{

					Properties.Settings.Default.Mastodon_Access_token = Tokens.AccessToken;
					Properties.Settings.Default.Save();

					txtAuthorizeCode.Text = "";
					panel1.Visible = false;
				}
			}
			finally
			{
			}
		}
	}
}
