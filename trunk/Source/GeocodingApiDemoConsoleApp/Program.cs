using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

using GeocodingApi;

namespace GeocodingApiDemoConsoleApp
{
	class Program
	{
		#region Class Data

		private static readonly List<string> Addresses = new List<string>
		{
			"1600 Amphitheatre Parkway, Mountain View, CA 94043",		// Google
			"1 Microsoft Way, Redmond, WA 98052",						// Microsoft
			"1601 S. California Ave., Palo Alto, CA 95304",				// Facebook
			"701 First Ave, Sunnyvale, CA 94089"						// Yahoo
		};

		/// <summary>
		/// The API is rate limited.  1 request every 0.5 seconds seems to keep Google happy.
		/// </summary>
		private static readonly int DelayInMs = 500;

		#endregion


		static void Main(string[] args)
		{
			foreach (string address in Addresses)
			{
				Geocoding.Geocode(address)
					.ForEach(coordinate => DisplayCoordinate(coordinate, address));

				Thread.Sleep(DelayInMs);
			}

			#region DEBUG only
#if DEBUG
			Console.WriteLine("Press ENTER to quit the application");
			Console.ReadLine();
#endif
			#endregion
		}


		private static void DisplayCoordinate(GeographicCoordinate coordinate, string address)
		{
			Console.WriteLine("Geographic coordinate for '{0}':", address);
			Console.WriteLine(
				"\t* Latitude: {0}, Longitude: {1}",
				coordinate.Latitude,
				coordinate.Longitude
				);
		}
	}
}
