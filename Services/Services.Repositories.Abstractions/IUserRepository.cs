using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions;

/// <summary>
/// Репозиторий работы с пользователями
/// </summary>
public interface IUserRepository : IRepository<User, long>
{
    /// <summary>
    /// Получить список пользователей
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список пользователей. </returns>
    Task<List<User>> GetPagedAsync(int page, int itemsPerPage);
}
