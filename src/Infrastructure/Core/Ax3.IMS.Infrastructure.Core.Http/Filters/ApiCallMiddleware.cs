using Ax3.IMS.Infrastructure.Core.Http.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ax3.IMS.Infrastructure.Core.Http.Filters
{
    public class ApiCallMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ApiCallMiddleware(RequestDelegate next)
        {
            requestDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<ApiCallMiddleware> logger)
        {
            try
            {
                var start = Stopwatch.GetTimestamp();

                await requestDelegate(httpContext);

                var elapsed = GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

                var apiAccessEvent = new ApiCallEvent(httpContext.Request, httpContext.Response, elapsed);

                var statusCode = httpContext.Response?.StatusCode;

                var level = LogLevel.Warning;
                if (statusCode == null || statusCode > 499)
                {
                    level = LogLevel.Error;
                }
                else if (statusCode >= 200 && statusCode <= 299)
                {
                    level = LogLevel.Debug;
                }

                System.Exception exception;
                switch (level)
                {
                    case LogLevel.Error:
                        exception = GetHandledException(httpContext);
                        logger.LogError(exception, "Api error: {@ApiAccess}", apiAccessEvent);
                        break;

                    case LogLevel.Warning:
                        exception = GetHandledException(httpContext);
                        logger.LogWarning(exception, "Api unsuccessful access: {@ApiAccess}", apiAccessEvent);
                        break;

                    case LogLevel.Debug:
                        logger.LogDebug("Api successful access: {@ApiAccess}", apiAccessEvent);
                        break;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static System.Exception GetHandledException(HttpContext context)
        {
            context.Items.TryGetValue(ExceptionHandlingFilter.HandledExceptionKey, out var handledException);
            return handledException as System.Exception;
        }

        private static long GetElapsedMilliseconds(long start, long stop)
        {
            return (stop - start) * 1000 / Stopwatch.Frequency;
        }
    }
}