using AutoMapper;
using FinExChange.Application.Commands.Users;
using FinExChange.Application.DTOs;
using FinExChange.Domain.Entities;
using System.Reflection.Metadata;

namespace FinExChange.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, UserDTO>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserDTO, User>();
        }
    }
}
