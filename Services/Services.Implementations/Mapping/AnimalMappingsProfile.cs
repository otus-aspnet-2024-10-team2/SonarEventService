using AutoMapper;
using Domain.Entities;
using Services.Contracts.Animal;

namespace Services.Implementations.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности животное.
    /// </summary>
    public class AnimalMappingsProfile : Profile
    {
        public AnimalMappingsProfile()
        {
            CreateMap<Animal, AnimalDto>();

            CreateMap<CreatingAnimalDto, Animal>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())                
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.SearchAnnouncements, map => map.Ignore())
                .ForMember(d => d.Owner, map => map.Ignore())
                ;

            CreateMap<UpdatingAnimalDto, Animal>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreatedAt, map => map.Ignore())
                .ForMember(d => d.UpdatedAt, map => map.Ignore())
                .ForMember(d => d.SearchAnnouncements, map => map.Ignore())
                .ForMember(d => d.Owner, map => map.Ignore())
                ;
        }
    }
}
