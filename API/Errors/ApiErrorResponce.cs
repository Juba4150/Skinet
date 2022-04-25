using System;

namespace API.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch{
                400=>"A bad Request, you have made",
                401=>"Authorized, you are not",
                404=>"Resource not found, it was not",  
                500=>"Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _=>null 
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}