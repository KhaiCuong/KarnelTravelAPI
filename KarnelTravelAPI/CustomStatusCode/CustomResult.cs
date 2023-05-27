using Microsoft.AspNetCore.Http;

namespace KarnelTravelAPI.CustomStatusCode
{
    public class CustomResult<T>
    {
        public CustomResult()
        {
            
        }

        public CustomResult(int status, string message, T? data ,string? error)
        {
            Status = status;    
            Message = message;
            Data = data;
            Error = error;
        }
        public int Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public string? Error { get; set; }
    }
}
