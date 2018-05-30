namespace LETin.BillingoAPI
{
    [System.Serializable]
    public class BillingoAPIException : System.Exception
    {
        public BillingoAPIException() { }
        public BillingoAPIException(string message) : base(message) { }
        public BillingoAPIException(string message, System.Exception inner) : base(message, inner) { }
        protected BillingoAPIException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}