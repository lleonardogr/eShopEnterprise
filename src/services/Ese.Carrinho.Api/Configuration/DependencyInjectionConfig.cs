using Ese.Carrinho.Api.Data;
using Ese.WebApi.Core.Usuario;

namespace Ese.Carrinho.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();
            builder.Services.AddScoped<CarrinhoContext>();
        }
    }
}
