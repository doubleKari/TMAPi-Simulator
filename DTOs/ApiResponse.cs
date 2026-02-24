using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.DTOs
{
    internal class ApiResponse<T>(bool success, string message, T data, int statuscode)
    {
        public bool Success { get; set; } = success;
        public string Message { get; set; } = message;

        public T Data { get; set; } = data;

        public int StatusCode { get; set; } = statuscode;

        public static ApiResponse<T> SuccessResponse(T data, string message)
        {

            return new ApiResponse<T>(true, message, data, 200);
        }

        public static ApiResponse<T> ErrorResponse (string message, T data, int statusCode)
        {
            return new ApiResponse<T>(false, message, data, statusCode);
        }
    }
}
