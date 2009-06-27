using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLGeocodingResultStatus
	{
		public int Code { get; set; }
		public string Request { get; set; }
	}
}
