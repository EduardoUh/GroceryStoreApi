namespace API.Common
{
    public class DefaultResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Request was successfull";
    }
}
