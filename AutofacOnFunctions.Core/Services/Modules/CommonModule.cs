using Autofac;
using AutofacOnFunctions.Core.Services.Ioc;

namespace AutofacOnFunctions.Core.Services.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectResolver>().As<IObjectResolver>().SingleInstance();
        }
    }
}