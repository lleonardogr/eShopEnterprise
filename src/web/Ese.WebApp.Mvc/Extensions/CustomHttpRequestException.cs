using System.Net;

namespace Ese.WebApp.Mvc.Extensions
{
    public class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode {get;set;}

        public CustomHttpRequestException() { }
        public CustomHttpRequestException(string message, Exception innerException) : base(message, innerException) { }
        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        
    }
}
