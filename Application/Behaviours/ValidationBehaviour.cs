using FluentValidation;
using MediatR;
// the reference to the ValidationException class is ambiguous here because FluentValidation has also a class named like that
using ValidationException = CleanArchitecture.Application.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Behaviours
{
    // this will execute the written validations within the pipeline before the request gets to the command or the query
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // if there are any validations written then execute them
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // executing found validations
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request, cancellationToken)));

                // checking for failures within the validations
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // if there are any failure, then execute the exception and the request won't reach the command handler or query handler
                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
