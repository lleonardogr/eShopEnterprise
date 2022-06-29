using Ese.Core.Messages;
using FluentValidation.Results;

namespace Ese.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T Evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T Comando) where T : Command;
    }
}
