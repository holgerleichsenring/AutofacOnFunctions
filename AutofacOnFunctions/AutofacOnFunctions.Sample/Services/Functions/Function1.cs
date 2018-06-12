using AutofacOnFunctions.Services.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace AutofacOnFunctions.Sample.Services.Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req, TraceWriter log,
            [Inject] ITestIt testit)
        {
            log.Info("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Hello. Dependency injection sample returns '{testit.CallMe()}'");
        }
    }
}