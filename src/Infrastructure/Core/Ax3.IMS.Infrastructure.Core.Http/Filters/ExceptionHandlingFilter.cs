using Ax3.IMS.Infrastructure.Core.Exception;
using Ax3.IMS.Infrastructure.Core.Http.HttpError;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Ax3.IMS.Infrastructure.Core.Http.Filters
{
    public sealed class ExceptionHandlingFilter : IExceptionFilter
    {
        public const string HandledExceptionKey = "HandledException";

        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionHandlingFilter> _logger;

        public ExceptionHandlingFilter(IHostEnvironment env, ILogger<ExceptionHandlingFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var exception = GetMostInnerException(context.Exception);
            context.HttpContext.Items[HandledExceptionKey] = exception;

            if (context.Exception.GetType() == typeof(DomainException))
            {
                var problemDetails = new ValidationProblemDetails()
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Please refer to the errors property for additional details."
                };
                problemDetails.Errors.Add("DomainValidations", new string[] { context.Exception.Message.ToString() });
                context.Result = new BadRequestObjectResult(problemDetails);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var error = new HttpError.HttpError
                {
                    Messages = new[] { "An error occured. Please try it again later." },
                    Type = HttpErrorType.Other
                };

                if (_env.IsDevelopment())
                {
                    error.DeveloperMessage = context.Exception;
                }

                var statusCode = (int)GetStatusCode(exception);
                context.Result = new ObjectResult(error) { StatusCode = statusCode };
            }
            context.ExceptionHandled = true;
        }

        private static HttpStatusCode GetStatusCode(System.Exception exception)
        {
            if (exception is BadRequestException || exception is ArgumentException || exception is NotSupportedException)
            {
                return HttpStatusCode.BadRequest;
            }

            if (exception is ConflictException)
            {
                return HttpStatusCode.Conflict;
            }

            if (exception is NotFoundException)
            {
                return HttpStatusCode.NotFound;
            }

            if (exception is AuthenticationException)
            {
                return HttpStatusCode.Unauthorized;
            }

            if (exception is AuthorizationException)
            {
                return HttpStatusCode.Forbidden;
            }

            return HttpStatusCode.InternalServerError;
        }

        private static System.Exception GetMostInnerException(System.Exception exception)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            return exception;
        }
    }
}