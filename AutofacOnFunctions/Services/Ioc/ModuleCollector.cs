using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutofacOnFunctions.Exceptions;
using AutofacOnFunctions.Services.Modules;

namespace AutofacOnFunctions.Services.Ioc
{
    public class ModuleCollector
    {
        public List<Module> Collect()
        {
            var modules = new List<Module>
            {
                new CommonModule(),
                new LoggingModule()
            };
            modules.AddRange(GetModules());
            return modules;
        }

        private static List<Module> GetModules()
        {
            var bootstrapperCollector = new BootstrapperCollector();
            var bootstrappers = bootstrapperCollector.GetBootstrappers();

            if (bootstrappers.Count == 0)
            {
                throw new BootstrapperNotFoundException("No bootstrapper instances had been recognized.");
            }

            var modules = new List<Module>();
            foreach (var bootstrapper in bootstrappers)
            {
                var instance = (IBootstrapper) Activator.CreateInstance(bootstrapper);
                modules.AddRange(instance.CreateModules());
            }

            return modules;
        }
    }
}