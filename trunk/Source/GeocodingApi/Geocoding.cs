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


#warning TODO: return a list of Placemark objects.
		public static object GeocodeAddress(string address)
		{
			return GeocodeAddress(address, false);
		}

		public static object GeocodeAddress(string address, bool sensor)
		{
			var requestParams = new Dictionary<string, string>
			{
				{"q", address},
				{"key", ApiKey},
				{"sensor", sensor.ToString().ToLower()},
				{"output", "json"},
				{"oe", "utf8"}
			};

			return LLGeocodingRequest.Execute(requestParams);
		}
	}
}
