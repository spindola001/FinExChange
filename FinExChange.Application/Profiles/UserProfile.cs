using AutoMapper;
using FinExChange.Application.Commands.Users;
using FinExChange.Application.DTOs;
using FinExChange.Domain.Entities;

namespace FinExChange.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => new List<Transaction>()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateUserCommand, UserDTO>();

            CreateMap<UserDTO, User>();
        }
    }
}
