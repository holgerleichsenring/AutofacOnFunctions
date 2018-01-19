using System;
using Microsoft.Azure.WebJobs.Description;

namespace FunctifiedAutofac.Core.Services.Ioc
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class InjectAttribute : Attribute
    {
    }
}
