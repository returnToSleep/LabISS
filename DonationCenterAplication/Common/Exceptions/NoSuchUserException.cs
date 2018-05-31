using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class NoSuchUserException : Exception
    {
        public NoSuchUserException() { }

        public NoSuchUserException(string message): base(message){ }

        public NoSuchUserException(SerializationInfo info, StreamingContext context) :base ( info, context) { }

        public NoSuchUserException(string message, Exception inner): base(message, inner){ }
    }
}
