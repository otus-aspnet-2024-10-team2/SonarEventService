using AutoMapper;
using Services.Contracts.SearchRequest;
using WebApi.Models.SearchRequest;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности заявка на поиск.
    /// </summary>
    public class SearchRequestMappingProfile : Profile
    {
        public SearchRequestMappingProfile()
        {
            CreateMap<SearchRequestDto, SearchRequestModel>();
            CreateMap<CreatingSearchRequestModel, CreatingSearchRequestDto>();
            CreateMap<UpdatingSearchRequestModel, UpdatingSearchRequestDto>();
        }
    }
}
