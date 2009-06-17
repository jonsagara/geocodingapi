using System;

namespace GeocodingApi
{
	[Serializable]
	public class Country
	{
		public string CountryNameCode { get; set; }
		public string CountryName { get; set; }
		public AdministrativeArea AdministrativeArea { get; set; }
	}
}
