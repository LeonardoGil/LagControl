using System;
using System.Runtime.Serialization;

namespace LagBaseDomain
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message) { } 
        public DomainException(string message, Exception? innerException) : base(message, innerException) { }
        
        public static DomainException Create(string message, Exception? innerException = null) => new(message, innerException);
    }
}
