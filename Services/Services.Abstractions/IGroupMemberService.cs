using Services.Contracts.GroupMember;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions;

/// <summary>
/// Интерфейс работы с участниками группы поиска
/// </summary>
public interface IGroupMemberService
{
    /// <summary>
    /// Получить участника группы поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО участника группы поиска. </returns>
    Task<GroupMemberDto> GetByIdAsync(long id);

    /// <summary>
    /// Создать участника группы поиска.
    /// </summary>
    /// <param name="сreatingGroupMemberDto"> ДТО создаваемого участника группы поиска. </param>
    Task<long> CreateAsync(CreatingGroupMemberDto creatingGroupMemberDto);

    /// <summary>
    /// Изменить участника группв поиска.
    /// </summary>
    /// <param name="id"> Иентификатор. </param>
    /// <param name="updatingGroupMemberDto"> ДТО редактируемого участника группы поиска. </param>
    Task UpdateAsync(long id, UpdatingGroupMemberDto updatingGroupMemberDto);

    /// <summary>
    /// Удалить участника группы поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    Task DeleteAsync(long id);

    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="filterDto"> ДТО фильтра. </param>
    /// <returns> Список участников. </returns>
    Task<ICollection<GroupMemberDto>> GetPagedAsync(GroupMemberFilterDto filterDto);
}
