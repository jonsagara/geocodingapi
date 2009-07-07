using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLCountry
	{
		public string CountryNameCode { get; set; }
		public string CountryName { get; set; }
		public LLAdministrativeArea AdministrativeArea { get; set; }
	}
}
