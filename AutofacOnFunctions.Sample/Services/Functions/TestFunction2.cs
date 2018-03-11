using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutofacOnFunctions.Core.Services.Ioc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace AutofacOnFunctions.Sample.Services.Functions
{
    public static class TestFunction2
    {
        [FunctionName("TestFunction2")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, 
            TraceWriter log,
            [Inject]  ITestIt testit)
        {
            log.Info("C# HTTP trigger function processed a request.");

            return req.CreateResponse(HttpStatusCode.OK,$"Hello. Dependency injection sample returns '{testit.CallMe()}'");
        }
    }
}
