using AutoMapper;
using Domain.Entities;
using Services.Contracts.SearchRequest;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности заявка на поиск.
    /// </summary>
    public class SearchRequestMappingsProfile : Profile
    {
        public SearchRequestMappingsProfile()
        {
            CreateMap<SearchRequest, SearchRequestDto>();

            CreateMap<CreatingSearchRequestDto, SearchRequest>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Announcement, map => map.Ignore())
                .ForMember(d => d.Coordinator, map => map.Ignore())
                .ForMember(d => d.Groups, map => map.Ignore())
                .ForMember(d => d.Events, map => map.Ignore())
                ;

            CreateMap<UpdatingSearchRequestDto, SearchRequest>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Announcement, map => map.Ignore())
                .ForMember(d => d.Coordinator, map => map.Ignore())
                .ForMember(d => d.Groups, map => map.Ignore())
                .ForMember(d => d.Events, map => map.Ignore())
                ;
        }
    }
}
