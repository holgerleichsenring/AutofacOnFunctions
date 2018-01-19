using Autofac;

namespace Functified.Core.Services.Ioc
{
    public interface IBootstrapper
    {
        Module[] CreateModules();
    }
}