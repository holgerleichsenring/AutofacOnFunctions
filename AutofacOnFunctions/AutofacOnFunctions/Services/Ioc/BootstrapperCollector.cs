using System;
using System.Collections.Generic;
using System.Linq;

namespace AutofacOnFunctions.Services.Ioc
{
    internal class BootstrapperCollector
    {
        public List<Type> GetBootstrappers()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IBootstrapper).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
        }
    }
}