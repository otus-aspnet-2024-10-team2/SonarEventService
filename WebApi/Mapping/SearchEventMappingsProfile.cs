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
            // VDV: Вернуть
            //CreateMap<SearchEventFilterModel, SearchEventFilterDto>();
            //CreateMap<UpdatingSearchEventWithSearchTasksModel, UpdatingSearchEventWithSeacrchTasksDto>();
        }
    }
}
