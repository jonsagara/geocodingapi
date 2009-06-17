using System;

namespace GeocodingApi
{
	[Serializable]
	public class AdministrativeArea
	{
		public string AdministrativeAreaName { get; set; }
		public Locality Locality { get; set; }
	}
}
