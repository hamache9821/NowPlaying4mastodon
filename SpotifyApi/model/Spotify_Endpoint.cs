namespace SpotifyApi.model
{
	public struct Spotify_Endpoint
	{
		public const string player_current_playback = "https://api.spotify.com/v1/me/player";
		public const string player_start = "https://api.spotify.com/v1/me/player/play";
		public const string player_pause = "https://api.spotify.com/v1/me/player/pause";
		public const string player_previous = "https://api.spotify.com/v1/me/player/previous";
		public const string player_next = "https://api.spotify.com/v1/me/player/next";
		public const string player_seek = "	https://api.spotify.com/v1/me/player/seek";
		public const string player_repeat = "https://api.spotify.com/v1/me/player/repeat";
		public const string player_shuffle = "https://api.spotify.com/v1/me/player/shuffle";

		public const string player_transfer = "	https://api.spotify.com/v1/me/player";
		public const string player_volume = "https://api.spotify.com/v1/me/player/volume";

		public const string player_available_devices = "https://api.spotify.com/v1/me/player/devices";

	}
}
