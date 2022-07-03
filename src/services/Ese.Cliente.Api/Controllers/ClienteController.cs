using Ese.Cliente.Api.Application.Commands;
using Ese.Core.Mediator;
using Ese.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ese.Cliente.Api.Controllers
{
    [ApiController]
    public class ClienteController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public ClienteController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> IndexAsync()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                 new RegistrarClienteCommand(Guid.NewGuid(), "Teste", "teste@teste.com.br", "30314299076"));

            return CustomResponse(resultado);
        }
    }
}
