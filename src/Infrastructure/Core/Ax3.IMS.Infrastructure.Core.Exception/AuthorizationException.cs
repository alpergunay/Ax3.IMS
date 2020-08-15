namespace Ax3.IMS.Infrastructure.Core.Exception
{
    public sealed class AuthorizationException : System.Exception
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string msg)
            : base(msg)
        {
        }
    }
}