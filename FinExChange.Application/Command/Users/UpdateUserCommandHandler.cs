using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinExChange.Application.Commands.Users
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, bool>
    {
        public Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            // Lógica para atualizar o usuário
            // var user = _userRepository.GetById(request.Id);
            // user.Name = request.Name;
            // user.Email = request.Email;
            // user.PhoneNumber = request.PhoneNumber;
            // _userRepository.Update(user);

            return Task.FromResult(true);
        }
    }
}
