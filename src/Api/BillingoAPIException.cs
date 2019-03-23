using System.Collections.Generic;
using System.Linq;

namespace LETin.Billingo.Api
{
    [System.Serializable]
    public class BillingoAPIException : System.Exception
    {
        public BillingoAPIException() { }
        public BillingoAPIException(string message) : base(message) { }
        public BillingoAPIException(IList<string> message) : base(message?.FirstOrDefault()) { }
        public BillingoAPIException(string message, System.Exception inner) : base(message, inner) { }
        protected BillingoAPIException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}