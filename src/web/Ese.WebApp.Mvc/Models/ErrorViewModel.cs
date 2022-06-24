namespace Ese.WebApp.Mvc.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ResponseResultViewModel
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessagesVieWModel Errors { get; set; }
    }

    public class ResponseErrorMessagesVieWModel
    { 
        public List<string> Mensagens { get; set; }
    }
}