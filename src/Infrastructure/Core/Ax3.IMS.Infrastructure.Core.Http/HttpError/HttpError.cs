namespace Ax3.IMS.Infrastructure.Core.Http.HttpError
{
    public sealed class HttpError
    {
        public HttpErrorType Type { get; set; }

        public string[] Messages { get; set; }

        public object DeveloperMessage { get; set; }
    }
}