using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutofacOnFunctions.Services.Ioc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace AutofacOnFunctions.Samples.NetFramework.Services.Functions
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequestMessage req, TraceWriter log,
            [Inject("registration1")] ITestItByName testitbyName1,
            [Inject("registration2")] ITestItByName testitbyName2)
        {
            log.Info("C# HTTP trigger function processed a request.");
            return req.CreateResponse(HttpStatusCode.OK,
                $"Hello, this is Function2. Dependency injection sample returns \n'{testitbyName1.CallMe()}', \n'{testitbyName2.CallMe()}'");
        }
    }
}