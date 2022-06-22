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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
