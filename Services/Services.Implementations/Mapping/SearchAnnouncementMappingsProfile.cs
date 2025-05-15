using AutoMapper;
using Domain.Entities;
using Services.Contracts.SearchAnnouncement;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности объявление.
    /// </summary>
    public class SearchAnnouncementMappingsProfile : Profile
    {
        public SearchAnnouncementMappingsProfile()
        {
            CreateMap<SearchAnnouncement, SearchAnnouncementDto>();

            CreateMap<CreatingSearchAnnouncementDto, SearchAnnouncement>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())                
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Animal, map => map.Ignore())
                .ForMember(d => d.Owner, map => map.Ignore())
                .ForMember(d => d.SearchRequests, map => map.Ignore())
                ;

            CreateMap<UpdatingSearchAnnouncementDto, SearchAnnouncement>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.Animal, map => map.Ignore())
                .ForMember(d => d.Owner, map => map.Ignore())
                .ForMember(d => d.SearchRequests, map => map.Ignore())
                ;
        }
    }
}
