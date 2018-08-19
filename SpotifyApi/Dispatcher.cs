using commonUtil.oAuth2;
using commonUtil.oAuth2.Model;
using Newtonsoft.Json;
using spofity.api.model;
using SpotifyApi.model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace spofity.api
{
	/// <summary>
	/// spotify api dispatcher
	/// </summary>
	public class Dispatcher
	{
		private oAuth2Request _oAuth2Request = null;
		private oAuth2Response _oAuth2Response = null;
		private HttpClient httpClient = new HttpClient();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="req"></param>
		/// <param name="res"></param>
		public Dispatcher(oAuth2Request req, oAuth2Response res)
		{
			_oAuth2Request = req;
			_oAuth2Response = res;
		}

		/// <summary>
		/// 現在再生中を取得
		/// </summary>
		/// <returns></returns>
		public CurrentPlayback GetCurrentPlayback(string market)
		{
			return JsonConvert.DeserializeObject<CurrentPlayback>(getJson(Endpoint.Spotify_Endpoint_current_playback + "?market=" + market));
		}

		/// <summary>
		/// デバイス一覧を取得
		/// </summary>
		/// <returns></returns>
		public AvailableDevices GetAvailableDevices()
		{
			return JsonConvert.DeserializeObject<AvailableDevices>(getJson(Endpoint.Spotify_Endpoint_Available_Devices));
		}

		/// <summary>
		/// 次トラックへ
		/// </summary>
		/// <param name="d">デバイス情報</param>
		public void SetPlaybackToNextTrack(Device d)
		{
			httpPost(Endpoint.Spotify_Endpoint_next_playback + "?device_id=" + d.id);
		}

		/// <summary>
		/// 前トラックへ
		/// </summary>
		/// <param name="d">デバイス情報</param>
		public void SetPlaybackToPreviousTrack(Device d)
		{
			httpPost(Endpoint.Spotify_Endpoint_previous_playback + "?device_id=" + d.id);
		}

		/// <summary>
		/// 再生停止
		/// </summary>
		/// <param name="d">デバイス情報</param>
		public void SetPlaybackToPause(Device d)
		{
			httpPut(Endpoint.Spotify_Endpoint_pause_playback + "?device_id=" + d.id);
		}

		/// <summary>
		/// 再生位置設定
		/// </summary>
		/// <param name="d">デバイス情報</param>
		/// <param name="position_ms">設定時間(ms)</param>
		public void SetSeekPosition(Device d, decimal position_ms)
		{
			httpPut(Endpoint.Spotify_Endpoint_seek_playback + "?device_id=" + d.id + "&position_ms=" + position_ms.ToString());
		}


		/// <summary>
		/// json取得
		/// </summary>
		/// <param name="url">endpoint</param>
		/// <returns></returns>
		private string getJson(string url)
		{
			if (_oAuth2Response == null) return "";

			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add(HttpRequestHeader.Accept, " application/json");
				webClient.Headers.Add(HttpRequestHeader.ContentType, " application/json");
				webClient.Encoding = Encoding.UTF8;
				webClient.Headers.Add(HttpRequestHeader.Authorization, string.Format("{0} {1}", _oAuth2Response.token_type, _oAuth2Response.access_token));

				string json = "";
				do
				{
					try
					{
						json = webClient.DownloadString(url);
					}
					catch (WebException ex)
					{
						if (ex.Status == WebExceptionStatus.ProtocolError)
						{
							HttpWebResponse HttpWebResponse = (HttpWebResponse)ex.Response;

							if (HttpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
							{
								_oAuth2Response = Client.GetToken(_oAuth2Request, "refresh_token", _oAuth2Response.refresh_token);
							}
						}
						break;
					}
					catch (Exception)
					{
						break;
					}
				} while (string.IsNullOrEmpty(json));

				return json;
			}
		}

		/// <summary>
		/// Http Post
		/// </summary>
		/// <param name="url"></param>
		private async void httpPost(string url)
		{
			try
			{
				var request = new HttpRequestMessage()
				{
					Method = HttpMethod.Post,
					RequestUri = new Uri(url)
				};

				request.Headers.Authorization
					= new AuthenticationHeaderValue(_oAuth2Response.token_type, _oAuth2Response.access_token);

				var response = await httpClient.SendAsync(request);

				return;
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					HttpWebResponse HttpWebResponse = (HttpWebResponse)ex.Response;

					if (HttpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
					{
						_oAuth2Response = Client.GetToken(_oAuth2Request, "refresh_token", _oAuth2Response.refresh_token);
					}
				}
			}
		}

		/// <summary>
		/// Http Put
		/// </summary>
		/// <param name="url"></param>
		private async void httpPut(string url)
		{
			try
			{
				var request = new HttpRequestMessage()
				{
					Method = HttpMethod.Put,
					RequestUri = new Uri(url)
				};

				request.Headers.Authorization
					= new AuthenticationHeaderValue(_oAuth2Response.token_type, _oAuth2Response.access_token);

				var response = await httpClient.SendAsync(request);

				return;
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					HttpWebResponse HttpWebResponse = (HttpWebResponse)ex.Response;

					if (HttpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
					{
						_oAuth2Response = Client.GetToken(_oAuth2Request, "refresh_token", _oAuth2Response.refresh_token);
					}
				}
			}
		}



	}
}