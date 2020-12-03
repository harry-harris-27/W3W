# W3W

![CI](https://github.com/harry-harris-27/W3W/workflows/CI/badge.svg)

A .NET wrapper library for the [what3words v3 API](https://docs.what3words.com/api/v3/).

All API methods are grouped into a single service interface (IWhat3WordsService), allowing for easy intropability with Dependency Injection applications. This service interface is implemented through the What3WordsService class, that takes your API key as a constructor argument.

## Documentation
See the what3words public API [documentation](https://docs.what3words.com/api/v3/).

## General Usage
```C#
// Instantiate What3WordsService instance using your API key
IWhat3WordsService what3wordsService = new What3WordsService("your-api-key-here");

// It is also possible to pass custom URLs to the What3WordsService to allow for access to your 
// servers, if you run the what3words Enterprise Suite API Server yourself.
//IWhat3WordsService what3wordsService = new What3WordsService("your-api-key-here", "your-enterprise-suite-server-url-here");

try
{
  What3WordsConversion conversion = await what3wordsService.ConvertAsync("filled.count.soap");
}
catch (What3WordsException w3wEx)
{
  // Handle error...
}
catch (Exception ex)
{
  // Handle error, likely connectivity error
}
```
