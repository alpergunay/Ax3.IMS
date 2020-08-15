using System;
using System.Runtime.Serialization;

namespace Ax3.IMS.Infrastructure.Core.Exception
{
    [Serializable]
    public class NotFoundException : System.Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(long id)
            : base(id.ToString())
        {
        }

        public NotFoundException(Guid id)
            : base(id.ToString())
        {
        }

        public NotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected NotFoundException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}