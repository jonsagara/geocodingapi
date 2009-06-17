using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class Placemark
	{
		public string Id { get; set; }
		public string Address { get; set; }
		public AddressDetails AddressDetails { get; set; }
		public ExtendedData ExtendedData { get; set; }
		public Point Point { get; set; }
	}
}
