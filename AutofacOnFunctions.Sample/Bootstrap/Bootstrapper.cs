using Autofac;
using AutofacOnFunctions.Sample.Services.Modules;
using AutofacOnFunctions.Core.Services.Ioc;

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