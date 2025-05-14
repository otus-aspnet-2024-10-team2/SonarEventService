using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.SearchAnnouncement;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с объявлениями
    /// </summary>
    public interface ISearchAnnouncementService
    {
        /// <summary>
        /// Получить объявление. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО объявления. </returns>
        Task<SearchAnnouncementDto> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать объявление.
        /// </summary>
        /// <param name="creatingAnnouncementDto"> ДТО объявления. </param>
        /// <returns> Идентификатор. </returns>
        Task<long> CreateAsync(CreatingSearchAnnouncementDto creatingAnnouncementDto);

        /// <summary>
        /// Изменить объявление.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingAnnouncementDto"> ДТО объявления. </param>
        Task UpdateAsync(long id, UpdatingSearchAnnouncementDto updatingAnnouncementDto);

        /// <summary>
        /// Удалить объявление.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(long id);
        
        /// <summary>
        /// Получить список объявлений.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница объявлений. </returns>
        Task<ICollection<SearchAnnouncementDto>> GetPagedAsync(int page, int pageSize);
    }
}