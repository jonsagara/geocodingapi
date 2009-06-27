using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeocodingApi
{
	[Serializable]
	public class Address
	{
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }

		/// <summary>
		/// An attribute indicating how accurately Google were able to geocode the given address.
		/// See http://code.google.com/apis/maps/documentation/reference.html#GGeoAddressAccuracy
		/// </summary>
		public int Accuracy { get; set; }
	}
}
