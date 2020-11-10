using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Pumox_Test.Exceptions
{
    public class CopmanyUpdateException : Exception
    {
        public CopmanyUpdateException()
        {
        }

        public CopmanyUpdateException(string message) : base(message)
        {
        }

        public CopmanyUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CopmanyUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
