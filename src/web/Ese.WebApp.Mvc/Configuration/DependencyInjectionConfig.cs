using Ese.WebApp.Mvc.Extensions;
using Ese.WebApp.Mvc.Services;

namespace Ese.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUser, AspNetUser>();
        }
    }
}
