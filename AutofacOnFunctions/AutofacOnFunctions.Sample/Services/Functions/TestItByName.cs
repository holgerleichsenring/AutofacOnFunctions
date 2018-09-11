
namespace AutofacOnFunctions.Sample.Services.Functions
{
    public class TestItByName : ITestItByName
    {
        public string CallMe()
        {
            return "Dependency Injection Test method had been called. Resolution had been done by name.";
        }
    }
}
