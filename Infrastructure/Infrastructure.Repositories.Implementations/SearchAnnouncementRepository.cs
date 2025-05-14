using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations;


/// <summary>
/// Репозиторий работы с объявлениями поиска.
/// </summary>
public class SearchAnnouncementRepository : Repository<SearchAnnouncement, long>, ISearchAnnouncementRepository
{
    public SearchAnnouncementRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Объявление поиска. </returns>
    public override async Task<SearchAnnouncement> GetAsync(long id, CancellationToken cancellationToken)
    {
        var query = _context.Set<SearchAnnouncement>().AsQueryable();
        query = query.Where(l => l.Id == id);
        var res = await query.SingleOrDefaultAsync();
        return res;
    }

    /// <summary>
    /// Получить список объявлений поиска.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список объявлений поиска. </returns>
    public async Task<List<SearchAnnouncement>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll();
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}
