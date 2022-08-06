using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Error { get; }

        public ValidationException()
            : base("One or more validation failures have occured.")
        {
            Error = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) // validationfaluires comes from fluentAPI
            :this()
        {
            Error = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
