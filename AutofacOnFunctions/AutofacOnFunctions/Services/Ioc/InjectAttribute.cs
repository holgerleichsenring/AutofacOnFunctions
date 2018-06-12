using System;
using Microsoft.Azure.WebJobs.Description;

namespace AutofacOnFunctions.Services.Ioc
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class InjectAttribute : Attribute
    {
    }
}
