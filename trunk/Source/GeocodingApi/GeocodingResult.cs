using System;

namespace GeocodingApi
{
	[Serializable]
	public class GeocodingResult
	{
		public string Name { get; set; }
		public GeocodingResultStatus Status { get; set; }
		public Placemark[] Placemark { get; set; }
	}
}
