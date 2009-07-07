using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLAddressDetails
	{
		public LLCountry Country { get; set; }
		public int Accuracy { get; set; }
	}
}
