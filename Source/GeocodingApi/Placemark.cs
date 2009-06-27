using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeocodingApi
{
	/// <summary>
	/// Multiple placemarks may be returned if the geocoder finds multiple matches.
	/// </summary>
	[Serializable]
	public class Placemark
	{
		public string PlacemarkId { get; set; }

		/// <summary>
		/// A nicely formatted and properly capitalized version of the address.
		/// </summary>
		public string FormattedAddress { get; set; }

		public Address Address { get; set; }

		public LatLonBox BoundedArea { get; set; }

		public LatLonAlt Point { get; set; }
	}
}
