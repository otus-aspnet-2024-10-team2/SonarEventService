using AutoMapper;
using Domain.Entities;
using Services.Contracts.SonarTask;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности задачи поиска.
    /// </summary>
    public class SonarTaskMappingsProfile : Profile
    {
        public SonarTaskMappingsProfile()
        {
            CreateMap<SonarTask, SonarTaskDto>();

            CreateMap<CreatingSonarTaskDto, SonarTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SonarProcess, map => map.Ignore())
                .ForMember(d => d.SonarProcessId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject));
            
            CreateMap<UpdatingSonarTaskDto, SonarTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SonarProcess, map => map.Ignore())
                .ForMember(d => d.SonarProcessId, map => map.Ignore())
                //.ForMember(d => d.DateTime, map => map.Ignore())
                .ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                ;
            
            CreateMap<AttachingSonarTasksDto, SonarTask>()
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
