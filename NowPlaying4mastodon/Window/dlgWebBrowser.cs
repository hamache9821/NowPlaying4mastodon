using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Security.Authentication;
using System.Threading;
using System.Windows.Forms;
using commonUtil.oAuth2.Model;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace NowPlaying4mastodon
{

	public class dlgWebBrowser : Form
	{
		private WebBrowser wb1 = null;
		private oAuth2Request _oAuth2Request = null;
		private oAuth2Response _oAuth2Response = null;
		private AuthorizeResponse res = new AuthorizeResponse();

		private string _url = "";


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="url"></param>
		public dlgWebBrowser(string url)
		{
			InitializeComponent();
			_url = url;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="oAuth2Request"></param>
		public dlgWebBrowser(oAuth2Request oAuth2Request)
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
			Name = "dlgWebBrowser";
			Text = "dlgWebBrowser";
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
			//wb1.Url = new Uri(_url);
			wb1.Url = new Uri(_oAuth2Request.auth_server_auth_endpoint);
		}

		/// <summary>
		/// token返却口
		/// </summary>
		public string token
		{
			get { return res.code; }
		}

		/// <summary>
		/// 認証コードをtokenに変換
		/// </summary>
		/// <returns></returns>
		private oAuth2Response GetToken()
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
				ps.Add("grant_type", "authorization_code");
				ps.Add("code", res.code);
				ps.Add("redirect_uri", _oAuth2Request.redirect_uri);

				byte[] resData = webClient.UploadValues(_oAuth2Request.auth_server_token_endpoint, ps);

				webClient.Dispose();

				return JsonConvert.DeserializeObject<oAuth2Response>(Encoding.UTF8.GetString(resData));
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
					_oAuth2Response = GetToken();

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
