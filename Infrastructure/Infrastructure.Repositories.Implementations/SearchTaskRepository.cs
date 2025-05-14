using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с задачами поиска.
    /// </summary>
    public class SearchTaskRepository: Repository<SearchTask, long>, ISearchTaskRepository 
    {
        public SearchTaskRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по Id.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> Задача поиска. </returns>
        public override async Task<SearchTask> GetAsync(long id, CancellationToken cancellationToken)
        {
            //await Task.Delay(TimeSpan.FromSeconds(20)); // VDV: Причесать
            var query = _context.Set<SearchTask>().AsQueryable();
            query = query.Where(l => l.Id == id );
            var res = await query.SingleOrDefaultAsync();
            return res;
            //return await query.SingleOrDefaultAsync(cancellationToken);
        }
        
        /// <summary>
        /// Получить список задач поиска.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список задач поиска. </returns>
        public async Task<List<SearchTask>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();//.Where(l => !l.Deleted);
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
