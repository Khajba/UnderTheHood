namespace Uth.Admin.Api.Models
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }

        public object Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}

