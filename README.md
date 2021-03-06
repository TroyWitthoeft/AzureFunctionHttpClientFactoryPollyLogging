# Azure Function HttpClientFactory Polly Logging

![Azure Functions](https://raw.githubusercontent.com/Runamok81/AzureFunctionHttpClientFactoryPollyLogging/master/Images/azure-functions-logo-color-raster.png)![Polly](https://raw.githubusercontent.com/Runamok81/AzureFunctionHttpClientFactoryPollyLogging/master/Images/Polly-Logo%402x.png)![dotnetcore](https://raw.githubusercontent.com/Runamok81/AzureFunctionHttpClientFactoryPollyLogging/master/Images/dotnetcore.png)

A quick example of how to build a resilient http endpoint.  This project uses 

  - VS Code (+ Azure Functions Extension)
  - C#
  - .NET Core 3.1
  - Azure Functions V3 (Http Trigger)
  - HttpClientFactory 
  - Dependency Injection
  - Polly with exponential retries and retry logging.

![Example](https://raw.githubusercontent.com/Runamok81/AzureFunctionHttpClientFactoryPollyLogging/master/Images/VSCodeTerminalPollyLog3.gif)

This github project was informed by the following articles.
- [Use HttpClientFactory to implement resilient HTTP requests](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)

- [Using Polly with HttpClient factory from ASPNET Core 2.1](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory#using-polly-with-httpclient-factory-from-aspnet-core-21)

Special thanks to Jeff H.
