using MediatR;
using System;

namespace FinExChange.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
