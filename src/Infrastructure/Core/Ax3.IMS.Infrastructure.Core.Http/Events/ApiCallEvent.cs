using Ax3.IMS.Infrastructure.Core.Http.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Net;

namespace Ax3.IMS.Infrastructure.Core.Http.Events
{
    public class ApiCallEvent
    {
        public DateTime AccessTime { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public string HttpMethod { get; set; }

        public string RemoteIpAddress { get; set; }

        public long RequestExecutionTime { get; set; }

        public string RequestUri { get; set; }

        public HttpStatusCode? ResponseStatusCode { get; set; }

        public string RouteTemplate { get; set; }

        public string UserAgent { get; set; }

        public ApiCallEvent(
            HttpRequest request,
            HttpResponse response = null,
            long? requestExecutionTime = null)
        {
            AccessTime = DateTime.Now;
            RequestExecutionTime = requestExecutionTime ?? 0;
            ResponseStatusCode = response != null ? (HttpStatusCode)response.StatusCode : default(HttpStatusCode?);
            RequestUri = request.GetDisplayUrl();
            RemoteIpAddress = request.GetClientIpAddress();
            HttpMethod = request.Method;
            RouteTemplate = request.Path.HasValue ? request.Path.Value : string.Empty;
            UserAgent = request.Headers["User-Agent"].FirstOrDefault();
            ControllerName = request.HttpContext.GetRouteValue("controller")?.ToString();
            ActionName = request.HttpContext.GetRouteValue("action")?.ToString();
        }
    }
}