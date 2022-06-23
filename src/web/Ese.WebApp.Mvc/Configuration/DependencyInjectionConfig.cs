using Ese.WebApp.Mvc.Services;

namespace Ese.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
        }
    }
}
