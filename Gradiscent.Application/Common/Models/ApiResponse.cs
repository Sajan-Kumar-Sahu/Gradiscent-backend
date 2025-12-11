namespace Gradiscent.Application.Common.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(bool success, string message, List<string> errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }

        public static ApiResponse SuccessResponse(string message = "Success")
        {
            return new ApiResponse(true, message);
        }

        public static ApiResponse Fail(string message, List<string> errors = null)
        {
            return new ApiResponse(false, message, errors);
        }
    }
}
