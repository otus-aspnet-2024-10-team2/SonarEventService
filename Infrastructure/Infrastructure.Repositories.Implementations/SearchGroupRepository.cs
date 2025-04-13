using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.SearchGroup;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с группами поиска.
    /// </summary>
    public class SearchGroupRepository : Repository<SearchGroup, long>, ISearchGroupRepository
    {
        public SearchGroupRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по ID.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Группа поиска. </returns>
        public override async Task<SearchGroup> GetAsync(long id, CancellationToken cancellationToken)
        {
            var query = Context.Set<SearchGroup>().AsQueryable();
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список групп поиска. </returns>
        public async Task<List<SearchGroup>> GetPagedAsync(SearchGroupFilterDto filterDto)
        {
            var query = GetAll();

            if (filterDto.RequestId>0)
            {
                query = query.Where(c => c.RequestId == filterDto.RequestId);
            }
            if (filterDto.LeaderId > 0)
            {
                query = query.Where(c => c.LeaderId == filterDto.LeaderId);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return await query.ToListAsync();
        }
    }
}
