using System;
using System.Runtime.Serialization;

namespace Magazyn
{
    [Serializable]
    internal class TowarNotFoundException : Exception
    {
        public TowarNotFoundException()
        {
        }

        public TowarNotFoundException(string message) : base(message)
        {
        }

        public TowarNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TowarNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}