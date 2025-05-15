using AutoMapper;
using Services.Contracts.Animal;
using WebApi.Models.Animal;

namespace WebApi.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности Животное.
    /// </summary>
    public class AnimalMappingProfile : Profile
    {
        public AnimalMappingProfile()
        {
            CreateMap<AnimalDto, AnimalModel>();
            CreateMap<CreatingAnimalModel, CreatingAnimalDto>();
            CreateMap<UpdatingAnimalModel, UpdatingAnimalDto>();
        }
    }
}
