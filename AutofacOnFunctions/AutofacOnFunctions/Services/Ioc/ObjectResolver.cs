using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;

namespace AutofacOnFunctions.Services.Ioc
{
    public class ObjectResolver : IObjectResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public ObjectResolver(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        /// <inheritdoc cref="IObjectResolver"/>
        public T Resolve<T>(IEnumerable<Parameter> arguments)
        {
            return _lifetimeScope.Resolve<T>(arguments);
        }

        /// <inheritdoc cref="IObjectResolver"/>
        public T Resolve<T>()
        {
            return _lifetimeScope.Resolve<T>();
        }
        /// <inheritdoc cref="IObjectResolver"/>
        public object Resolve(Type service)
        {
            return _lifetimeScope.Resolve(service);
        }

        public object Resolve(Type service, string name)
        {
            return _lifetimeScope.ResolveNamed(name, service);
        }
    }
}