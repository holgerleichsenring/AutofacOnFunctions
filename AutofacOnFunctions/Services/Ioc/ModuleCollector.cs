using System;
using System.Collections.Generic;
using Autofac;
using AutofacOnFunctions.Exceptions;
using AutofacOnFunctions.Services.Modules;

namespace AutofacOnFunctions.Services.Ioc
{
    public class ModuleCollector
    {
        private readonly string _bootstrappingAssembly;

        public ModuleCollector(string bootstrappingAssembly)
        {
            _bootstrappingAssembly = bootstrappingAssembly;
        }

        public List<Module> Collect()
        {   
            var modules = new List<Module>
            {
                new CommonModule(),
                new LoggingModule()
            };
            modules.AddRange(GetModules(_bootstrappingAssembly));
            return modules;
        }

        private static List<Module> GetModules(string bootstrappingAssembly)
        {
            var isBootstrappingAssemblyPresent = !string.IsNullOrWhiteSpace(bootstrappingAssembly);
            var bootstrapperCollector = new BootstrapperCollector();
            var bootstrappers = isBootstrappingAssemblyPresent ? bootstrapperCollector.GetBootstrappers(bootstrappingAssembly) : bootstrapperCollector.GetBootstrappers();

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