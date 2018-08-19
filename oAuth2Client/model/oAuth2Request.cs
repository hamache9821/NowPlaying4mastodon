
namespace commonUtil.oAuth2.Model
{
	public class oAuth2Request
	{
		public string client_id { get; set; }
		public string client_secret { get; set; }
		public string response_type { get; set; }
		public string redirect_uri { get; set; }
		public string state { get; set; }
		public string scope { get; set; }
		public string auth_server_auth_endpoint { get; set; }
		public string auth_server_token_endpoint { get; set; }
	}
}
