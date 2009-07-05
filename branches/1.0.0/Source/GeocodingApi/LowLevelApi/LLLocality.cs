using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLLocality
	{
		public string LocalityName { get; set; }
		public LLThoroughfare Thoroughfare { get; set; }
		public LLPostalCode PostalCode { get; set; }
	}
}
