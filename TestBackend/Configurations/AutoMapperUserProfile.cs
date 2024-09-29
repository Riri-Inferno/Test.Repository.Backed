using AutoMapper;
using TestBackend.Models.Entities;
using TestBackend.Interactor.Dtos;

namespace TestBackend.Configrations.Configurations
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            // エンティティからDTOへのマッピング
            CreateMap<User, UserReadResponse>();
            // DTOからエンティティへのマッピング
            CreateMap<UserReadResponse, User>();
        }
    }
}
