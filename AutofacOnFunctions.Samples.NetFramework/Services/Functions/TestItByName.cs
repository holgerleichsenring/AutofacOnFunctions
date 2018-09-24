
namespace AutofacOnFunctions.Samples.NetFramework.Services.Functions
{
    public class TestItByName : ITestItByName
    {
        public string CallMe()
        {
            return "Dependency Injection Test method had been called. Resolution had been done by name.";
        }
    }
}
