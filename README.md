This is a small C# wrapper of the Google Maps geocoding service.

Simply put, the API exposes a method that takes an address string as input and returns a list of any matching geographic coordinates.

## Usage

### Restrictions

There are some restrictions on usage of Google's geocoding service, most notably the following:

> No Use of Content without a Google Map. You must not use or display the Content without a corresponding Google map, unless you are explicitly permitted to do so in the Maps APIs Documentation. In any event, you must not use or display the Content on or in conjunction with a non-Google map. For example, you must not use geocodes obtained through the Service in conjunction with a non-Google map. As another example, you must not display Street View imagery alongside a non-Google map, but you may display Street View imagery without a corresponding Google map because the Maps APIs Documentation explicitly permits you to do so.

More information is available at [Maps API Terms of Service License Restrictions](https://developers.google.com/maps/terms?csw=1#section_10_12).

### App.config or Web.config

Your application's App.config or Web.config will need the following `<appSettings />` elements:

```xml
<add key="GeocodingApi.Key" value="{your_api_key}" />
<add key="GeocodingApi.Url" value="http://maps.google.com/maps/geo?" />
```

You will, of course, need to replace `{your_api_key}` with your actual Google Maps API key.

### Sample code

```csharp
private static readonly List<string> Addresses = new List<string>
{
    "1600 Amphitheatre Parkway, Mountain View, CA 94043",       // Google
    "1 Microsoft Way, Redmond, WA 98052",                       // Microsoft
    "1601 S. California Ave., Palo Alto, CA 95304",             // Facebook
    "701 First Ave, Sunnyvale, CA 94089"                        // Yahoo
};

// The API is rate limited.  1 request every 0.5 seconds seems to keep Google happy.
private static readonly int DelayInMs = 500;

static void Main(string[] args)
{
    foreach (string address in Addresses)
    {
        Geocoding.Geocode(address)
            .ForEach(coordinate => DisplayCoordinate(coordinate, address));

        Thread.Sleep(DelayInMs);
    }
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
```

## Requirements and Dependencies

This library is compiled against the .NET Framework 4.5.2.

It uses the latest version of [Json.NET](https://github.com/JamesNK/Newtonsoft.Json).