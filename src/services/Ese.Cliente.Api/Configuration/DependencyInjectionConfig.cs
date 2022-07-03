using Ese.Cliente.Api.Data;
using Ese.Core.Mediator;
using MediatR;
using FluentValidation.Results;
using Ese.Cliente.Api.Application.Commands;
using Ese.Cliente.Api.Models;
using Ese.Cliente.Api.Application.Events;
using Ese.Cliente.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ese.Cliente.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
            builder.Services.AddScoped<IRequestHandler<RegistrarClienteCommand,ValidationResult>, ClienteCommandHandler>();

            builder.Services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<ClienteContext>();

            builder.Services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
