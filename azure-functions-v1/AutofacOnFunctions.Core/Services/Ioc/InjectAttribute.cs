using System;
using Microsoft.Azure.WebJobs.Description;

namespace AutofacOnFunctions.Core.Services.Ioc
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class InjectAttribute : Attribute
    {
    }
}
