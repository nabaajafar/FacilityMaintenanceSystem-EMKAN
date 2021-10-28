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
    /// Trace the requests, responses, and exceptions in API
    ///  https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
    /// </summary>
    public class APILoggingMiddleware
    {
        //Variables
        //  private readonly ILogger<APILoggingMiddleware> _logger;
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        //Constructor
        /*   public APILoggingMiddleware(ILogger<APILoggingMiddleware> logger, RequestDelegate next)
           {
               _logger = logger;
               _next = next;
           }*/
        public APILoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<APILoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context, IRequestTrace requestTracer)
        {
            var requestId = Guid.NewGuid();
            // get the incoming request
            requestTracer.Register(requestId);
            try
            {
                await LogRequestData(context, requestId);
                //Copy a pointer to the original response body stream
                var originalBodyStream = context.Response.Body;
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);

                await LogResponseData(context.Response, requestId);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, requestId + ": " + exception.Message);
            }
        }
        private async Task LogRequestData(HttpContext context, Guid requestId)
        {
            //reader for the request back at the beginning of its stream (ensure the request Body can be read multiple times).
            //core 3.x
            context.Request.EnableBuffering();
            //core 2.x
            //context.Request.EnableRewind();
            var body = context.Request.Body;
            //To read the request stream, we create a new byte[] with the same length as the request stream.
            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
            //copy the entire request stream into the new buffer.
            await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            context.Request.Body.Position = 0;
            //convert the byte[] into a string using UTF8 encoding.
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            //assign the read body back to the request body, which is allowed because of EnableRewind()/ EnableBuffering()
            context.Request.Body = body;
            // Return the request info.
            _logger.LogDebug($"Request information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Scheme: {context.Request.Scheme}{Environment.NewLine}" +
                             $"Host: {context.Request.Host}{Environment.NewLine}" +
                             $"Path: {context.Request.Path}{Environment.NewLine}" +
                             $"QueryString: {context.Request.QueryString}{Environment.NewLine}" +
                             $"Body: {bodyAsText}" +
                             $"{Environment.NewLine}{Environment.NewLine}");
        }
        private async Task LogResponseData(HttpResponse response, Guid requestId)
        {
            //To read the response stream from the beginning
            response.Body.Seek(0, SeekOrigin.Begin);
            //copy it into a string
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            // reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);
            //Return the string for the response, including the status code
            _logger.LogDebug($"Response information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Status Code: {response.StatusCode}" +
                             $"text: {text}");
        }

    }
}
