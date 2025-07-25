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
    /// Репозиторий работы с мероприятиями поиска.
    /// </summary>
    public class SearchEventRepository: Repository<SearchEvent, long>, ISearchEventRepository
    {
        public SearchEventRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по ID.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> Процесс поиска. </returns>
        public override async Task<SearchEvent> GetAsync(long id, CancellationToken cancellationToken)
        {
            var query = _context.Set<SearchEvent>().AsQueryable();
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список процессов поиска. </returns>
        public async Task<List<SearchEvent>> GetPagedAsync(SearchEventFilterDto filterDto)
        {
            var query = GetAll();
            if (!string.IsNullOrWhiteSpace(filterDto.Status))
            {
                query = query.Where(c => c.Status == filterDto.Status); 
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return await query.ToListAsync();
        }
    }
}
