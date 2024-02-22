using AutoMapper;
using UserDetails.Api.Models;
using UserDetails.Api.Models.Entities;

namespace UserDetails.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}