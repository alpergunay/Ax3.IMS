namespace Ax3.IMS.Infrastructure.Core.Exception
{
    public class ApiValidationException : BadRequestException
    {
        public ApiValidationException(string message) : base(message)
        {
        }
    }
}