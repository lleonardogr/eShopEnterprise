using Ese.Catalogo.Api.Data;
using Ese.Catalogo.Api.Data.Repository;
using Ese.Catalogo.Api.Models;

namespace Ese.Catalogo.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<CatalogoContext>();
        }
    }
}
