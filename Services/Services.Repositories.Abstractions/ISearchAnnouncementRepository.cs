using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions;

/// <summary>
/// Репозиторий работы с объявлениями
/// </summary>
public interface ISearchAnnouncementRepository : IRepository<SearchAnnouncement, long>
{
    /// <summary>
    /// Получить список обЪявлений
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список объявлений. </returns>
    Task<List<SearchAnnouncement>> GetPagedAsync(int page, int itemsPerPage);
}
