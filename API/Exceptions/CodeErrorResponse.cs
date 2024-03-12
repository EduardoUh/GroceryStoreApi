namespace API.Exceptions
{
    public class CodeErrorResponse(int statusCode, string? message = null)
    {
        public int StatusCode { get; set; } = statusCode;
        public string? Message { get; set; } = message ?? GetDefaultMessageStatusCode(statusCode);

        private static string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The request contains errors",
                401 => "Unauthorized",
                404 => "Not found",
                409 => "Conflict",
                500 => "Internal server error",
                _ => string.Empty
            };
        }
    }
}
