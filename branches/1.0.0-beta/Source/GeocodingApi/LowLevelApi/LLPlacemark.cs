using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLPlacemark
	{
		public string Id { get; set; }
		public string Address { get; set; }
		public LLAddressDetails AddressDetails { get; set; }
		public LLExtendedData ExtendedData { get; set; }
		public LLPoint Point { get; set; }
	}
}
