using AutoMapper;
using Domain.Entities;
using Services.Contracts.GroupMember;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности участник грууппы поиска.
    /// </summary>
    public class GroupMemberMappingsProfile : Profile
    {
        public GroupMemberMappingsProfile()
        {
            CreateMap<GroupMember, GroupMemberDto>();

            CreateMap<CreatingGroupMemberDto, GroupMember>()
                .ForMember(d => d.Id, map => map.Ignore());

            CreateMap<UpdatingGroupMemberDto, GroupMember>()
                .ForMember(d => d.Id, map => map.Ignore());
        }
    }
}
