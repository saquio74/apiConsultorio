using apiConsultorio.Models.Dtos;
using apiConsultorio.Models.Entities;
using AutoMapper;

namespace apiConsultorio.infra;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>();
    }
}
