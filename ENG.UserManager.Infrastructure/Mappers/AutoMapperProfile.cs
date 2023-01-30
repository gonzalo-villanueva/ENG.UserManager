using AutoMapper;
using ENG.UserManager.Domain.Entities;
using ENG.UserManager.Domain.Models;

namespace ENG.UserManager.Infrastructure.Mappers;

public class AutoMapperProfile : Profile 
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserCreateModel>().ReverseMap();
    }
}
