using Ese.WebApp.Mvc.Extensions;

namespace Ese.WebApp.Mvc.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this WebApplicationBuilder builder) 
        {
            builder.Services.AddControllersWithViews();
            builder.AddIdentityConfiguration();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();
            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
