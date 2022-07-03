using Ese.Cliente.Api.Services;
using Ese.Core.Utils;
using Ese.MessageBus;

namespace Ese.Cliente.Api.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this WebApplicationBuilder builder)
        { 
            builder.Services.AddMessageBus(builder.Configuration.GetMessageQueueConnection("MessageBus"))
            .AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
