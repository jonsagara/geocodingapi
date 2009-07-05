using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLGeocodingResult
	{
		public string Name { get; set; }
		public LLGeocodingResultStatus Status { get; set; }
		public LLPlacemark[] Placemark { get; set; }
	}
}
