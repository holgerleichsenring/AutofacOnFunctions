using Autofac;
using FunctifiedAutofac.Sample.Services.Functions;

namespace FunctifiedAutofac.Sample.Services.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIt>();
        }
    }
}