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
			List<Placemark> placemarks = Geocoding.GeocodeAddress("1600 Amphitheatre Parkway, Mountain View, CA 94043");
			placemarks.ForEach(placemark => Console.WriteLine(placemark.Point));

#if DEBUG
			Console.WriteLine("Press ENTER to quit the application");
			Console.ReadLine();
#endif
		}
	}
}
