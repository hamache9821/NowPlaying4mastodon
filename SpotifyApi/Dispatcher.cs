using commonUtil.oAuth2;
using commonUtil.oAuth2.Model;
using Newtonsoft.Json;
using spofity.api.model;
using Spotify.Api.model;
using SpotifyApi.model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

		#region"【Get】"

		/// <summary>
		/// 現在再生中を取得
		/// </summary>
		/// <returns></returns>
		public CurrentPlayback GetCurrentPlayback(string market)
		{
			return JsonConvert.DeserializeObject<CurrentPlayback>(getJson(Spotify_Endpoint.player_current_playback + "?market=" + market));
		}

		/// <summary>
		/// デバイス一覧を取得
		/// </summary>
		/// <returns></returns>
		public AvailableDevices GetAvailableDevices()
		{
			return JsonConvert.DeserializeObject<AvailableDevices>(getJson(Spotify_Endpoint.player_available_devices));
		}
		#endregion

		#region"【Set】"
		/// <summary>
		/// 次トラックへ
		/// </summary>
		/// <param name="devive">デバイス情報</param>
		public void SetPlaybackToNextTrack(Device devive)
		{
			httpPost(Spotify_Endpoint.player_next + "?device_id=" + devive.id);
		}

		/// <summary>
		/// 前トラックへ
		/// </summary>
		/// <param name="device">デバイス情報</param>
		public void SetPlaybackToPreviousTrack(Device device)
		{
			httpPost(Spotify_Endpoint.player_previous + "?device_id=" + device.id);
		}

		/// <summary>
		/// 再生停止
		/// </summary>
		/// <param name="d">デバイス情報</param>
		public void SetPlaybackToPause(Device d)
		{
			httpPut(Spotify_Endpoint.player_pause + "?device_id=" + d.id);
		}


		public void SetPlaybackToResume(Device device, ResumeRequestBase req)
		{
			//string json = "{\"context_uri\":\"spotify:album:5ht7ItJgpBH7W6vJ5BqpPr\",\"offset\":{\"position\":5}}";

			string json =  JsonConvert.SerializeObject(req);

			Console.Write(json);
			//httpPut(Spotify_Endpoint.player_pause + "?device_id=" + d.id);
		}

		/// <summary>
		/// 再生位置設定
		/// </summary>
		/// <param name="device">デバイス情報</param>
		/// <param name="position_ms">設定時間(ms)</param>
		public void SetSeekPosition(Device device, decimal position_ms)
		{
			httpPut(Spotify_Endpoint.player_seek + "?device_id=" + device.id + "&position_ms=" + position_ms.ToString());
		}

		/// <summary>
		/// リピート設定
		/// </summary>
		/// <param name="status"></param>
		public void SetRepeatStatus(string status)
		{
			httpPut(Spotify_Endpoint.player_repeat + "?state=" + status);
		}

		/// <summary>
		/// シャッフル設定
		/// </summary>
		/// <param name="device"></param>
		/// <param name="state"></param>
		public void SetSuffleStatus(Device device, bool state)
		{
			//httpPut(Endpoint.Spotify_Endpoint_repeat_playback + "?state=" + status);
		}

		/// <summary>
		/// 音量設定
		/// </summary>
		/// <param name="device"></param>
		/// <param name="volume_percent"></param>
		public void SetVolume(Device device, Int32 volume_percent)
		{
			httpPut(Spotify_Endpoint.player_volume + "?volume_percent=" + volume_percent);
		}

		public void SetTransferDevice(TransferRequest req)
		{

			var json = JsonConvert.SerializeObject(req);

			httpPut(Spotify_Endpoint.player_transfer, json);

		}

		#endregion








		#region"【http dispatcher】"
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
					//break;
				}
				catch (Exception)
				{
					//break;
				}

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
			HttpWebResponse HttpWebResponse = null;

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

				return ;
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					HttpWebResponse = (HttpWebResponse)ex.Response;

					if (HttpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
					{
						_oAuth2Response = Client.GetToken(_oAuth2Request, "refresh_token", _oAuth2Response.refresh_token);
					}
				}
			}
		}

		/// <summary>
		/// Http Put with json content
		/// </summary>
		/// <param name="url"></param>
		/// <param name="body"></param>
		private async void httpPut(string url, string body)
		{
			try
			{
				var request = new HttpRequestMessage()
				{
					Method = HttpMethod.Put,
					RequestUri = new Uri(url),
					Content = new StringContent(body, Encoding.UTF8, "application/json")
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
		#endregion
	}
}