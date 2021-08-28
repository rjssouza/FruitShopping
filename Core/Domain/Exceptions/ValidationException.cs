using System.Net;

namespace Core.Domain.Exceptions
{
    public class ValidationException : ApiException
    {
        public override int TroubleshootingId => 0;

        public ValidationException(string message)
                            : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}