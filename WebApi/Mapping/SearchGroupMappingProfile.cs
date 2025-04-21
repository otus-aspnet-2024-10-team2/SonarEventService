using AutoMapper;
using Services.Contracts.SearchGroup;
using WebApi.Models.SearchGroup;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности Группа поиска.
    /// </summary>
    public class SearchGroupMappingProfile : Profile
    {
        public SearchGroupMappingProfile()
        {
            CreateMap<SearchGroupDto, SearchGroupModel>();
            CreateMap<CreatingSearchGroupModel, CreatingSearchGroupDto>();
            CreateMap<UpdatingSearchGroupModel, UpdatingSearchGroupDto>();
            CreateMap<SearchGroupFilterModel, SearchGroupFilterDto>();
        }
    }
}
