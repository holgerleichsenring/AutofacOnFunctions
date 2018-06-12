using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace AutofacOnFunctions.Services.Ioc
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
            return Task.FromResult(_objectResolver.Resolve(Type));
        }

        public string ToInvokeString()
        {
            return Type.ToString();
        }

        public Type Type => _parameterInfo.ParameterType;
    }
}