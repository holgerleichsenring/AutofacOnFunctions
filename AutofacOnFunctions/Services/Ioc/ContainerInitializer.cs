using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Services.Ioc
{
    public class ContainerInitializer
    {
        private readonly ILoggerFactory _loggerFactory;
        private IContainer _container;
        private string _bootstrappingAssembly = null;

        public void SetBoostrappingAssembly(string bootstrappingAssembly)
        {
            _bootstrappingAssembly = bootstrappingAssembly;
        }

        public ContainerInitializer(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

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
            var moduleCollector = new ModuleCollector(_bootstrappingAssembly);
            var containerBuilder = new ContainerBuilder();
            var modules = moduleCollector.Collect();
            RegisterModules(modules, containerBuilder);
            RegisterLoggingFactory(_loggerFactory, containerBuilder);
            _container = containerBuilder.Build();
        }

        private void RegisterLoggingFactory(ILoggerFactory loggerFactory, ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstance(loggerFactory);
        }

        private static void RegisterModules(List<Module> modules, ContainerBuilder containerBuilder)
        {
            foreach (var module in modules)
            {
                containerBuilder.RegisterModule(module);
            }
        }
    }
}