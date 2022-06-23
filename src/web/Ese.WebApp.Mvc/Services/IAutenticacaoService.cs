using Ese.WebApp.Mvc.Models;

namespace Ese.WebApp.Mvc.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin);
        Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro);
    }
}
