using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

using Newtonsoft.Json;

namespace GeocodingApi
{
	public class GeocodingRequest
	{
		#region Class Properties

		public static string ApiUrl
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


		public static GeocodingResult Execute(IDictionary<string, string> requestParams)
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
				return JsonConvert.DeserializeObject<GeocodingResult>(jsonResponse);
			}
		}

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
