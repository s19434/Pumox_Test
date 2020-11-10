using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Pumox_Test.Exceptions
{
    public class CompanyDeleteException : Exception
    {
        public CompanyDeleteException()
        {
        }

        public CompanyDeleteException(string message) : base(message)
        {
        }

        public CompanyDeleteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CompanyDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
