using AutoMapper;
using Domain.Entities;
using Services.Contracts.SonarTask;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности задачи поиска.
    /// </summary>
    public class SearchTaskMappingsProfile : Profile
    {
        public SearchTaskMappingsProfile()
        {
            CreateMap<SearchTask, SearchTaskDto>();

            CreateMap<CreatingSearchTaskDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SearchEvent, map => map.Ignore())
                .ForMember(d => d.SearchEventId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject));
            
            CreateMap<UpdatingSearchTaskDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SearchEvent, map => map.Ignore())
                .ForMember(d => d.SearchEventId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
            
            CreateMap<AttachingSearchTasksDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SearchEvent, map => map.Ignore())
                .ForMember(d => d.SearchEventId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
        }
    }
}
