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
                .ForMember(d => d.SonarProcess, map => map.Ignore())
                .ForMember(d => d.SonarProcessId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject));
            
            CreateMap<UpdatingSearchTaskDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SonarProcess, map => map.Ignore())
                .ForMember(d => d.SonarProcessId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
            
            CreateMap<AttachingSonarTasksDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SonarProcess, map => map.Ignore())
                .ForMember(d => d.SonarProcessId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
        }
    }
}
