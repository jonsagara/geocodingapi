using System;

namespace GeocodingApi
{
	[Serializable]
	public class GeocodingResultStatus
	{
		public int Code { get; set; }
		public string Request { get; set; }
	}
}
