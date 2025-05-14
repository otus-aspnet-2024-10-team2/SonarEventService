using AutoMapper;
using Services.Contracts.User;
using WebApi.Models.User;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности пользователь.
    /// </summary>
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDto, UserModel>();
            CreateMap<CreatingUserModel, CreatingUserDto>();
            CreateMap<UpdatingUserModel, UpdatingUserDto>();
        }
    }
}
