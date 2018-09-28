using System;
using System.Runtime.Serialization;

namespace CustomerInviter.Entities
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) {
        }

        public CustomException() : base() {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}