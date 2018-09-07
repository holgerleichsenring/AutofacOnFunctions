# Autofac On Functions
Azure Function Autofac Integration

For a comprehensive explanation have a look at [codingsoul: azure functions dependency injection with autofac](http://codingsoul.de/2018/01/19/azure-function-dependency-injection-with-autofac/)

There are two samples available:
- Azure Functions V1 with .net framework.
- Azure Functions V2 with dot net standard.

The procedure is identical in both scenarios.

# Goal
Azure functions are by design static. Allow for dependency injection within Azure function with Autofac. The extensible nature of Azure Functions allow for attribute based dependency injection implementation. The attribute is called "Inject". Just add it as a parameter to your function combined with the type and name of the service parameter.
```C#
        [FunctionName("TestFunction1")]
        public static async Task<HttpResponseMessage> Run([Inject] IMyService MyService)
```

# How to
Simple create a class based on the [IBootstrapper interface](AutofacOnFunctions.Sample/Bootstrap/Bootstrapper.cs).
You need to package your references into modules, obviously. Different strategies are not implemented by now.

```C#
    public interface IBootstrapper
    {
        Module[] CreateModules();
    }
```

Just visit the sample to check how easy it is to provide your modularized services in [Bootstrapper Sample](AutofacOnFunctions.Sample/Bootstrap/Bootstrapper.cs).

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

The module(s) in question shall contain the services that are necessary for the functions in your project. A sample is provided in [ServicesModule](AutofacOnFunctions.Sample/Services/Modules/ServicesModule.cs) Sample.

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

# Breaking Changes

As version 1.0.19 of Azure Functions made changes to the procedure of initialization necessary, the former used ServiceLocator is not available anymore. Anyway you should not use a direct reference to an Autofac IContainer reference anyway. If you need to resolve services on the fly, just inject IObjectResolver to your class.





