using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinExChange.Application.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        public Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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
