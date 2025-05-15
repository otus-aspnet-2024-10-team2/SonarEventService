using AutoMapper;
using Services.Contracts.SearchAnnouncement;
using WebApi.Models.SearchAnnouncement;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности объявление.
    /// </summary>
    public class SearchAnnouncementMappingProfile : Profile
    {
        public SearchAnnouncementMappingProfile()
        {
            CreateMap<SearchAnnouncementDto, SearchAnnouncementModel>();
            CreateMap<CreatingSearchAnnouncementModel, CreatingSearchAnnouncementDto>();
            CreateMap<UpdatingSearchAnnouncementModel, UpdatingSearchAnnouncementDto>();
        }
    }
}
