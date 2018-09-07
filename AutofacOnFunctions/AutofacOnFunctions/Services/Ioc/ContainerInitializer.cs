using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutofacOnFunctions.Exceptions;
using AutofacOnFunctions.Services.Modules;

namespace AutofacOnFunctions.Services.Ioc
{
    public class ContainerInitializer
    {
        private IContainer _container;

        public IContainer GetOrCreateContainer()
        {
            if (_container == null)
            {
                InitializeContainer();
            }

            return _container;
        }

        private void InitializeContainer()
        {
            var modules = GetModules();
            var containerBuilder = EnsureCommonModule(modules);
            RegisterModules(modules, containerBuilder);
            _container = containerBuilder.Build();
        }

        private static void RegisterModules(List<Module> modules, ContainerBuilder containerBuilder)
        {
            foreach (var module in modules)
            {
                containerBuilder.RegisterModule(module);
            }
        }

        private static ContainerBuilder EnsureCommonModule(List<Module> modules)
        {
            var containerBuilder = new ContainerBuilder();
            if (modules.All(module => module.GetType().FullName != typeof(CommonModule).FullName))
            {
                modules.Add(new CommonModule());
            }

            return containerBuilder;
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