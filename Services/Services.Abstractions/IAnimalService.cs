using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.Animal;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с животными
    /// </summary>
    public interface IAnimalService
    {
        /// <summary>
        /// Получить информацию о животном. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО информация о животном. </returns>
        Task<AnimalDto> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать информацию о животном.
        /// </summary>
        /// <param name="creatingAnimalDto"> ДТО информации о животном. </param>
        /// <returns> Идентификатор. </returns>
        Task<long> CreateAsync(CreatingAnimalDto creatingAnimalDto);

        /// <summary>
        /// Изменить информацию о животном.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingAnimalDto"> ДТО информации о животном. </param>
        Task UpdateAsync(long id, UpdatingAnimalDto updatingAnimalDto);

        /// <summary>
        /// Удалить информацию о животном.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(long id);

        /// <summary>
        /// Получить список животных
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница животных. </returns>
        Task<ICollection<AnimalDto>> GetPagedAsync(int page, int pageSize);
    }
}