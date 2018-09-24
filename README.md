# Autofac On Functions
Azure Function Autofac Integration, now version 1 available in nuget!

For a comprehensive explanation have a look at 

- [codingsoul: azure functions dependency injection with autofac](http://codingsoul.de/2018/01/19/azure-function-dependency-injection-with-autofac/)
- [codingsoul: azure functions dependency injection with autofac nuget package](http://codingsoul.de/2018/06/12/azure-functions-dependency-injection-autofac-on-functions-nuget-package/)
- [codingsoul: named services, fixes for breaking changes](http://codingsoul.de/2018/09/11/autofaconfunctions-named-services-support-fixes-for-breaking-changes/)
- [codingsoul: autofaconfunctions version 1 released](http://codingsoul.de/2018/09/24/autofaconfunctions-version-1-released/)

# Environment
Current library supports net framework and net standard since Microsoft.Net.Sdk.Functions version 1.0.21. For that version Azure Functions V2 is necessary. If you want to work with former version of the sdk, have a look onto the [archive](https://github.com/holgerleichsenring/AutofacOnFunctions/tree/master/archive/).

# Paradigm
It doesn't matter with version of dotnet is going to be used, dependency injection paradigm is done completely identical. The code probably need some different references for implementing the function itself due to microsoft.net.sdk.functions implementation in certain versions.

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

## Microsoft.net.sdk.function version 1.0.19
As version 1.0.19 of Azure Functions made changes to the procedure of initialization necessary, the former used ServiceLocator is not available anymore. Anyway you should not use a direct reference to an Autofac IContainer reference anyway. If you need to resolve services on the fly, just inject IObjectResolver to your class.

## Microsoft.net.sdk.function version 1.0.21
Version 1.0.19 references WebJobs  Azure Functions made changes to the procedure of initialization necessary, the former used ServiceLocator is not available anymore. Anyway you should not use a direct reference to an Autofac IContainer reference anyway. If you need to resolve services on the fly, just inject IObjectResolver to your class.


# Named Services
Autofac allows for named services. AutofacOnFunctions had been enhanced to support named services in most initutive way. Actually there are only two steps to do.

First register your services by name.
```C#
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIt>().As<ITestIt>();

            builder.RegisterType<TestItByName>().Named<ITestItByName>("registration1");
            builder.RegisterType<TestItByName>().Named<ITestItByName>("registration2");
        }
    }
```

Use the inject atttribute to specify the named instance:
```C#
public static class Function2
    {
        [FunctionName("Function2")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req, TraceWriter log,
            [Inject("registration1")] ITestItByName testitbyName1,
            [Inject("registration2")] ITestItByName testitbyName2)
        {
            log.Info("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Hello, this is Function2. Dependency injection sample returns \n'{testitbyName1.CallMe()}', \n'{testitbyName2.CallMe()}'");
        }
    }
```

Full sample is available 

- [net standard](https://github.com/holgerleichsenring/AutofacOnFunctions/tree/master/AutofacOnFunctions/AutofacOnFunctions.Samples.NetStandard)
- [net framework](https://github.com/holgerleichsenring/AutofacOnFunctions/tree/master/AutofacOnFunctions/AutofacOnFunctions.Samples.NetFramework)

