using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts.SearchGroup;
using Services.Contracts.SonarProcess;

namespace Services.Repositories.Abstractions;

/// <summary>
/// Репозиторий работы с группами поиска
/// </summary>
public interface ISearchGroupRepository: IRepository<SearchGroup, long>
{
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="filterDto"> ДТО фильтра. </param>
    /// <returns> Список групп. </returns>
    Task<List<SearchGroup>> GetPagedAsync(SearchGroupFilterDto filterDto);
}
