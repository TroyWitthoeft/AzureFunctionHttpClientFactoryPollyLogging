using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;
using System;


[assembly: FunctionsStartup(typeof(Company.Function.Startup))]

namespace Company.Function
{
    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly
    //https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory#step-2-configure-a-client-with-polly-policies-in-startup
    public class Startup : FunctionsStartup
    {
        
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddHttpClient("pollyClient").AddPolicyHandler(GetRetryPolicy());    // Here we are adding "named" http clients.  Because they are used in lots of examples, we may want to consider using <typed> clients. 
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                        3, 
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,retryAttempt)),
                        onRetry: (outcome, timespan, retryAttempt, context) =>
                        {
                            var log = context.GetLogger();
                            log?.LogInformation($"Request failed with status code {outcome.Result.StatusCode} delaying for {timespan.TotalMilliseconds} milliseconds then making retry {retryAttempt}");
                        }
                );
        }
    }
}