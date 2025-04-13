using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts.GroupMember;

namespace Services.Repositories.Abstractions;

/// <summary>
/// Репозиторий работы с участниками групп поиска
/// </summary>
public interface IGroupMemberRepository : IRepository<GroupMember, long>
{
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="filterDto"> ДТО фильтра. </param>
    /// <returns> Список участников групп поиска. </returns>
    Task<List<GroupMember>> GetPagedAsync(GroupMemberFilterDto filterDto);
}
