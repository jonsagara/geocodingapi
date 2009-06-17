using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class Locality
	{
		public string LocalityName { get; set; }
		public Thoroughfare Thoroughfare { get; set; }
		public PostalCode PostalCode { get; set; }
	}
}
