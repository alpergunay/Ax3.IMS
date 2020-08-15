namespace Ax3.IMS.Infrastructure.Core.Exception
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}