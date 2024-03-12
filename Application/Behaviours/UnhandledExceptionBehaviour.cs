using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Behaviours
{
    // this will execute within the handle methods of commands or queries if there is a error, it will
    // be handled by this
    public class UnhandledExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger = logger;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                // The @ symbol indicates that the object should be serialized as structured data.In this case, it's likely the entire request object
                // being logged for debugging purposes.
                _logger.LogError(ex, "Application request: An exception was triggered for the request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}
