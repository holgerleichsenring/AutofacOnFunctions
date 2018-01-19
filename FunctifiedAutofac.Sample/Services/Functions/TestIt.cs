using System;

namespace FunctifiedAutofac.Sample.Services.Functions
{
    public class TestIt : ITestIt
    {
        public string Name { get; set; }

        public string CallMe()
        {
            return "Dependency Injection Test method had been called.";
        }
    }

    public interface ITestIt
    {
        string Name { get; set; }
        string CallMe();
    }
}