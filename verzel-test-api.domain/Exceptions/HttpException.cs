using System.Net;

namespace verzel_test_api.domain.Exceptions
{
    public class HttpException : Exception
    {
        private readonly HttpStatusCode _httpStatusCode;

        public HttpException(string? message, HttpStatusCode httpStatusCode) : base(message)
        {
            _httpStatusCode = httpStatusCode;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return _httpStatusCode;
        }
    }
}
