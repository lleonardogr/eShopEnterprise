namespace Ese.WebApp.Mvc.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }

    public class ResponseResultViewModel
    {
        public ResponseResultViewModel()
        {
            Errors = new ResponseErrorMessagesViewModel();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessagesViewModel Errors { get; set; }
    }

    public class ResponseErrorMessagesViewModel
    {
        public ResponseErrorMessagesViewModel()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}