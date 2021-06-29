using System;
using System.Net;

namespace TaxService.Exceptions
{
    public class HttpCustomException : Exception
    {
        public int StatusCode { get; }

        public HttpCustomException(HttpStatusCode statusCode, string message, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = (int)statusCode;
        }

        
    }
}