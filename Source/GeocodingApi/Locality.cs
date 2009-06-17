using System;

namespace GeocodingApi
{
	[Serializable]
	public class Locality
	{
		public string LocalityName { get; set; }
		public Thoroughfare Thoroughfare { get; set; }
		public PostalCode PostalCode { get; set; }
	}
}
