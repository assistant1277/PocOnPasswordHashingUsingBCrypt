using AutoMapper;
using PasswordHashing.Dtos;
using PasswordHashing.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordHashing.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map UserDto to User and reverse map
            CreateMap<UserDto, User>().ReverseMap();

            // Map LoginDto to User (if needed for extended scenarios)
            CreateMap<LoginDto, User>();
        }
    }
}
