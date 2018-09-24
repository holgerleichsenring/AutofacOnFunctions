using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using AutofacOnFunctions.Services.Ioc;
using AutofacOnFunctions.Services.Ioc.Provider.Binding;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace AutofacOnFunctions.Services.Ioc.Provider.Binding
{
    public class InjectAttributeBindingProvider : IBindingProvider
    {
        private readonly ContainerInitializer _containerInitializer;

        public InjectAttributeBindingProvider()
        {
            _containerInitializer = new ContainerInitializer();
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var parameterInfo = context.Parameter;
            var injectAttribute = parameterInfo.GetCustomAttribute<InjectAttribute>();
            if (injectAttribute == null)
            {
                return Task.FromResult<IBinding>(null);
            }

            var container = _containerInitializer.GetOrCreateContainer();
            var objectResolver = container.Resolve<IObjectResolver>();
            return Task.FromResult<IBinding>(new InjectAttributeBinding(parameterInfo, objectResolver));
        }
    }
}