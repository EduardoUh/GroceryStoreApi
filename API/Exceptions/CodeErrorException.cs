namespace API.Exceptions
{
    public class CodeErrorException(int statusCode, string? message = null, string? details = null) : CodeErrorResponse(statusCode, message)
    {
        public string? Detailes { get; set; } = details;
    }
}
