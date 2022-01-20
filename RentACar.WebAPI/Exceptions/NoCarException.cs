namespace RentACar.WebAPI.Exceptions
{
    [Serializable]
    public class NoCarException : Exception
    {
        public NoCarException() { }
        public NoCarException(string message) : base(message) { }
        public NoCarException(string message, Exception inner) : base(message, inner) { }
        protected NoCarException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
