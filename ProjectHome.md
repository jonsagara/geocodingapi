This is a small C# wrapper of the Google Maps geocoding service.

Simply put, the API exposes a method that takes an address string as input and returns a list of any matching geographic coordinates.

### Usage ###

**Restrictions**

There are some restrictions on usage of Google's geocoding service, most notably [the following](http://code.google.com/apis/maps/documentation/geocoding/index.html):

> Note: the geocoding service may only be used in conjunction with displaying results on a Google map; geocoding results without displaying them on a map is prohibited.

More information is available at [Maps API Terms of Service License Restrictions](http://code.google.com/apis/maps/terms.html#section_10_12) and [Google Maps API Services - Geocoding](http://code.google.com/apis/maps/documentation/geocoding/index.html).

**App.config or Web.config**

Your application's App.config or Web.config will need the following `<appSettings />` elements:

```
<add key="GeocodingApi.Key" value="{your_api_key}" />
<add key="GeocodingApi.Url" value="http://maps.google.com/maps/geo?" />
```

You will, of course, need to replace "{your\_api\_key}" with your actual Google Maps API key.

**Sample code**

```
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

### Requirements ###

This library uses [Json.NET](http://www.codeplex.com/Json), which requires .NET Framework  3.5 SP1; hence, this library also requires .NET Framework 3.5 SP1.