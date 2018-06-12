using Autofac;
using AutofacOnFunctions.Core.Services.Ioc;
using AutofacOnFunctions.Sample.Services.Modules;

namespace AutofacOnFunctions.Sample.Bootstrap
{
    public class Bootstrapper : IBootstrapper
    {
        public Module[] CreateModules()
        {
            return new Module[]
            {
                new ServicesModule()
            };
        }
    }
}