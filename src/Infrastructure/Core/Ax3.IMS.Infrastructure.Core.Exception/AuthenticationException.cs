namespace Ax3.IMS.Infrastructure.Core.Exception
{
    public sealed class AuthenticationException : System.Exception
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string msg)
            : base(msg)
        {
        }
    }
}