using AutoMapper;
using Services.Contracts.SonarProcess;
using WebApi.Models.SearchEvent;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности мероприятия поиска.
    /// </summary>
    public class SearchEventMappingsProfile : Profile
    {
        public SearchEventMappingsProfile()
        {
            CreateMap<SearchEventDto, SearchEventModel>();
            CreateMap<CreatingSeachEventModel, CreatingSearchEventDto>();
            CreateMap<UpdatingSearchEventModel, UpdatingSearchEventDto>();
            CreateMap<UpdatingSearchEventWithSearchTasksModel, UpdatingSearchEventWithSeacrchTasksDto>();
            CreateMap<SearchEventFilterModel, SearchEventFilterDto>();
        }
    }
}
