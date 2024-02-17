using System.Runtime.Serialization;

namespace flexisource_exam.Exceptions
{
    [Serializable]
    internal class RainfallNotFoundException : Exception
    {
        public RainfallNotFoundException()
        {
        }

        public RainfallNotFoundException(string? message) : base(message)
        {
        }

        public RainfallNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RainfallNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}