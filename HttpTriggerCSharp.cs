using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Polly;

namespace Company.Function
{
    public class HttpTriggerCSharp
    {
        private readonly IHttpClientFactory _factory;

        public HttpTriggerCSharp(IHttpClientFactory httpClientFactory) 
        {
            _factory = httpClientFactory;
        }
        
        [FunctionName("HttpTriggerCSharp")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            var pollyContext = new Context().WithLogger(log);
            HttpClient pollyClient = _factory.CreateClient("pollyClient");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://httpstat.us/408");
            request.SetPolicyExecutionContext(pollyContext); 
            var response = await pollyClient.SendAsync(request);
            
            
            
            // string name = req.Query["name"];

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            return new OkObjectResult("Wonder what took so long?  Check the logs.");

        }
    }
}
