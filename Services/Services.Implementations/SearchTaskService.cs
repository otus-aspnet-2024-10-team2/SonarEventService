using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using CommonNamespace;
using Domain.Entities;
using MassTransit;
using Services.Contracts.SonarTask;

namespace Services.Implementations
{
    /// <summary>
    /// Сервис работы с задачами поиска.
    /// </summary>
    public class SearchTaskService : ISearchTaskService
    {
        private readonly IMapper _mapper;
        private readonly ISearchTaskRepository _searchTaskRepository;
        private readonly IBusControl _busControl;

        public SearchTaskService(
            IMapper mapper,
            ISearchTaskRepository searchTaskRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _searchTaskRepository = searchTaskRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить задачу поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО задачи поиска. </returns>
        public async Task<SearchTaskDto> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                var searchTask = await _searchTaskRepository.GetAsync(id, cancellationToken);
                return _mapper.Map<SearchTask, SearchTaskDto>(searchTask);
            }
            catch (Exception e) // VDV: Убрать
            {
                throw e;
            }
        }

        /// <summary>
        /// Создать задачу поиска.
        /// </summary>
        /// <param name="сreatingSearchTaskDto"> ДТО задачи. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<long> CreateAsync(CreatingSearchTaskDto сreatingSearchTaskDto)
        {
            var searchTask = _mapper.Map<CreatingSearchTaskDto, SearchTask>(сreatingSearchTaskDto);
            //searchTask.SearchEventId = сreatingSearchTaskDto.SonarProcessId; // VDV Заполнять
            var createdSearchTask = await _searchTaskRepository.AddAsync(searchTask);
            await _searchTaskRepository.SaveChangesAsync();
            // здесь как понял идет публикация сообщения ... надо изучать пока закоментировал, как понимаю отправляет сообщение
            //await _busControl.Publish(new MessageDto
            //{
            //    Content = $"Sonar Task {createdSonarTask.Id} with subject {createdSonarTask.Subject} is added"
            //});

            return createdSearchTask.Id;
        }

        /// <summary>
        /// Изменить задачу поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingSearchTaskDto"> ДТО задачи поиска. </param>
        public async Task UpdateAsync(long id, UpdatingSearchTaskDto updatingSearchTaskDto)
        {
            var searchTask = await _searchTaskRepository.GetAsync(id, CancellationToken.None);
            if (searchTask == null)
            {
                throw new Exception($"Задача поиска с id = {id} не найден");
            }

            //searchTask.Subject = updatingSearchTaskDto.Subject; // VDV: Заполнять
            _searchTaskRepository.Update(searchTask);
            await _searchTaskRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить задачу поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(long id)
        {
            var searchTask = await _searchTaskRepository.GetAsync(id, CancellationToken.None);
            //searchTask.Deleted = true;  // VDV: Удалить
            var deleted = _searchTaskRepository.Delete(id);
            if (!deleted)
            {
                throw new Exception($"Задача поиска с идентфикатором {id} не удалена!");
            }
            await _searchTaskRepository.SaveChangesAsync();

            // VDV: Удалить отладка
            //var searchGroup = await _searchGroupRepository.GetAsync(id, CancellationToken.None);
            //var deleted = _searchGroupRepository.Delete(id);
            //if (!deleted)
            //{
            //    throw new Exception($"Группа поиска с идентфикатором {id} не удалена!");
            //}
            //await _searchGroupRepository.SaveChangesAsync();

        }
        
        /// <summary>
        /// Получить постраничный список задач поиска.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница задач поиска. </returns>
        public async Task<ICollection<SearchTaskDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<SearchTask> entities = await _searchTaskRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<SearchTask>, ICollection<SearchTaskDto>>(entities);
        }
    }
}