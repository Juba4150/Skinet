namespace API.Errors
{
    public class ApiExceptionResponce : ApiErrorResponse
    {
        public ApiExceptionResponce(int statusCode, string message = null,string details=null) : base(statusCode, message)
        {
            this.Details=details;
        }
        public string Details { get; set; }
    }
}