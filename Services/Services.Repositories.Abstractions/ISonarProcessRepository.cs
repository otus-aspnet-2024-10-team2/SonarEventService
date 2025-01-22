using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts.SonarProcess;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с процессами поиска
    /// </summary>
    public interface ISonarProcessRepository: IRepository<SonarProcess, int>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список курсов. </returns>
        Task<List<SonarProcess>> GetPagedAsync(SonarProcessFilterDto filterDto);
    }
}
