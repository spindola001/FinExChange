using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinExChange.Application.Commands.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // Lógica para deletar o usuário
            // _userRepository.Delete(request.Id);

            return Task.FromResult(true);
        }
    }
}
