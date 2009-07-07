using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLAdministrativeArea
	{
		public string AdministrativeAreaName { get; set; }
		public LLLocality Locality { get; set; }
	}
}
