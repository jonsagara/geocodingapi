using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeocodingApi
{
	[Serializable]
	public class LatLonBox
	{
		public double North { get; set; }
		public double South { get; set; }
		public double East { get; set; }
		public double West { get; set; }
	}
}
