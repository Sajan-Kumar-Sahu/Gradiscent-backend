﻿namespace Gradiscent.Application.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> SuccessfulRespone(T data, string message = "Request successful")
            => new ApiResponse<T> { Success = true, Message = message, Data = data,};

        public static ApiResponse<T> FailedResponse(string message)
            => new ApiResponse<T> { Success = false, Message = message};
    }
}
