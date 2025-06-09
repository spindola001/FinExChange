using MediatR;
using System;

namespace FinExChange.Application.Commands.Users
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
