using System;
using System.Collections.Generic;
using Autofac;
using AutofacOnFunctions.Core.Exceptions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;

namespace AutofacOnFunctions.Core.Services.Ioc
{
    public class InjectAttributeExtensionConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            InitializeServiceLocator(context);

            context.Config.RegisterBindingExtensions(new InjectAttributeBindingProvider());
        }

        private static void InitializeServiceLocator(ExtensionConfigContext context)
        {
            var bootstrapperCollector = new BootstrapperCollector();
            var bootstrappers = bootstrapperCollector.GetBootstrappers();

            if (bootstrappers.Count == 0)
            {
                throw new BootstrapperNotFoundException("No bootstrapper instances had been recognized.");
            }

            var modules = new List<Module>();
            foreach (var bootstrapper in bootstrappers)
            {
                var instance = (IBootstrapper) Activator.CreateInstance(bootstrapper);
                modules.AddRange(instance.CreateModules());
            }
            InjectConfiguration.Initialize(modules.ToArray());
        }
    }
}