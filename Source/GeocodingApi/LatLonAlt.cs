using System;

namespace GeocodingApi
{
	[Serializable]
	public class LatLonAlt
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Altitude { get; set; }

		public override string ToString()
		{
			return string.Format(
				"{0}, {1}, {2}",
				Latitude,
				Longitude,
				Altitude
				);
		}
	}
}
