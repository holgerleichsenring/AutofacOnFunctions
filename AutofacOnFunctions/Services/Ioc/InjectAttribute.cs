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

        public string BootstrappingAssembly { get; set; }
        public bool HasBootstrappingAssembly => !string.IsNullOrWhiteSpace(BootstrappingAssembly);

        public InjectAttribute() { }

        public InjectAttribute(string name, string bootstrappingAssembly = "")
        {
            Name = name;
            BootstrappingAssembly = bootstrappingAssembly;
        }

        public InjectAttribute(string bootstrappingAssembly, bool useBoostrappingAssembly)
        {
            BootstrappingAssembly = bootstrappingAssembly;
        }

        
    }
}
