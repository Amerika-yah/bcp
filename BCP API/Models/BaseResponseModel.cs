namespace BCP_API.Models
{
    public class BaseResponseModel
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
