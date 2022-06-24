using Ese.WebApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ese.WebApp.Mvc.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResultViewModel resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
                return true;
            return false;
        }
    }
}
