using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    [Serializable]
    public class DataBaseException : Exception
    {
        public DataBaseException(){}

        public DataBaseException(SerializationInfo info, StreamingContext context) :base ( info, context) {}

        public DataBaseException(string message): base(message){}

        public DataBaseException(string message, Exception inner): base(message, inner){}
    }
}
