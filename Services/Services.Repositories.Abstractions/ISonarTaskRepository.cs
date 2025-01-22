using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с уроками.
    /// </summary>
    public interface ISonarTaskRepository: IRepository<SonarTask, int>
    {
        /// <summary>
        /// Получить список задач поиска.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список задач. </returns>
        Task<List<SonarTask>> GetPagedAsync(int page, int itemsPerPage);
    }
}
