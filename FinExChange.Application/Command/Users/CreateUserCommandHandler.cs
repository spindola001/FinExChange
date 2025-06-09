using AutoMapper;
using FinExChange.Application.DTOs;
using FinExChange.Domain.Entities;
using FinExChange.Domain.Interfaces;
using MediatR;
//using FinExChange.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinExChange.Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper? _mapper;
        private readonly IUserRepository? _userRepository;

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Lógica para criar o usuário
            User? userEntity = _mapper?.Map<User>(request) ?? throw new Exception("Erro ao mapear o usuário.");

            // Simulação de persistência
            Guid newUserId = await (_userRepository?.CreateUserAsync(userEntity) ?? throw new Exception("Erro ao criar o usuário."));

            return newUserId;
        }
    }
}
