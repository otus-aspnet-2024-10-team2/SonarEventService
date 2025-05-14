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

            CreateMap<CreatingSearchEventDto, SearchEvent>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Request, map => map.Ignore())
                .ForMember(d => d.CreatedBy, map => map.Ignore())
                .ForMember(d => d.Tasks, map => map.Ignore())
            ;

            CreateMap<UpdatingSearchEventDto, SearchEvent>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedById, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.Request, map => map.Ignore())
                .ForMember(d => d.CreatedBy, map => map.Ignore())
                .ForMember(d => d.Tasks, map => map.Ignore());

            // VDV: Вернуть            
            //CreateMap<UpdatingSearchEventWithSeacrchTasksDto, SearchEvent>()
            //    .ForMember(d => d.Id, map => map.Ignore())
            //    //.ForMember(d => d.Deleted, map => map.Ignore())
            //    .ForMember(d => d.Tasks, map => map.Ignore());
        }
    }
}
