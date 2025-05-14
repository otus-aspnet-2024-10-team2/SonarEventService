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
/// Репозиторий работы с животными.
/// </summary>
public class AnimalRepository : Repository<Animal, long>, IAnimalRepository
{
    public AnimalRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Животное. </returns>
    public override async Task<Animal> GetAsync(long id, CancellationToken cancellationToken)
    {
        var query = _context.Set<Animal>().AsQueryable();
        query = query.Where(l => l.Id == id);
        var res = await query.SingleOrDefaultAsync();
        return res;
    }

    /// <summary>
    /// Получить список животных.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список животных. </returns>
    public async Task<List<Animal>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll();
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}
