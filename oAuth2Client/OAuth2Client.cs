using commonUtil.oAuth2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace commonUtil.oAuth2
{

	public class Client : Form, IDisposable
	{
		private WebBrowser wb1 = null;
		private oAuth2Request _oAuth2Request = null;
		private oAuth2Response _oAuth2Response = null;
		private AuthorizeResponse res = new AuthorizeResponse();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="oAuth2Request"></param>
		public Client(oAuth2Request oAuth2Request)
		{
			InitializeComponent();
			_oAuth2Request = oAuth2Request;
		}

		/// <summary>
		/// お決まりのやつ
		/// </summary>
		private void InitializeComponent()
		{
			wb1 = new System.Windows.Forms.WebBrowser();
			SuspendLayout();
			//
			//wb1
			//
			wb1.Dock = DockStyle.Fill;
			wb1.Location = new System.Drawing.Point(165, 69);
			wb1.MinimumSize = new System.Drawing.Size(20, 20);
			wb1.Name = "wb1";
			wb1.Size = new System.Drawing.Size(518, 400);
			wb1.TabIndex = 0;
			wb1.DocumentCompleted += wb1_DocumentCompleted;
			wb1.DocumentTitleChanged += wb1_DocumentTitleChanged;
			wb1.Navigated += wb1_Navigated;

			//Form
			//
			AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(600, 600);
			Controls.Add(this.wb1);
			Name = "OAuth2Client";
			Text = "OAuth2Client";
			ResumeLayout(false);
			Visible = false;
			ShowIcon = false;
			Load += Client_Load;
		}

		/// <summary>
		/// フォーム表示イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Client_Load(object sender, EventArgs e)
		{
			_oAuth2Request.state = getRandomHash();

			string url
				= _oAuth2Request.auth_server_auth_endpoint
				+ "?client_id=" + WebUtility.UrlEncode(_oAuth2Request.client_id)
				+ "&response_type=" + WebUtility.UrlEncode(_oAuth2Request.response_type)
				+ "&redirect_uri=" + WebUtility.UrlEncode(_oAuth2Request.redirect_uri)
				+ "&scope=" + WebUtility.UrlEncode(_oAuth2Request.scope)
				+ "&state=" + WebUtility.UrlEncode(_oAuth2Request.state);

			wb1.Url = new Uri(url);
		}

		/// <summary>
		/// token返却口
		/// </summary>
		public oAuth2Response oAuth2Response
		{
			get { return _oAuth2Response; }
		}

		/// <summary>
		/// 認証コードをtokenに変換
		/// </summary>
		/// <returns></returns>
		public static oAuth2Response GetToken(oAuth2Request _oAuth2Request,string grant_type, string code)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					Encoding encoding = Encoding.UTF8;

					string sBasicAuth =
						string.Format("Basic {0}",
						Convert.ToBase64String(
							encoding.GetBytes(string.Format("{0}:{1}", _oAuth2Request.client_id, _oAuth2Request.client_secret))
							));

					webClient.Headers.Add(HttpRequestHeader.Authorization, sBasicAuth);
					webClient.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
					webClient.Encoding = Encoding.UTF8;

					NameValueCollection ps = new NameValueCollection();
					ps.Clear();
					ps.Add("redirect_uri", _oAuth2Request.redirect_uri);

					switch (grant_type)
					{
						case "authorization_code":
							ps.Add("grant_type", "authorization_code");
							ps.Add("code", code);
							break;

						case "refresh_token":
							ps.Add("grant_type", "refresh_token");
							ps.Add("refresh_token", code);
							break;
					}


					byte[] resData = webClient.UploadValues(_oAuth2Request.auth_server_token_endpoint, ps);

					webClient.Dispose();

					return JsonConvert.DeserializeObject<oAuth2Response>(Encoding.UTF8.GetString(resData));
				}

			}
			catch (WebException)
			{
				//webex.
				return null;

			}
		}

		private void wb1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			Text = wb1.DocumentTitle;
		}

		private void wb1_DocumentTitleChanged(object sender, EventArgs e)
		{
		}

		private void wb1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			string url = wb1.Url.AbsoluteUri;

			//token取得
			if (url.StartsWith(this._oAuth2Request.redirect_uri))
			{
				string s = url.Replace(string.Format("{0}?", this._oAuth2Request.redirect_uri), "");
				string[] v = s.Split('&');

				for (int i = 0; i <= v.Length - 1; i++)
				{
					string[] x = v[i].Split('=');

					switch (x[0])
					{
						case "code":
							res.code = x[1];
							break;

						case "error":
							res.error = x[1];
							break;

						case "state":
							res.state = x[1];
							break;
					}
				}

				//todo キャンセルイベント

				//codeありでstateが一致する場合だけ
				if (res.code != null && res.state == _oAuth2Request.state)
				{
					_oAuth2Response = GetToken(_oAuth2Request, "authorization_code", res.code);

					//画面閉じる
					Close();
				}
			}
		}
		/// <summary>
		/// SHA1ハッシュ乱数を生成
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		private string getRandomHash()
		{
			string result = "";
			try
			{
				byte[] random = new byte[101];
				SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
				RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

				rng.GetBytes(random);

				byte[] bs = sha1.ComputeHash(random);
				result = BitConverter.ToString(bs).ToLower().Replace("-", "");
			}
			catch
			{
			}
			return result;
		}

		/// <summary>
		/// 認証コード一時保存用
		/// </summary>
		class AuthorizeResponse
		{
			public string code { get; set; }
			public string error { get; set; }
			public string state { get; set; }
		}
	}
}
