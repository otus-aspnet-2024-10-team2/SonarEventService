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
            CreateMap<SearchTaskDto, SearchTaskModel>()
                //.ForMember(d => d.AssignedToId, map => map.MapFrom(m => m.AssignedTo))
                ;
            // VDV: Настривать
            //CreateMap<CreatingSearchTaskModel, CreatingSearchTaskDto>();
            //CreateMap<UpdatingSearchTaskModel, UpdatingSearchTaskDto>();
            //CreateMap<AttachingSearchTaskModel, AttachingSearchTasksDto>();
        }
    }
}
