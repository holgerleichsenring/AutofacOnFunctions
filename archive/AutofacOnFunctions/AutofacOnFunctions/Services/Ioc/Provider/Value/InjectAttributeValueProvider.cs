using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace AutofacOnFunctions.Services.Ioc.Provider.Value
{
    internal class InjectAttributeValueProvider : IValueProvider
    {
        private readonly ParameterInfo _parameterInfo;
        private readonly IObjectResolver _objectResolver;

        public InjectAttributeValueProvider(ParameterInfo parameterInfo, IObjectResolver objectResolver)
        {
            _parameterInfo = parameterInfo;
            _objectResolver = objectResolver;
        }

        public Task<object> GetValueAsync()
        {
            var injectAttribute = _parameterInfo.GetCustomAttribute<InjectAttribute>();
            if (!injectAttribute.HasName)
            {
                return Task.FromResult(_objectResolver.Resolve(Type));
            }
            return Task.FromResult(_objectResolver.Resolve(Type, injectAttribute.Name));

        }

        public string ToInvokeString()
        {
            return Type.ToString();
        }

        public Type Type => _parameterInfo.ParameterType;
    }
}