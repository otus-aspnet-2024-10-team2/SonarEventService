using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.SearchGroup;

namespace Services.Abstractions;

/// <summary>
/// Интерфейс работы с группами поиска
/// </summary>
public interface ISearchGroupService
{
    /// <summary>
    /// Получить группу поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО группы поиска. </returns>
    Task<SearchGroupDto> GetByIdAsync(long id);

    /// <summary>
    /// Создать группу поиска.
    /// </summary>
    /// <param name="сreatingSearchGroupDto"> ДТО создаваемой группы поиска. </param>
    Task<long> CreateAsync(CreatingSearchGroupDto creatingSearchGroupDto);

    /// <summary>
    /// Изменить группу поиска.
    /// </summary>
    /// <param name="id"> Иентификатор. </param>
    /// <param name="updatingSearchGroupDto"> ДТО редактируемой группы поиска. </param>
    Task UpdateAsync(long id, UpdatingSearchGroupDto updatingSearchGroupDto);

    /// <summary>
    /// Удалить группу поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    Task DeleteAsync(long id);

    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="filterDto"> ДТО фильтра. </param>
    /// <returns> Список групп поиска. </returns>
    Task<ICollection<SearchGroupDto>> GetPagedAsync(SearchGroupFilterDto filterDto);
}


