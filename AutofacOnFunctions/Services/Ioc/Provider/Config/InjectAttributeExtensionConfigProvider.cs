using AutofacOnFunctions.Services.Ioc.Provider.Binding;
using Microsoft.Azure.WebJobs.Host.Config;

namespace AutofacOnFunctions.Services.Ioc.Provider.Config
{
    public class InjectAttributeExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly InjectAttributeBindingProvider _bindingProvider;

        public InjectAttributeExtensionConfigProvider()
        {
            _bindingProvider = new InjectAttributeBindingProvider();
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<InjectAttribute>().Bind(_bindingProvider);
        }
    }
}