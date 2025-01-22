using AutoMapper;
using Services.Contracts.SonarProcess;
using WebApi.Models.SonarProcess;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности курса.
    /// </summary>
    public class SonarProcessMappingsProfile : Profile
    {
        public SonarProcessMappingsProfile()
        {
            CreateMap<SonarProcessDto, SonarProcessModel>();
            CreateMap<CreatingSonarProcessModel, CreatingSonarProcessDto>();
            CreateMap<UpdatingSonarProcessModel, UpdatingSonarProcessDto>();
            CreateMap<SonarProcessFilterModel, SonarProcessFilterDto>();
            CreateMap<UpdatingSonarProcessWithSonarTasksModel, UpdatingSonarProcessWithLSonarTasksDto>();
        }
    }
}
