using System;
using System.Collections.Generic;
using System.Linq;

namespace AutofacOnFunctions.Services.Ioc
{
    internal class BootstrapperCollector
    {
        public List<Type> GetBootstrappers()
        {
            // loading assemblies fails with exception, that System.Runtime.Loader or dependencies cannot be loaded
            // only with .net framework sample.
            // this is quick hack.
            // System and Microsoft assemblies will never contain any relevant class, so it is sensible to skip them anyway.
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => !x.GetName().Name.StartsWith("System.") && !x.GetName().Name.StartsWith("Microsoft."))
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IBootstrapper).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
        }
    }
}