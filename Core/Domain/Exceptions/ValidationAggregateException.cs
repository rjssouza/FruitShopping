using System;
using System.Collections.Generic;

namespace Core.Domain.Exceptions
{
    public class ValidationAggregateException : AggregateException
    {
        public ValidationAggregateException(string message, IEnumerable<ValidationException> innerExceptions)
            : base(message, innerExceptions)
        {
        }

        public ValidationAggregateException(params ValidationException[] innerExceptions)
            : base(innerExceptions)
        {
        }
    }
}