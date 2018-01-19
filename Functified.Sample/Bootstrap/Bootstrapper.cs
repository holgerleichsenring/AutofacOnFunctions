using Autofac;
using Functified.Core.Services.Ioc;
using Functified.Sample.Services.Modules;

namespace Functified.Sample.Bootstrap
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