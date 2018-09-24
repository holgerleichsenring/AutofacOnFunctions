#if NETSTANDARD
using AutofacOnFunctions.Services.Ioc;
using AutofacOnFunctions.Services.Ioc.Provider.Config;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(WebJobsExtensionStartup), "AutofacOnFunctions extension startup.")]

namespace AutofacOnFunctions.Services.Ioc
{
    public class WebJobsExtensionStartup : IWebJobsStartup
    {
        public virtual void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<InjectAttributeExtensionConfigProvider>();
        }
    }
}
#endif
