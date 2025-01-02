namespace MeetlyOmni.Core.WrapperResult
{
    public class ApiResponseResult
    {
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
        public string? Message { get; set; }
        public DateTime Time { get; set; }
    }

    public class ApiResponseResult<T> : ApiResponseResult
    {
        public T Data { get; set; }
    }
}
