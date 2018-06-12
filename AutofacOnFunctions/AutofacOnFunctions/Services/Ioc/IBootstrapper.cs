using Autofac;

namespace AutofacOnFunctions.Services.Ioc
{
    public interface IBootstrapper
    {
        Module[] CreateModules();
    }
}