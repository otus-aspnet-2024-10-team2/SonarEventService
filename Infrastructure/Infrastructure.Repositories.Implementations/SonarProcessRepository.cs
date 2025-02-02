﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.SonarProcess;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с процессами.
    /// </summary>
    public class SonarProcessRepository: Repository<SonarProcess, int>, ISonarProcessRepository
    {
        public SonarProcessRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по ID.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Процесс поиска. </returns>
        public override async Task<SonarProcess> GetAsync(int id, CancellationToken cancellationToken)
        {
            var query = Context.Set<SonarProcess>().AsQueryable();
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список процессов поиска. </returns>
        public async Task<List<SonarProcess>> GetPagedAsync(SonarProcessFilterDto filterDto)
        {
            var query = GetAll()
                //.ToList().AsQueryable()
                .Where(c => !c.Deleted);
                //.Include(c => c.Lessons).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(c => c.Name == filterDto.Name);
            }
            
            if (filterDto.Price.HasValue && filterDto.Price != 0)
            {
                query = query.Where(c => c.Price == filterDto.Price);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return await query.ToListAsync();
        }
    }
}
