namespace Ax3.IMS.Infrastructure.Core.Exception
{
    public class InternalServerErrorException : System.Exception
    {
        public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string msg)
            : base(msg)
        {
        }
    }
}