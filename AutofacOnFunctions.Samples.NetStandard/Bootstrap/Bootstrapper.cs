using Autofac;
using AutofacOnFunctions.Samples.NetStandard.Services.Modules;
using AutofacOnFunctions.Services.Ioc;

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