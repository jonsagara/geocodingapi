using System;
using System.Collections.Generic;
using System.Configuration;

namespace GeocodingApi
{
	public class Geocoding
	{
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


		public static GeocodingResult GeocodeAddress(string address)
		{
			var requestParams = new Dictionary<string, string>
			{
				{"q", address},
				{"key", ApiKey},
				{"sensor", "false"},
				{"output", "json"},
				{"oe", "utf8"}
			};

			return GeocodingRequest.Execute(requestParams);
		}
	}
}
