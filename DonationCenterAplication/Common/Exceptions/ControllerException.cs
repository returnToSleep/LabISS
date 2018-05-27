using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ControllerException : Exception
    {
        
        public ControllerException() { }

        public ControllerException(string message): base(message){ }

        public ControllerException(string message, Exception inner): base(message, inner){ }
    }
}

