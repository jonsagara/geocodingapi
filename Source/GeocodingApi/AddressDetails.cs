using System;

namespace GeocodingApi
{
	[Serializable]
	public class AddressDetails
	{
		public Country Country { get; set; }
		public int Accuracy { get; set; }
	}
}
