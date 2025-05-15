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
/// Репозиторий работы с пользователями.
/// </summary>
public class UserRepository : Repository<User, long>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Пользователь. </returns>
    public override async Task<User> GetAsync(long id, CancellationToken cancellationToken)
    {
        var query = _context.Set<User>().AsQueryable();
        query = query.Where(l => l.Id == id);
        var res = await query.SingleOrDefaultAsync();
        return res;
    }

    /// <summary>
    /// Получить список пользователей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список пользователей. </returns>
    public async Task<List<User>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll();
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}
