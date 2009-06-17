using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class AdministrativeArea
	{
		public string AdministrativeAreaName { get; set; }
		public Locality Locality { get; set; }
	}
}
