using Ese.Cliente.Api.Data;

namespace Ese.Cliente.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ClienteContext>();
        }
    }
}
