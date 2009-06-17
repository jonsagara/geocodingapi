using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class Country
	{
		public string CountryNameCode { get; set; }
		public string CountryName { get; set; }
		public AdministrativeArea AdministrativeArea { get; set; }
	}
}
