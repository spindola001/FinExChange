using FinExChange.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinExChange.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/users")]
        public Task<IActionResult> GetAllUsers()
        {
            // Logic to get all users


            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserCommand user)
        {
            // Logic to create a new user
            _mediator.Send(user);

            return Ok();
        }
    }
}
