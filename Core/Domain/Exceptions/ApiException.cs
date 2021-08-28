using System;
using System.Net;

namespace Core.Domain.Exceptions
{
    public abstract class ApiException : Exception
    {
        private readonly HttpStatusCode _httpStatusCode;
        public HttpStatusCode HttpStatusCode => this._httpStatusCode;
        public abstract int TroubleshootingId { get; }

        public ApiException(HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            this._httpStatusCode = httpStatusCode;
        }
    }
}