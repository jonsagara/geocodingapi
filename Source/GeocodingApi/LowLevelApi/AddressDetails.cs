using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class AddressDetails
	{
		public Country Country { get; set; }
		public int Accuracy { get; set; }
	}
}
