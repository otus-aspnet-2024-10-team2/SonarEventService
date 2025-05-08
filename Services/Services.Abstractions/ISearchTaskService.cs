using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.SonarTask;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с уроками.
    /// </summary>
    public interface ISearchTaskService
    {
        /// <summary>
        /// Получить урок. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО урока. </returns>
        Task<SearchTaskDto> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать урок.
        /// </summary>
        /// <param name="creatingLessonDto"> ДТО урока. </param>
        /// <returns> Идентификатор. </returns>
        Task<long> CreateAsync(CreatingSearchTaskDto creatingLessonDto);

        /// <summary>
        /// Изменить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingLessonDto"> ДТО урока. </param>
        Task UpdateAsync(long id, UpdatingSearchTaskDto updatingLessonDto);

        /// <summary>
        /// Удалить урок.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(long id);
        
        /// <summary>
        /// Получить список уроков.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница уроков. </returns>
        Task<ICollection<SearchTaskDto>> GetPagedAsync(int page, int pageSize);
    }
}