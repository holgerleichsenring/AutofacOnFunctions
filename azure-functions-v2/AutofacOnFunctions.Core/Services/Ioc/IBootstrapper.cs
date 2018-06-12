using Autofac;

namespace AutofacOnFunctions.Core.Services.Ioc
{
    public interface IBootstrapper
    {
        Module[] CreateModules();
    }
}