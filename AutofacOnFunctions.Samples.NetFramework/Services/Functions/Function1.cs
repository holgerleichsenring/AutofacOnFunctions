using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutofacOnFunctions.Services.Ioc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;

namespace AutofacOnFunctions.Samples.NetFramework.Services.Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, 
            [Inject] ITestIt testit,
            [Inject] ILogger logger)
        {
            
            logger.LogInformation("C# HTTP trigger function processed a request");
            return req.CreateResponse(HttpStatusCode.OK, $"Hello. Dependency injection sample returns '{testit.CallMe()}'");
            
        }
    }
}

