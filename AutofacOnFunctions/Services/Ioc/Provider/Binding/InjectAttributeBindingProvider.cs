using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Services.Ioc.Provider.Binding
{
    public class InjectAttributeBindingProvider : IBindingProvider
    {
        private readonly ContainerInitializer _containerInitializer;

        public InjectAttributeBindingProvider(ILoggerFactory loggerFactory)
        {
            _containerInitializer = new ContainerInitializer(loggerFactory);
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

            if (injectAttribute.HasBootstrappingAssembly)
                _containerInitializer.SetBoostrappingAssembly(injectAttribute.BootstrappingAssembly);
            var container = _containerInitializer.GetOrCreateContainer();
            var objectResolver = container.Resolve<IObjectResolver>();
            return Task.FromResult<IBinding>(new InjectAttributeBinding(parameterInfo, objectResolver));
        }
    }
}