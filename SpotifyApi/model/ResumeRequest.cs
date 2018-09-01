using System.Collections.Generic;

namespace Spotify.Api.model
{
	/// <summary>
	/// 
	/// </summary>
	public class ResumeRequestBase
	{
		public int position_ms { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class ResumeUrisRequest : ResumeRequestBase
	{
		public List<string> uris { get; set; }
		public OffsetUris offset { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public class OffsetUris
		{
			public int position { get; set; }
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class ResumeContextRequest : ResumeRequestBase
	{
		public string context_uri { get; set; }
		public OffsetContext_uri offset { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public class OffsetContext_uri
		{
			public string uri { get; set; }
		}
	}

}
