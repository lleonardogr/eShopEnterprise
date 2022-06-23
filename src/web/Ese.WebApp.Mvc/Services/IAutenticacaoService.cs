using Ese.WebApp.Mvc.Models;

namespace Ese.WebApp.Mvc.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLoginViewModel usuarioLogin);
        Task<string> Registro(UsuarioRegistroViewModel usuarioRegistro);
    }
}
