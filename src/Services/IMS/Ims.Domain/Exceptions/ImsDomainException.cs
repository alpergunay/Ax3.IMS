using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Infrastructure.Core.Exception;

namespace Ims.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class ImsDomainException : DomainException
    {
        public ImsDomainException()
        { }

        public ImsDomainException(string message)
            : base(message)
        { }

        public ImsDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
