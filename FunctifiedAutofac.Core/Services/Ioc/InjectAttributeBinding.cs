using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace FunctifiedAutofac.Core.Services.Ioc
{
    public class InjectAttributeBinding : IBinding
    {
        private readonly ParameterInfo _parameterInfo;
        private readonly IObjectResolver _objectResolver;

        public InjectAttributeBinding(ParameterInfo parameterInfo, IObjectResolver objectResolver)
        {
            _parameterInfo = parameterInfo;
            _objectResolver = objectResolver;
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            return Task.FromResult<IValueProvider>(new InjectAttributeValueProvider(_parameterInfo, _objectResolver));
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            return Task.FromResult<IValueProvider>(new InjectAttributeValueProvider(_parameterInfo, _objectResolver));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameterInfo.Name,
                DisplayHints = new ParameterDisplayHints
                {
                    Description = "Inject services",
                    DefaultValue = "Inject services",
                    Prompt = "Inject services"
                }
            };
        }

        public bool FromAttribute => true;
    }
}