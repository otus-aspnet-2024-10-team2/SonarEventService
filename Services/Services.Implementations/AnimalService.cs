using AutoMapper;
using Domain.Entities;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.Animal;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Сервис работы с животными
    /// </summary>
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        private readonly IBusControl _busControl;

        public AnimalService(
            IMapper mapper,
            IAnimalRepository animalRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить информацию о животном.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО информации о животном. </returns>
        public async Task<AnimalDto> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var animal = await _animalRepository.GetAsync(id, cancellationToken);
            return _mapper.Map<Animal, AnimalDto>(animal);
        }

        /// <summary>
        /// Создать информацию о животном.
        /// </summary>
        /// <param name="сreatingAnimalDto"> ДТО информации о животном. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<long> CreateAsync(CreatingAnimalDto сreatingAnimalDto)
        {
            var animal = _mapper.Map<CreatingAnimalDto, Animal>(сreatingAnimalDto);
            var createdAnimal = await _animalRepository.AddAsync(animal);
            await _animalRepository.SaveChangesAsync();
            return createdAnimal.Id;
        }

        /// <summary>
        /// Изменить информацию о животном.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingAnimalDto"> ДТО информации о животном. </param>
        public async Task UpdateAsync(long id, UpdatingAnimalDto updatingAnimalDto)
        {
            var animal = await _animalRepository.GetAsync(id, CancellationToken.None);
            if (animal == null)
            {
                throw new Exception($"Животное с id = {id} не найден");
            }

            animal.Name = updatingAnimalDto.Name;
            animal.Species = updatingAnimalDto.Species;
            animal.Breed = updatingAnimalDto.Breed;
            animal.Color = updatingAnimalDto.Color;
            animal.ChipNumber = updatingAnimalDto.ChipNumber;
            animal.OwnerId = updatingAnimalDto.OwnerId;
            animal.LastSeenLocation = updatingAnimalDto.LastSeenLocation;
            animal.Description = updatingAnimalDto.Description;
            animal.PhotoUrl = updatingAnimalDto.PhotoUrl;
            animal.UpdatedAt = updatingAnimalDto.UpdatedAt;

            _animalRepository.Update(animal);
            await _animalRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить информацию о животном.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(long id)
        {
            var animal = await _animalRepository.GetAsync(id, CancellationToken.None);
            var deleted = _animalRepository.Delete(id);
            if (!deleted)
            {
                throw new Exception($"Животное с идентфикатором {id} не удален!");
            }
            await _animalRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Получить постраничный список животных.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница животных. </returns>
        public async Task<ICollection<AnimalDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Animal> entities = await _animalRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Animal>, ICollection<AnimalDto>>(entities);
        }
    }
}