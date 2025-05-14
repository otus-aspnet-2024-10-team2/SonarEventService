using AutoMapper;
using Domain.Entities;
using Services.Contracts.User;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности пользователя.
    /// </summary>
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<CreatingUserDto, User>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())                
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Animals, map => map.Ignore())
                .ForMember(d => d.SearchAnnouncements, map => map.Ignore())
                .ForMember(d => d.CoordinatedRequests, map => map.Ignore())
                .ForMember(d => d.LedGroups, map => map.Ignore())
                .ForMember(d => d.CreatedEvents, map => map.Ignore())
                .ForMember(d => d.AssignedTasks, map => map.Ignore())
                .ForMember(d => d.GroupMemberships, map => map.Ignore())
                ;

            CreateMap<UpdatingUserDto, User>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Animals, map => map.Ignore())
                .ForMember(d => d.SearchAnnouncements, map => map.Ignore())
                .ForMember(d => d.CoordinatedRequests, map => map.Ignore())
                .ForMember(d => d.LedGroups, map => map.Ignore())
                .ForMember(d => d.CreatedEvents, map => map.Ignore())
                .ForMember(d => d.AssignedTasks, map => map.Ignore())
                .ForMember(d => d.GroupMemberships, map => map.Ignore())
                ;
        }
    }
}
