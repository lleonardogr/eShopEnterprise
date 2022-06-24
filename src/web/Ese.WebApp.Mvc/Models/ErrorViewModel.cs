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
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessagesVieWModel Errors { get; set; }
    }

    public class ResponseErrorMessagesVieWModel
    { 
        public List<string> Mensagens { get; set; }
    }
}