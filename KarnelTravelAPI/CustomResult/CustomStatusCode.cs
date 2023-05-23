namespace KarnelTravelAPI.CustomResult
{
    public class CustomStatusCode<T>
    {
        public CustomStatusCode(int status, string message, T? data, string? error)
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
