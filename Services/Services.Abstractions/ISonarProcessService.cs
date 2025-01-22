using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.SonarProcess;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с процессами поиска.
    /// </summary>
    public interface ISonarProcessService
    {
        /// <summary>
        /// Получить процесс поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО процесса поиска. </returns>
        Task<SonarProcessDto> GetByIdAsync(int id);

        /// <summary>
        /// Создать процесс поиска.
        /// </summary>
        /// <param name="сreatingSonarProcessDto"> ДТО создаваемого процесса поиска. </param>
        Task<int> CreateAsync(CreatingSonarProcessDto сreatingSonarProcessDto);

        /// <summary>
        /// Обновить процесс поиска и состав задач.
        /// Для показа unit of work.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="updatingSonarProcessWithLSonarTasksDto"></param>
        Task UpdatingWithSonarTasksAsync(int id, UpdatingSonarProcessWithLSonarTasksDto updatingSonarProcessWithLSonarTasksDto);        

        /// <summary>
        /// Изменить процесс поиска.
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingSonarProcessDto"> ДТО редактируемого процесса поиска. </param>
        Task UpdateAsync(int id, UpdatingSonarProcessDto updatingSonarProcessDto);

        /// <summary>
        /// Удалить процесс поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(int id);
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список процессов поиска. </returns>
        Task<ICollection<SonarProcessDto>> GetPagedAsync(SonarProcessFilterDto filterDto);
    }
}