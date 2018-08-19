namespace SpotifyApi.model
{
	public struct Endpoint
	{
		public const string Spotify_Endpoint_current_playback = "https://api.spotify.com/v1/me/player";
		public const string Spotify_Endpoint_start_playback = "https://api.spotify.com/v1/me/player/play";
		public const string Spotify_Endpoint_pause_playback = "https://api.spotify.com/v1/me/player/pause";
		public const string Spotify_Endpoint_previous_playback = "https://api.spotify.com/v1/me/player/previous";
		public const string Spotify_Endpoint_next_playback = "https://api.spotify.com/v1/me/player/next";
		public const string Spotify_Endpoint_seek_playback = "	https://api.spotify.com/v1/me/player/seek";
		public const string Spotify_Endpoint_Available_Devices = "https://api.spotify.com/v1/me/player/devices";

	}
}
