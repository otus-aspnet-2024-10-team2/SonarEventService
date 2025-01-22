using AutoMapper;
using Services.Contracts.SonarTask;
using WebApi.Models.SonarTask;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности процесска поиска.
    /// </summary>
    public class SonarTaskMappingsProfile : Profile
    {
        public SonarTaskMappingsProfile()
        {
            CreateMap<SonarTaskDto, SonarTaskModel>();
            CreateMap<CreatingSonarTaskModel, CreatingSonarTaskDto>();
            CreateMap<UpdatingSonarTaskModel, UpdatingSonarTaskDto>();
            CreateMap<AttachingSonarTaskModel, AttachingSonarTasksDto>();
        }
    }
}
