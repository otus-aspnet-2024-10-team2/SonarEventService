using AutoMapper;
using Domain.Entities;
using Services.Contracts.SonarProcess;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности процесса поиска.
    /// </summary>
    public class SonarProcessMappingsProfile : Profile
    {
        public SonarProcessMappingsProfile()
        {
            CreateMap<SearchEvent, SearchEventDto>();
            
            CreateMap<CreatingSearchEventDto, SearchEvent>()
                .ForMember(d => d.Id, map => map.Ignore())
                //.ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Tasks, map => map.Ignore());
            
            CreateMap<UpdatingSearchEventDto, SearchEvent>()
                .ForMember(d => d.Id, map => map.Ignore())
                //.ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Tasks, map => map.Ignore());

            CreateMap<UpdatingSearchEventWithSeacrchTasksDto, SearchEvent>()
                .ForMember(d => d.Id, map => map.Ignore())
                //.ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.Tasks, map => map.Ignore());
        }
    }
}
