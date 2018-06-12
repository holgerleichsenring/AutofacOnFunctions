using System;
using System.Runtime.Serialization;

namespace AutofacOnFunctions.Core.Exceptions
{
    public class BootstrapperNotFoundException : ApplicationException
    {
        public BootstrapperNotFoundException()
        {
        }

        public BootstrapperNotFoundException(string message) : base(message)
        {
        }

        public BootstrapperNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BootstrapperNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}