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

                            // VDV: Настривать
                            //CreateMap<CreatingSearchTaskDto, SearchTask>()
                            //    // VDV пока все игнорирую просто считать
                            //    .ForMember(d => d.Id, map => map.Ignore())
                            //    .ForMember(d => d.EventId, map => map.Ignore())
                            //    .ForMember(d => d.Status, map => map.Ignore())
                            //    .ForMember(d => d.SearchEvent, map => map.Ignore())
                            //    .ForMember(d => d.AssignedToUser, map => map.Ignore())
                            //    .ForMember(d => d.AssignedToUser, map => map.Ignore())
                            //    .ForMember(d => d.CreatedAt, map => map.Ignore())
                            //    .ForMember(d => d.UpdatedAt, map => map.Ignore())

                            //    //.ForMember(d => d.Deleted, map => map.Ignore())
                            //    //.ForMember(d => d.SearchEvent, map => map.Ignore())
                            //    //.ForMember(d => d.EventId, map => map.Ignore()) // VDV: Вопрос почему тут игнорируем 
                            //    //.ForMember(d => d.SearchEventId, map => map.Ignore())
                            //    //.ForMember(d => d.DateTime, map => map.Ignore())
                            //    //.ForMember(d => d.Description, map => map.MapFrom(m=>m.Subject))
                            //    ;
                            //// VDV: Настривать
                            //CreateMap<UpdatingSearchTaskDto, SearchTask>()
                            //    .ForMember(d => d.Id, map => map.Ignore())
                            //    .ForMember(d => d.EventId, map => map.Ignore())
                            //    .ForMember(d => d.Status, map => map.Ignore())
                            //    .ForMember(d => d.SearchEvent, map => map.Ignore())
                            //    .ForMember(d => d.AssignedToUser, map => map.Ignore())
                            //    .ForMember(d => d.AssignedToUser, map => map.Ignore())
                            //    .ForMember(d => d.CreatedAt, map => map.Ignore())
                            //    .ForMember(d => d.UpdatedAt, map => map.Ignore())
                            //    //---
                            //    //.ForMember(d => d.Id, map => map.Ignore())
                            //    //.ForMember(d => d.Deleted, map => map.Ignore())
                            //    //.ForMember(d => d.SearchEvent, map => map.Ignore())
                            //    //.ForMember(d => d.SearchEventId, map => map.Ignore())
                            //    //.ForMember(d => d.DateTime, map => map.Ignore())
                            //    //.ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                            //    ;
                            //// VDV: Настривать
                            //CreateMap<AttachingSearchTasksDto, SearchTask>()
                            //    .ForMember(d => d.Id, map => map.Ignore())
                            //    .ForMember(d => d.EventId, map => map.Ignore())
                            //    .ForMember(d => d.Status, map => map.Ignore())
                            //    .ForMember(d => d.SearchEvent, map => map.Ignore())
                            //    .ForMember(d => d.AssignedToUser, map => map.Ignore())
                            //    .ForMember(d => d.AssignedToUser, map => map.Ignore())
                            //    .ForMember(d => d.CreatedAt, map => map.Ignore())
                            //    .ForMember(d => d.UpdatedAt, map => map.Ignore())

                            //    //.ForMember(d => d.Id, map => map.Ignore())
                            //    //.ForMember(d => d.Deleted, map => map.Ignore())
                            //    //.ForMember(d => d.SearchEvent, map => map.Ignore())
                            //    //.ForMember(d => d.SearchEventId, map => map.Ignore())
                            //    //.ForMember(d => d.DateTime, map => map.Ignore())
                            //    //.ForMember(d => d.Subject, map => map.MapFrom(m=>m.Subject))
                            //    ;
        }
    }
}
