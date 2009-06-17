using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class GeocodingResult
	{
		public string Name { get; set; }
		public GeocodingResultStatus Status { get; set; }
		public Placemark[] Placemark { get; set; }
	}
}
