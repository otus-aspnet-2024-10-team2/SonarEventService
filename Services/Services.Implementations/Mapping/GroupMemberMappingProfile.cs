using AutoMapper;
using Domain.Entities;
using Services.Contracts.GroupMember;
using Services.Contracts.SearchGroup;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности участник грууппы поиска.
    /// </summary>
    public class GroupMemberMappingsProfile : Profile
    {
        public GroupMemberMappingsProfile()
        {
            CreateMap<GroupMember, GroupMemberDto>()
                .ForMember(d => d.MemberId, map => map.MapFrom(m => m.Id));

            CreateMap<CreatingGroupMemberDto, GroupMember>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Group, map => map.Ignore())
                .ForMember(d => d.User, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore());

            CreateMap<UpdatingGroupMemberDto, GroupMember>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Group, map => map.Ignore())
                .ForMember(d => d.User, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore());
        }
    }
}
