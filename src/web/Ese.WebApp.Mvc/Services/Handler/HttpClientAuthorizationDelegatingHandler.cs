﻿using Ese.WebApp.Mvc.Extensions;
using System.Net.Http.Headers;

namespace Ese.WebApp.Mvc.Services.Handler
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IUser _user;

        public HttpClientAuthorizationDelegatingHandler(IUser user)
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
