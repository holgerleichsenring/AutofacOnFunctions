using Autofac;
using Functified.Core.Services.Ioc;

namespace Functified.Core.Services.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectResolver>().As<IObjectResolver>().SingleInstance();
        }
    }
}