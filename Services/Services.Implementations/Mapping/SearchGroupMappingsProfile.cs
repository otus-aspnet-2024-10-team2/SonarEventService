using AutoMapper;
using Domain.Entities;
using Services.Contracts.SearchGroup;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности группа поиска.
    /// </summary>
    public class SearchGroupMappingsProfile : Profile
    {
        public SearchGroupMappingsProfile()
        {
            CreateMap<SearchGroup, SearchGroupDto>()
                .ForMember(d => d.GroupId, map => map.MapFrom(m => m.Id));

            CreateMap<CreatingSearchGroupDto, SearchGroup>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Request, map => map.Ignore())
                .ForMember(d => d.Leader, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Members, map => map.Ignore())
                ;
            CreateMap<UpdatingSearchGroupDto, SearchGroup>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Request, map => map.Ignore())
                .ForMember(d => d.Leader, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Members, map => map.Ignore())
                ;
        }
    }
}
