using MediatR;
//using FinExChange.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinExChange.Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Lógica para criar o usuário
            //var user = new User
            //{
            //    Id = Guid.NewGuid(),
            //    Name = request.Name,
            //    Email = request.Email,
            //    PasswordHash = request.PasswordHash,
            //    PhoneNumber = request.PhoneNumber,
            //    CreatedAt = DateTime.UtcNow,
            //    Transactions = new List<Transaction>()
            //};

            // Simulação de persistência
            // _userRepository.Add(user);

            return Task.FromResult(Guid.NewGuid());
        }
    }
}
