using System;
using Autofac;

namespace Functified.Core.Services.Ioc
{
    public class ServiceLocator
    {
        private static IContainer _container;

        public static IContainer Instance
        {
            get
            {
                if (_container == null)
                {
                    throw new Exception("ServiceLocator has to be initialized before usage.");
                }
                return _container;
            }
        }
        
        public static void Dispose()
        {
            _container.Dispose();
        }

        public static void Initialize(Module[] modules)
        {
            var containerBuilder = GetContainerBuilder(modules);
            _container = containerBuilder.Build();
        }

        public static IContainer Initialize(ContainerBuilder containerBuilder)
        {
            _container = containerBuilder.Build();
            return _container;
        }

        public static ContainerBuilder GetContainerBuilder(Module[] modules)
        {
            var containerBuilder = new ContainerBuilder();
            foreach (var module in modules)
            {
                containerBuilder.RegisterModule(module);
            }
            return containerBuilder;
        }

        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }
    }
}