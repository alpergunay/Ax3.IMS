namespace Ax3.IMS.Infrastructure.Core.Exception
{
    public sealed class ConflictException : System.Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string msg)
            : base(msg)
        {
        }
    }
}