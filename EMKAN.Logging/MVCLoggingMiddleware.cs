using EMKAN.Trace.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Logging
{
    /// <summary>
    /// Trace and record the requests, responses, and exceptions in MVC
    ///  https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
    /// </summary>
    public class MVCLoggingMiddleware
    {
        //Variables
        private readonly ILogger<MVCLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        //Constructor
        public MVCLoggingMiddleware(ILogger<MVCLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IRequestTrace requestTracer)
        {
            var requestId = Guid.NewGuid();
            //get the incoming request
            requestTracer.Register(requestId);
            try
            {
                LogRequestData(context, requestId);

                await _next(context);

                LogResponseData(context, requestId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, requestId + ": " + exception.Message);
            }
        }
        // Return the request info.
        private void LogRequestData(HttpContext context, Guid requestId)
        {
            _logger.LogDebug($"Request information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Scheme: {context.Request.Scheme}{Environment.NewLine}" +
                             $"Host: {context.Request.Host}{Environment.NewLine}" +
                             $"Path: {context.Request.Path}{Environment.NewLine}" +
                             $"QueryString: {context.Request.QueryString}{Environment.NewLine}" +
                             $"{Environment.NewLine}{Environment.NewLine}");
        }
        //Return the string for the response, including the status code
        private void LogResponseData(HttpContext context, Guid requestId)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            _logger.LogDebug($"Response information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Status Code: {context.Response.StatusCode}" +
                             $"{Environment.NewLine}{Environment.NewLine}");
        }
    }
}
