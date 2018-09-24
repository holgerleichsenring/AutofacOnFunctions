
namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    internal class TestIt : ITestIt
    {
        public string Name { get; set; }

        public string CallMe()
        {
            return "Dependency Injection Test method had been called.";
        }
    }
}
