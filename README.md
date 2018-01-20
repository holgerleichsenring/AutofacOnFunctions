# functified-autofac
Azure Function Autofac Integration

For a comprehensive explanation have a look at [codingsoul](http://codingsoul.de/2018/01/19/azure-function-dependency-injection-with-autofac-functified-autofac/)

# Goal
Azure functions are by design static. Allow for dependency injection within Azure function with Autofac. The extensible nature of Azure Functions allow for attribute based dependency injection implementation. The attribute is called "Inject". Just add it as a parameter to your function combined with the type and name of the service parameter.
```C#
        [FunctionName("TestFunction1")]
        public static async Task<HttpResponseMessage> Run([Inject] IMyService MyService)
```

# How to
Simple create a class based on the [IBootstrapper interface](FunctifiedAutofac.Sample/Bootstrap/Bootstrapper.cs).
You need to package your references into modules, obviously. Different strategies are not implemented by now.

```C#
    public interface IBootstrapper
    {
        Module[] CreateModules();
    }
```

Just visit the sample to check how easy it is to provide your modularized services in [Bootstrapper Sample](FunctifiedAutofac.Sample/Bootstrap/Bootstrapper.cs).

```C#
    public class Bootstrapper : IBootstrapper
    {
        public Module[] CreateModules()
        {
            return new Module[]
            {
                new ServicesModule()
            };
        }
    }
```

The module(s) in question shall contain the services that are necessary for the functions in your project. A sample is provided in [ServicesModule](FunctifiedAutofac.Sample/Services/Modules/ServicesModule.cs) Sample.

```C#
 public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyService>();
        }
    }
```

The bootstrapper implementations will be read and autofac will be configured when the first function that uses the Inject attribute is called or triggered. 

Internally the implementation uses a ServiceLocator. When you need to inject services on the fly, avoid using a direct reference to that static class. IObjectResolver implementation can be injected that avoids this anti-pattern.





