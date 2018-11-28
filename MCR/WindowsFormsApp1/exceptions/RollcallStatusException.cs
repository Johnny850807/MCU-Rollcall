using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MCR.exceptions
{
    [Serializable()]
    public class RollcallStateException : Exception
    {
        protected RollcallStateException()
           : base()
        { }


        public RollcallStateException(string message) :
           base(message)
        {
        }

        public RollcallStateException(string message, Exception innerException) :
           base(message, innerException)
        {
        }

        protected RollcallStateException(SerializationInfo info,
                                    StreamingContext context)
           : base(info, context)
        { }
    }
}
