using System.Collections.Generic;

namespace spofity.api.model
{
	/// <summary>
	/// 
	/// </summary>
	public class TransferRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public TransferRequest()
		{
			device_ids = new List<string>();
			play = false;
		}

		public List<string> device_ids { get; set; }
		public bool play { get; set; }
	}
}
