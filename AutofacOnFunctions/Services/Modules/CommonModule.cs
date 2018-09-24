using Autofac;
using AutofacOnFunctions.Services.Ioc;

namespace AutofacOnFunctions.Services.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectResolver>().As<IObjectResolver>().SingleInstance();
        }
    }
}