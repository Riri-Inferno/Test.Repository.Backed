using AutoMapper;
using TestBackend.Models.Entities;
using TestBackend.Interactor.Dtos;

namespace TestBackend.Configrations.Configurations
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<User, ReadUserResponse>().ReverseMap();
            CreateMap<User, CreateUserRequest>().ReverseMap();
        }
    }
}
