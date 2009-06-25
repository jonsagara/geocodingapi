using System;

namespace GeocodingApi.LowLevelApi
{
	[Serializable]
	internal class LLLatLonBox
	{
		public double North { get; set; }
		public double South { get; set; }
		public double East { get; set; }
		public double West { get; set; }
	}
}
