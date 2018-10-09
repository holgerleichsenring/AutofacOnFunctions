

using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    internal class TestIt : ITestIt
    {
        private readonly ILogger<TestIt> _logger;

        public TestIt(ILogger<TestIt> logger)
        {
            _logger = logger;
            _logger.LogInformation("ctor");
        }
        public string Name { get; set; }

        public string CallMe()
        {
            _logger.LogInformation("callme");
            return "Dependency Injection Test method had been called.";
        }
    }
}
