using AutofacOnFunctions.Services.Ioc.Provider.Binding;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Services.Ioc.Provider.Config
{
    public class InjectAttributeExtensionConfigProvider : IExtensionConfigProvider
    {
        private InjectAttributeBindingProvider _bindingProvider;
        private readonly ILoggerFactory _loggerFactory;

        public InjectAttributeExtensionConfigProvider(ILoggerFactory loggerFactory)
        {
            //constructor takes over loggerfactory instance 
            //that is directly injected only by webjobs 3.x
            _loggerFactory = loggerFactory;
        }

        public InjectAttributeExtensionConfigProvider()
        {
            //constructor is necessary due to implemenatation of webjobs for .net framework
            //which is not going to inject loggerfactory
        }

        public void Initialize(ExtensionConfigContext context)
        {
            ILoggerFactory loggerFactory = null;
            //get the instance of the loggerfactory dependent on the framework version
#if NETSTANDARD
            loggerFactory = _loggerFactory;
#else
            loggerFactory = context.Config.LoggerFactory;
#endif
            _bindingProvider = new InjectAttributeBindingProvider(loggerFactory);
            context.AddBindingRule<InjectAttribute>().Bind(_bindingProvider);
        }
    }
}