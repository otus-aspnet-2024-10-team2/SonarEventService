using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions;

/// <summary>
/// Репозиторий работы с животными
/// </summary>
public interface IAnimalRepository : IRepository<Animal, long>
{
    /// <summary>
    /// Получить список животных
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список животных. </returns>
    Task<List<Animal>> GetPagedAsync(int page, int itemsPerPage);
}
