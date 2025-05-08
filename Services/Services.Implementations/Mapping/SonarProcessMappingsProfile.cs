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
            CreateMap<SonarProcess, SonarProcessDto>();
            
            CreateMap<CreatingSonarProcessDto, SonarProcess>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SearchTasks, map => map.Ignore());
            
            CreateMap<UpdatingSonarProcessDto, SonarProcess>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SearchTasks, map => map.Ignore());

            CreateMap<UpdatingSonarProcessWithLSonarTasksDto, SonarProcess>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Deleted, map => map.Ignore())
                .ForMember(d => d.SearchTasks, map => map.Ignore());
        }
    }
}
