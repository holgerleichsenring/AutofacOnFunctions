
namespace AutofacOnFunctions.Samples.NetStandard.Services.Functions
{
    internal class TestItByName : ITestItByName
    {
        public string CallMe()
        {
            return "Dependency Injection Test method had been called. Resolution had been done by name.";
        }
    }
}
