using Ese.WebApi.Core.Usuario;
using Ese.WebApp.Mvc.Extensions;
using Ese.WebApp.Mvc.Services;
using Ese.WebApp.Mvc.Services.Handler;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Ese.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IAspNetUser, AspNetUser>();


            #region HttpServices
            builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            builder.Services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                //.AddTransientHttpErrorPolicy(p => 
                //p.WaitAndRetryAsync(3 , _ => TimeSpan.FromMilliseconds(600)));
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(p => 
                    p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            //builder.Services.AddHttpClient("Refit", options => {
            //    options.BaseAddress = new Uri(builder.Configuration.GetSection("CatalogoUrl").Value);
            //})
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

            builder.Services.AddHttpClient<ICarrinhoService, CarrinhoService>()
               .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
               //.AddTransientHttpErrorPolicy(p => 
               //p.WaitAndRetryAsync(3 , _ => TimeSpan.FromMilliseconds(600)));
               .AddPolicyHandler(PollyExtensions.EsperarTentar())
               .AddTransientHttpErrorPolicy(p =>
                   p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            #endregion


        }
    }

    #region PollyExtensions
    public class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            return retry;
        }
    }

    #endregion
}
