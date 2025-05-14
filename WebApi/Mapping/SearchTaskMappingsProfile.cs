using AutoMapper;
using Services.Contracts.SonarTask;
using WebApi.Models.SearchTask;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности процесска поиска.
    /// </summary>
    public class SearchTaskMappingsProfile : Profile
    {
        public SearchTaskMappingsProfile()
        {
            CreateMap<SearchTaskDto, SearchTaskModel>();
            CreateMap<CreatingSearchTaskModel, CreatingSearchTaskDto>();
            CreateMap<UpdatingSearchTaskModel, UpdatingSearchTaskDto>();
            CreateMap<AttachingSearchTaskModel, AttachingSearchTasksDto>();
        }
    }
}
