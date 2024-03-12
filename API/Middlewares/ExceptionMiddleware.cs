using API.Exceptions;
using Application.Exceptions;
using CleanArchitecture.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace API.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.ContentType = "application/json";

                var statusCode = (int)HttpStatusCode.InternalServerError;

                var result = string.Empty;

                switch (e)
                {
                    case NotFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case BadRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ConflictException:
                        statusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        // serializing the validation errors to a json structure
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, e.Message, validationJson));
                        break;
                }

                if (string.IsNullOrWhiteSpace(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, e.Message, e.StackTrace));

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
