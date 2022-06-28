using Ese.WebApp.Mvc.Extensions;
using Ese.WebApp.Mvc.Services;
using Ese.WebApp.Mvc.Services.Handler;

namespace Ese.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            builder.Services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUser, AspNetUser>();
        }
    }
}
