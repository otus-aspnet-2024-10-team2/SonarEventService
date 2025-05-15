using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions;

/// <summary>
/// Репозиторий работы с заявками на поиск
/// </summary>
public interface ISearchRequestRepository : IRepository<SearchRequest, long>
{
    /// <summary>
    /// Получить список заявок
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список заявок. </returns>
    Task<List<SearchRequest>> GetPagedAsync(int page, int itemsPerPage);
}
