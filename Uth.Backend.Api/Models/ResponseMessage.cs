namespace Uth.Backend.Api.Models
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class ResponseMessage<TData> : ResponseMessage
    {

        public TData data { get; set; }
    }

}



