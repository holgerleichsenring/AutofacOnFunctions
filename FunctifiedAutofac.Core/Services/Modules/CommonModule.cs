using Autofac;
using FunctifiedAutofac.Core.Services.Ioc;

namespace FunctifiedAutofac.Core.Services.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectResolver>().As<IObjectResolver>().SingleInstance();
        }
    }
}