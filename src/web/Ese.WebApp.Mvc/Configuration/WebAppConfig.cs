using Ese.WebApp.Mvc.Extensions;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Ese.WebApp.Mvc.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this WebApplicationBuilder builder) 
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (builder.Environment.IsDevelopment())
                builder.Configuration.AddUserSecrets<Program>();

            builder.Services.AddControllersWithViews();
            builder.AddIdentityConfiguration();
            builder.Services.Configure<AppSettings>(builder.Configuration);
        }

        public static void UseMvcConfiguration(this WebApplication app) 
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("erro/{0}");
                app.UseHsts();
            }
            else
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Catalogo}/{action=Index}/{id?}");
        }
    }
}
