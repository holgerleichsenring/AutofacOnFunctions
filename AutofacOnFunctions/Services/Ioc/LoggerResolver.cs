using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Logging;

namespace AutofacOnFunctions.Services.Ioc
{
    public class LoggerResolver
    {
        private static readonly ConcurrentDictionary<Type, object> _logCache = new ConcurrentDictionary<Type, object>();

        public object GetLogger(IComponentContext context, Type declaringType)
        {
            // method is used to resolve logger instances for any classes that are not static azure function implementations
            return GetLogger(declaringType, delegate
            {
                var factory = context.Resolve<ILoggerFactory>();
                var loggerName = GetLoggerName(declaringType);
                return factory.CreateLogger(loggerName);
            });
        }

        internal object GetLogger(IComponentContext context, Type declaringType, Type loggerType)
        {
            if (loggerType.IsGenericType)
            {
                return GetLogger(declaringType, delegate
                {
                    var factory = context.Resolve<ILoggerFactory>();
                    //TODO: make this more stable
                    // this is a hack, calling the extension method CreateLogger<> with the parameter
                    // via reflection. The type is known only while runtime, so no other possible solution
                    // to create this logger instance
                    var t = loggerType.GenericTypeArguments[0];
                    var methodInfo = GetMethodInfo(typeof(LoggerFactoryExtensions), "CreateLogger");
                    var genericMethod = methodInfo.MakeGenericMethod(t);

                    return genericMethod.Invoke(null, new object[] {factory});
                });
            }

            return GetLogger(context, declaringType);
        }

        public object GetLogger(IObjectResolver objectResolver, Type declaringType)
        {
            // method is used to resolve logger instances azure function implementations with [inject] attribute
            return GetLogger(declaringType, delegate
            {
                var factory = objectResolver.Resolve<ILoggerFactory>();
                var loggerName = GetLoggerName(declaringType);
                return factory.CreateLogger(loggerName);
            });
        }


        private static object GetLogger(Type declaringType, Func<object> action)
        {
            return _logCache.GetOrAdd(
                declaringType,
                x => action());
        }

        private static string GetLoggerName(Type declaringType)
        {
            // why this is necessary: https://www.neovolve.com/2018/04/05/dependency-injection-and-ilogger-in-azure-functions/
            return "Function." + declaringType.FullName + ".User";
        }

        private static MethodInfo GetMethodInfo(Type staticType, string methodName,
            params Type[] paramTypes)
        {
            var methods = from method in staticType.GetMethods()
                where method.Name == methodName && method.IsGenericMethod
                select method;

            try
            {
                return methods.SingleOrDefault();
            }
            catch (InvalidOperationException)
            {
                throw new AmbiguousMatchException();
            }
        }
    }
}