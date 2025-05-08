using AutoMapper;
using Services.Contracts.SonarProcess;
using WebApi.Models.SonarProcess;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности мероприятия поиска.
    /// </summary>
    public class SonarProcessMappingsProfile : Profile
    {
        public SonarProcessMappingsProfile()
        {
            CreateMap<SearchEventDto, SearchEventModel>();
            CreateMap<CreatingSeachEventModel, CreatingSearchEventDto>();
            CreateMap<UpdatingSearchEventModel, UpdatingSearchEventDto>();
            CreateMap<SearchEventFilterModel, SearchEventFilterDto>();
            CreateMap<UpdatingSearchEventWithSearchTasksModel, UpdatingSearchEventWithSeacrchTasksDto>();
        }
    }
}
