using System;

namespace AcmeCorporation.Draw.Domain
{
    /// <summary>
    /// Domain exception is thrown when a business rule has been violated
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message){}
    }
}
