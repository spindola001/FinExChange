using FinExChange.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinExChange.API.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/finexchange/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário pelo ID", Description = "Retorna os detalhes de um usuário específico.")]
        [SwaggerResponse(200, "Usuário encontrado com sucesso.")]
        [SwaggerResponse(404, "Usuário não encontrado.")]
        public async Task<IActionResult> GetUserById()
        {
            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo usuário", Description = "Adiciona um novo usuário ao sistema.")]
        [SwaggerResponse(201, "Usuário criado com sucesso.")]
        [SwaggerResponse(400, "Dados inválidos para criação do usuário.")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualiza um usuário existente", Description = "Atualiza os dados de um usuário específico.")]
        [SwaggerResponse(204, "Usuário atualizado com sucesso.")]
        [SwaggerResponse(400, "Dados inválidos para atualização do usuário.")]
        [SwaggerResponse(404, "Usuário não encontrado.")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um usuário", Description = "Remove um usuário do sistema pelo ID.")]
        [SwaggerResponse(204, "Usuário excluído com sucesso.")]
        [SwaggerResponse(404, "Usuário não encontrado.")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
