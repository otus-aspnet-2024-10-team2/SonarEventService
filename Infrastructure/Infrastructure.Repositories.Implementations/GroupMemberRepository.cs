using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.GroupMember;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с группами поиска.
    /// </summary>
    public class GroupMemberRepository : Repository<GroupMember, long>, IGroupMemberRepository
    {
        public GroupMemberRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по ID.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Участник группы поиска. </returns>
        public override async Task<GroupMember> GetAsync(long id, CancellationToken cancellationToken)
        {
            var query = Context.Set<GroupMember>().AsQueryable();
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список групп/участников поиска. </returns>
        public async Task<List<GroupMember>> GetPagedAsync(GroupMemberFilterDto filterDto)
        {
            var query = GetAll();

            if (filterDto.GroupId > 0)
            {
                query = query.Where(c => c.GroupId == filterDto.GroupId);
            }
            if (filterDto.UserId > 0)
            {
                query = query.Where(c => c.UserId == filterDto.UserId);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return await query.ToListAsync();
        }
    }
}
