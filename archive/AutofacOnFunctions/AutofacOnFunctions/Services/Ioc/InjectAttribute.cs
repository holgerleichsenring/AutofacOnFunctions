using System;
using Microsoft.Azure.WebJobs.Description;

namespace AutofacOnFunctions.Services.Ioc
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class InjectAttribute : System.Attribute
    {
        public string Name { get; set; }
        public bool HasName => !string.IsNullOrWhiteSpace(Name);

        public InjectAttribute()
        {

        }
        public InjectAttribute(string name)
        {
            Name = name;
        }
    }
}
