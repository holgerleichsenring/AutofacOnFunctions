
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetFramework.Services.Functions
{
    internal class TestItByName : ITestItByName
    {
        private readonly ILogger _logger;

        public TestItByName(ILogger logger)
        {
            _logger = logger;
            _logger.LogInformation("ctor");
        }

        public string CallMe()
        {
            _logger.LogInformation("callme");
            return "Dependency Injection Test method had been called. Resolution had been done by name.";
        }
    }
}
