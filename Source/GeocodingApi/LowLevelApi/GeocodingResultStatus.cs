using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class GeocodingResultStatus
	{
		public int Code { get; set; }
		public string Request { get; set; }
	}
}
