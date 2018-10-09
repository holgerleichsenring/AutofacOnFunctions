using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;

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
            if (injectAttribute.HasName)
            {
                return Task.FromResult(_objectResolver.Resolve(Type, injectAttribute.Name));
            }

            if (Type != typeof(ILogger))
            {
                return Task.FromResult(_objectResolver.Resolve(Type));
            }

            //logging does not consider naming
            //logging for Azure Functions cannot contain any <T> as the function's class is static and cannot be used to 
            //define a concrete type for generic usage.
            var loggerResolver = _objectResolver.Resolve<LoggerResolver>();
            return Task.FromResult(loggerResolver.GetLogger(_objectResolver, _parameterInfo.Member.DeclaringType));

        }

        public string ToInvokeString()
        {
            return Type.ToString();
        }

        public Type Type => _parameterInfo.ParameterType;
    }
}