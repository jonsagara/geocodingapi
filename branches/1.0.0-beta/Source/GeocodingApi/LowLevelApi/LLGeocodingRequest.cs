using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

using Newtonsoft.Json;

namespace GeocodingApi.LowLevelApi
{
	internal class LLGeocodingRequest
	{
		#region Class Properties

		/// <summary>
		/// The base API URL, up to and including the query string question mark.  The parameters 
		/// will be appended as query string parameters.
		/// </summary>
		private static string ApiUrl
		{
			get
			{
				string apiUrl = ConfigurationManager.AppSettings["GeocodingApi.Url"];

				if (string.IsNullOrEmpty(apiUrl))
				{
					throw new ArgumentException("Missing GeocodingApi.Url from config file.  This should be \"http://maps.google.com/maps/geo?\"");
				}

				if (!apiUrl.EndsWith("?"))
				{
					throw new ArgumentException("GeocodingApi.Url should be \"http://maps.google.com/maps/geo?\" (note the trailing question mark)");
				}

				return apiUrl;
			}
		}

		#endregion


		/// <summary>
		/// Call the geocoding API with the given request parameters.
		/// </summary>
		/// <param name="requestParams"></param>
		/// <returns></returns>
		internal static LLGeocodingResult Execute(IDictionary<string, string> requestParams)
		{
			string requestUrl = GetRequestUrl(requestParams);
			HttpWebRequest req = WebRequest.Create(requestUrl) as HttpWebRequest;
			if (req == null)
			{
				throw new Exception("Unable to create an HTTP request for URL " + requestUrl);
			}


			using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
			using (StreamReader respReader = new StreamReader(resp.GetResponseStream()))
			{
				string jsonResponse = respReader.ReadToEnd();
				return JsonConvert.DeserializeObject<LLGeocodingResult>(jsonResponse);
			}
		}

		/// <summary>
		/// Constructs the request URL using the provided dictionary of request parameters.
		/// </summary>
		/// <param name="requestParams"></param>
		/// <returns></returns>
		private static string GetRequestUrl(IDictionary<string, string> requestParams)
		{
			StringBuilder qsParams = new StringBuilder();

			foreach (string key in requestParams.Keys)
			{
				if (qsParams.Length > 0)
				{
					qsParams.Append("&");
				}

				qsParams.AppendFormat("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(requestParams[key]));
			}

			return string.Format("{0}{1}", ApiUrl, qsParams.ToString());
		}
	}
}
