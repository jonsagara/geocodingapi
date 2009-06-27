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
			string address = "1600 Amphitheatre Parkway, Mountain View, CA 94043";
			List<GeographicCoordinate> coords = Geocoding.GeocodeAddress(address);

			Console.WriteLine("Coordinates for address \"{0}\":", address);
			if (coords.Count == 0)
			{
				Console.WriteLine("\tNone returned for this address");
			}
			else
			{
				coords.ForEach(
					coord =>
					{
						Console.WriteLine(
							"\t* Latitude: {0}, Longitude: {1}, Altitude: {2}",
							coord.Latitude,
							coord.Longitude,
							coord.Altitude
							);
					}
					);
			}

#if DEBUG
			Console.WriteLine("Press ENTER to quit the application");
			Console.ReadLine();
#endif
		}
	}
}
