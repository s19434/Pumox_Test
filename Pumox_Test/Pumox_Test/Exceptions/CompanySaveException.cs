using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Pumox_Test.Exceptions
{
    public class CompanySaveException : Exception
    {
        public CompanySaveException()
        {
        }

        public CompanySaveException(string message) : base(message)
        {
        }

        public CompanySaveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CompanySaveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
