using System.Net.Http.Headers;
using Ese.WebApi.Core.Usuario;
using Ese.WebApp.Mvc.Extensions;

namespace Ese.WebApp.Mvc.Services.Handler
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IAspNetUser _user;

        public HttpClientAuthorizationDelegatingHandler(IAspNetUser user)
        {
            _user = user;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader))
                request.Headers.Add("Authorization", new List<string>() { authorizationHeader });

            var token = _user.ObterUserToken();

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
