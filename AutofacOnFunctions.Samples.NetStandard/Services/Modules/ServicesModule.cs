using Autofac;
using AutofacOnFunctions.Samples.NetStandard.Services.Functions;

namespace AutofacOnFunctions.Samples.NetStandard.Services.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIt>().As<ITestIt>();

            builder.RegisterType<TestItByName>().Named<ITestItByName>("registration1");
            builder.RegisterType<TestItByName>().Named<ITestItByName>("registration2");
        }
    }
}