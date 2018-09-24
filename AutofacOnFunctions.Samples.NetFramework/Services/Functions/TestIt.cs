
namespace AutofacOnFunctions.Samples.NetFramework.Services.Functions
{
    public class TestIt : ITestIt
    {
        public string Name { get; set; }

        public string CallMe()
        {
            return "Dependency Injection Test method had been called.";
        }
    }
}
