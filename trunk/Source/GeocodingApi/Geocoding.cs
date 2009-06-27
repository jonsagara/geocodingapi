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


		public static List<Placemark> GeocodeAddress(string address)
		{
			return GeocodeAddress(address, false);
		}

		public static List<Placemark> GeocodeAddress(string address, bool sensor)
		{
			var requestParams = new Dictionary<string, string>
			{
				{"q", address},
				{"key", ApiKey},
				{"sensor", sensor.ToString().ToLower()},
				{"output", "json"},
				{"oe", "utf8"}
			};

			return ReadResult(LLGeocodingRequest.Execute(requestParams));
		}

		private static List<Placemark> ReadResult(LLGeocodingResult result)
		{
			List<Placemark> placemarks = new List<Placemark>(result.Placemark.Length);

			foreach (LLPlacemark llPlacemark in result.Placemark)
			{
				Placemark placemark = new Placemark
				{
					PlacemarkId = llPlacemark.Id,
					FormattedAddress = llPlacemark.Address,

					Address = ReadAddress(llPlacemark.AddressDetails),

					BoundedArea = new LatLonBox
					{
						North = llPlacemark.ExtendedData.LatLonBox.North,
						South = llPlacemark.ExtendedData.LatLonBox.South,
						East = llPlacemark.ExtendedData.LatLonBox.East,
						West = llPlacemark.ExtendedData.LatLonBox.West
					},

					Point = new LatLonAlt
					{
						Latitude = llPlacemark.Point.Coordinates[1],
						Longitude = llPlacemark.Point.Coordinates[0],
						Altitude = llPlacemark.Point.Coordinates[2]
					}
				};

				placemarks.Add(placemark);
			}

			return placemarks;
		}

		private static Address ReadAddress(LLAddressDetails llAddressDetails)
		{
			if (llAddressDetails == null)
				return null;

			return new Address
			{
				Street = llAddressDetails.Country.AdministrativeArea.Locality.Thoroughfare.ThoroughfareName,
				City = llAddressDetails.Country.AdministrativeArea.Locality.LocalityName,
				State = llAddressDetails.Country.AdministrativeArea.AdministrativeAreaName,
				PostalCode = llAddressDetails.Country.AdministrativeArea.Locality.PostalCode.PostalCodeNumber,
				Country = llAddressDetails.Country.CountryName,
				CountryCode = llAddressDetails.Country.CountryNameCode,
				Accuracy = llAddressDetails.Accuracy
			};
		}
	}
}
