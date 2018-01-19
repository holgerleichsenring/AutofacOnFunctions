using Autofac;
using Functified.Sample.Services.Functions;

namespace Functified.Sample.Services.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIt>();
        }
    }
}