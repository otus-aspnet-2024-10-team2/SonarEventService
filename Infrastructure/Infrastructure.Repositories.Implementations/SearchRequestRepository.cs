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
/// Репозиторий работы с заявками на поиск.
/// </summary>
public class SearchRequestRepository : Repository<SearchRequest, long>, ISearchRequestRepository
{
    public SearchRequestRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Заявка на поиск. </returns>
    public override async Task<SearchRequest> GetAsync(long id, CancellationToken cancellationToken)
    {
        var query = _context.Set<SearchRequest>().AsQueryable();
        query = query.Where(l => l.Id == id);
        var res = await query.SingleOrDefaultAsync();
        return res;
    }

    /// <summary>
    /// Получить список заявок на поиск.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список заявок. </returns>
    public async Task<List<SearchRequest>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll();
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}
