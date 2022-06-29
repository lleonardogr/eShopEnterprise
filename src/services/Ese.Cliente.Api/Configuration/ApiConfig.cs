using Ese.Cliente.Api.Data;
using Ese.WebApi.Core.Identidade;
using Microsoft.EntityFrameworkCore;

namespace Ese.Cliente.Api.Configuration
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (builder.Environment.IsDevelopment())
                builder.Configuration.AddUserSecrets<Program>();

            builder.Services.AddDbContext<ClienteContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("eShopEnterprise")));

            
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Total", builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return builder;
        }

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseCors("Total");

            app.UseAuthConfiguration();

            app.MapControllers();

            return app;
        }
    }
}
