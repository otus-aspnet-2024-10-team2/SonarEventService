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
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Event, map => map.Ignore())
                .ForMember(d => d.AssignedTo, map => map.Ignore())
                ;

            CreateMap<UpdatingSearchTaskDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.AssignedTo, map => map.Ignore())
                .ForMember(d => d.Event, map => map.Ignore())
                ;

            CreateMap<AttachingSearchTasksDto, SearchTask>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Event, map => map.Ignore())
                .ForMember(d => d.AssignedTo, map => map.Ignore())
                 ;
        }
    }
}
