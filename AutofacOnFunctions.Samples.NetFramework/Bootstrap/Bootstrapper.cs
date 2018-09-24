using Autofac;
using AutofacOnFunctions.Services.Ioc;
using AutofacOnFunctions.Samples.Services.Modules;

namespace AutofacOnFunctions.Samples.Bootstrap
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