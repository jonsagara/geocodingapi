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


		#region Helpers

		private static List<Placemark> ReadResult(LLGeocodingResult result)
		{
			if (result.Placemark == null)
				return new List<Placemark>();

			List<Placemark> placemarks = new List<Placemark>(result.Placemark.Length);

			foreach (LLPlacemark llPlacemark in result.Placemark)
			{
				Placemark placemark = new Placemark
				{
					PlacemarkId = llPlacemark.Id,
					FormattedAddress = llPlacemark.Address,
					Address = ReadAddress(llPlacemark.AddressDetails),
					BoundedArea = ReadBoundedArea(llPlacemark.ExtendedData),
					Point = ReadPoint(llPlacemark.Point)
				};

				placemarks.Add(placemark);
			}

			return placemarks;
		}

		private static Address ReadAddress(LLAddressDetails llAddressDetails)
		{
			if (llAddressDetails == null)
				return null;

			Address address = new Address
			{
				Accuracy = llAddressDetails.Accuracy
			};

			if (llAddressDetails.Country != null)
			{
				address.Country = llAddressDetails.Country.CountryName;
				address.CountryCode = llAddressDetails.Country.CountryNameCode;

				if (llAddressDetails.Country.AdministrativeArea != null)
				{
					address.State = llAddressDetails.Country.AdministrativeArea.AdministrativeAreaName;

					if (llAddressDetails.Country.AdministrativeArea.Locality != null)
					{
						address.City = llAddressDetails.Country.AdministrativeArea.Locality.LocalityName;

						if (llAddressDetails.Country.AdministrativeArea.Locality.PostalCode != null)
						{
							address.PostalCode = llAddressDetails.Country.AdministrativeArea.Locality.PostalCode.PostalCodeNumber;
						}

						if (llAddressDetails.Country.AdministrativeArea.Locality.Thoroughfare != null)
						{
							address.Street = llAddressDetails.Country.AdministrativeArea.Locality.Thoroughfare.ThoroughfareName;
						}
					}
				}
			}

			return address;
		}

		private static LatLonBox ReadBoundedArea(LLExtendedData llExtendedData)
		{
			if (llExtendedData == null)
				return null;

			if (llExtendedData.LatLonBox == null)
				return null;

			return new LatLonBox
			{
				North = llExtendedData.LatLonBox.North,
				South = llExtendedData.LatLonBox.South,
				East = llExtendedData.LatLonBox.East,
				West = llExtendedData.LatLonBox.West
			};
		}

		private static LatLonAlt ReadPoint(LLPoint llPoint)
		{
			if (llPoint == null)
				return null;

			return new LatLonAlt
			{
				Latitude = llPoint.Coordinates[1],
				Longitude = llPoint.Coordinates[0],
				Altitude = llPoint.Coordinates[2]
			};
		}

		#endregion
	}
}
