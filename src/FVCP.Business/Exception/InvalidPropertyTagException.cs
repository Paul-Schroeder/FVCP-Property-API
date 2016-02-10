using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Business.Command
{
    [Serializable]
    public class InvalidPropertyTagException : Exception
    {
        public InvalidPropertyTagException() { }
        public InvalidPropertyTagException(string message) : base(message) { }
        public InvalidPropertyTagException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPropertyTagException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
