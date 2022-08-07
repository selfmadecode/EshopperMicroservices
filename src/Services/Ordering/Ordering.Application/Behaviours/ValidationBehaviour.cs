using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Ordering.Application.Exceptions.ValidationException; // using custom ValidationException

namespace Ordering.Application.Behaviours
{
    // intercepts the request and runs the validation rules associated with the request
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> // MediatR 9.5.3 does not have this
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        // IValidator interface is implemented by the AbstractValidator classes, so the validation rules can be gotten

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // runs all rules defined in the AbstractValidator class
                var validationFailures = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationFailures.SelectMany(x => x.Errors).Where(e => e != null).ToList();

                if(failures.Count > 0)
                {
                    //throw new ValidationException(failures); // Fluent validation exception class
                    throw new ValidationException(failures);
                }
            }

            return await next(); // calls the next method in the pipeline
        }
    }
}
