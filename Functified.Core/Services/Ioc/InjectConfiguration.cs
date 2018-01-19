using System.Linq;
using Autofac;
using Functified.Core.Services.Modules;

namespace Functified.Core.Services.Ioc
{
    public static class InjectConfiguration
    {
        public static void Initialize(Module[] modules)
        {
            var modulesList = modules.ToList();

            if (modules.All(module => module.GetType().FullName != typeof(CommonModule).FullName))
            {
                modulesList.Add(new CommonModule());
            }
            ServiceLocator.Initialize(modulesList.ToArray());
        }
    }
}
