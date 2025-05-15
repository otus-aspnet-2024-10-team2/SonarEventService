using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.SearchRequest;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с заявками на поиск
    /// </summary>
    public interface ISearchRequestService
    {
        /// <summary>
        /// Получить заявку. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО заявки. </returns>
        Task<SearchRequestDto> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать заявку.
        /// </summary>
        /// <param name="creatingRequestDto"> ДТО заявки. </param>
        /// <returns> Идентификатор. </returns>
        Task<long> CreateAsync(CreatingSearchRequestDto creatingRequestDto);

        /// <summary>
        /// Изменить заявку.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingRequestDto"> ДТО заявки. </param>
        Task UpdateAsync(long id, UpdatingSearchRequestDto updatingRequestDto);

        /// <summary>
        /// Удалить заявку.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(long id);
        
        /// <summary>
        /// Получить список заявок.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница заявок. </returns>
        Task<ICollection<SearchRequestDto>> GetPagedAsync(int page, int pageSize);
    }
}