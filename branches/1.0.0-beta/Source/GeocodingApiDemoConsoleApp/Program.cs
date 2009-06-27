using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GeocodingApi;

namespace GeocodingApiDemoConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			List<GeographicCoordinate> coords = Geocoding.GeocodeAddress("1600 Amphitheatre Parkway, Mountain View, CA 94043");
			coords.ForEach(coord => Console.WriteLine(coord));

#if DEBUG
			Console.WriteLine("Press ENTER to quit the application");
			Console.ReadLine();
#endif
		}
	}
}
