using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace AutofacOnFunctions.Services.Ioc
{
    public class InjectAttributeBindingProvider : IBindingProvider
    {
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

            var objectResolver = ServiceLocator.Resolve<IObjectResolver>();
            return Task.FromResult<IBinding>(new InjectAttributeBinding(parameterInfo, objectResolver));
        }
    }
}