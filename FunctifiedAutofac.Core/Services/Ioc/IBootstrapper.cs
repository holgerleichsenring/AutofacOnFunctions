using Autofac;

namespace FunctifiedAutofac.Core.Services.Ioc
{
    public interface IBootstrapper
    {
        Module[] CreateModules();
    }
}