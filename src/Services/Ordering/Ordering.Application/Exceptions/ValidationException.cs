using System;
using System.Collections.Generic;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base("One or more validation failures have occured.")
        {
            Error = new Dictionary<string, string[]>();
        }

        public IDictionary<string, string[]> Error { get;}
    }
}
