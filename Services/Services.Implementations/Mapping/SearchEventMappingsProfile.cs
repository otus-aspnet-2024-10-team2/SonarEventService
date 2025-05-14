using AutoMapper;
using Domain.Entities;
using Services.Contracts.SonarProcess;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности процесса поиска.
    /// </summary>
    public class SearchEventMappingsProfile : Profile
    {
        public SearchEventMappingsProfile()
        {
            CreateMap<SearchEvent, SearchEventDto>();
            // VDV: Вернуть            
            //CreateMap<CreatingSearchEventDto, SearchEvent>()
            //    .ForMember(d => d.Id, map => map.Ignore())
            //    //.ForMember(d => d.Deleted, map => map.Ignore())
            //    .ForMember(d => d.Tasks, map => map.Ignore());

            //CreateMap<UpdatingSearchEventDto, SearchEvent>()
            //    .ForMember(d => d.Id, map => map.Ignore())
            //    //.ForMember(d => d.Deleted, map => map.Ignore())
            //    .ForMember(d => d.Tasks, map => map.Ignore());

            //CreateMap<UpdatingSearchEventWithSeacrchTasksDto, SearchEvent>()
            //    .ForMember(d => d.Id, map => map.Ignore())
            //    //.ForMember(d => d.Deleted, map => map.Ignore())
            //    .ForMember(d => d.Tasks, map => map.Ignore());
        }
    }
}
