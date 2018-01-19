using Autofac;
using FunctifiedAutofac.Core.Services.Ioc;
using FunctifiedAutofac.Sample.Services.Modules;

namespace FunctifiedAutofac.Sample.Bootstrap
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