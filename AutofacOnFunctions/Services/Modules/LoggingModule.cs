using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using AutofacOnFunctions.Services.Ioc;
using Microsoft.Extensions.Logging;
using Module = Autofac.Module;

namespace AutofacOnFunctions.Services.Modules
{
    public class LoggingModule : Module
    {
        private static readonly ConcurrentDictionary<Type, object> _logCache = new ConcurrentDictionary<Type, object>();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoggerResolver>().SingleInstance();
        }

        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            // Handle constructor parameters.
            registration.Preparing += OnComponentPreparing;
        }

        private static object GetLogger(IComponentContext context, Type declaringType, Type loggerType)
        {
            var loggerResolver = context.Resolve<LoggerResolver>();
            return loggerResolver.GetLogger(context, declaringType, loggerType);
        }

        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            var limitType = e.Component.Activator.LimitType;
            var loggerType = typeof(ILogger);
            var loggerGenericType = typeof(ILogger<>);
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        delegate(ParameterInfo info, IComponentContext context)
                    {
                        return info.ParameterType == loggerType ||
                               info.ParameterType.IsGenericType && info.ParameterType.GetGenericTypeDefinition() == loggerGenericType;
                    }, delegate(ParameterInfo info, IComponentContext context)
                    {
                        if (info.ParameterType == loggerType)
                        {
                            return GetLogger(context, limitType, info.ParameterType);
                        }
                        return GetLogger(context, limitType, info.ParameterType);
                    } )
                    //new ResolvedParameter((parameterInfo, context) =>
                    //parameterInfo.ParameterType == loggerType ||
                    //parameterInfo.ParameterType.IsGenericParameter && parameterInfo.ParameterType.GetGenericTypeDefinition() == loggerGenericType,
                    //(parameterInfo, context) => GetLogger(context, limitType, parameterInfo.ParameterType))
                });
        }
    }
}