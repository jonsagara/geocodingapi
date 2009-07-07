using System;
using System.Collections.Generic;
using System.Configuration;

using GeocodingApi.LowLevelApi;

namespace GeocodingApi
{
	/// <summary>
	/// Wrapper for returning results from Google's Geocoding API.
	/// </summary>
	public static class Geocoding
	{
		#region Instance Properties

		private static string ApiKey
		{
			get
			{
				string apiKey = ConfigurationManager.AppSettings["GeocodingApi.Key"];
				if (string.IsNullOrEmpty(apiKey))
				{
					throw new ArgumentException("Missing GeocodingApi.Key from config file.  This should be your Google Maps API key");
				}

				return apiKey;
			}
		}

		#endregion


		/// <summary>
		/// Obtain the geographic coordinates of the specified address.  May return multiple sets
		/// of coordinates.
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static List<GeographicCoordinate> Geocode(string address)
		{
			return Geocode(address, false);
		}

		/// <summary>
		/// Obtain the geographic coordinates of the specified address.  May return multiple sets
		/// of coordinates.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="sensor">Use of the Google Maps API now requires that you indicate whether your application is using a sensor (such as a GPS locator) to determine the user's location.  Applications that determine the user's location via a sensor must true.</param>
		/// <returns></returns>
		public static List<GeographicCoordinate> Geocode(string address, bool sensor)
		{
			var requestParams = new Dictionary<string, string>
			{
				{"q", address},
				{"key", ApiKey},
				{"sensor", sensor.ToString().ToLowerInvariant()},
				{"output", "json"},
				{"oe", "utf8"}
			};

			return ReadResult(LLGeocodingRequest.Execute(requestParams));
		}


		#region Helpers

		private static List<GeographicCoordinate> ReadResult(LLGeocodingResult result)
		{
			List<GeographicCoordinate> coords = new List<GeographicCoordinate>();
			if (result.Placemark == null || result.Placemark.Length == 0)
			{
				return coords;
			}

			foreach (LLPlacemark llPlacemark in result.Placemark)
			{
				coords.Add(new GeographicCoordinate
				{
					Latitude = llPlacemark.Point.Coordinates[1],
					Longitude = llPlacemark.Point.Coordinates[0],
					Altitude = llPlacemark.Point.Coordinates[2]
				});
			}

			return coords;
		}

		#endregion
	}
}
