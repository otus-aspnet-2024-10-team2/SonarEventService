using AutoMapper;
using Services.Contracts.GroupMember;
using WebApi.Models.GroupMember;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности Участник группы поиска.
    /// </summary>
    public class GroupMemberMappingProfile : Profile
    {
        public GroupMemberMappingProfile()
        {
            CreateMap<GroupMemberDto, GroupMemberModel>();
            CreateMap<CreatingGroupMemberModel, CreatingGroupMemberDto>();
            CreateMap<UpdatingGroupMemberModel, UpdatingGroupMemberDto>();
            CreateMap<GroupMemberFilterModel, GroupMemberFilterDto>();
        }
    }
}
