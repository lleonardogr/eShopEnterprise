using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Ese.WebApi.Core.Usuario
{
    public interface IAspNetUser
    {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRole(string Role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }
}
