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
    public class SonarTaskService : ISonarTaskService
    {
        private readonly IMapper _mapper;
        private readonly ISonarTaskRepository _sonarTaskRepository;
        private readonly IBusControl _busControl;

        public SonarTaskService(
            IMapper mapper,
            ISonarTaskRepository sonarTaskRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _sonarTaskRepository = sonarTaskRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить задачу поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО задачи поиска. </returns>
        public async Task<SonarTaskDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var sonarTask = await _sonarTaskRepository.GetAsync(id, cancellationToken);
            return _mapper.Map<SonarTask, SonarTaskDto>(sonarTask);
        }

        /// <summary>
        /// Создать задачу поиска.
        /// </summary>
        /// <param name="сreatingSonarTaskDto"> ДТО задачи. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingSonarTaskDto сreatingSonarTaskDto)
        {
            var lesson = _mapper.Map<CreatingSonarTaskDto, SonarTask>(сreatingSonarTaskDto);
            lesson.SonarProcessId = сreatingSonarTaskDto.SonarProcessId;
            var createdSonarTask = await _sonarTaskRepository.AddAsync(lesson);
            await _sonarTaskRepository.SaveChangesAsync();

            await _busControl.Publish(new MessageDto
            {
                Content = $"Sonar Task {createdSonarTask.Id} with subject {createdSonarTask.Subject} is added"
            });

            return createdSonarTask.Id;
        }

        /// <summary>
        /// Изменить задачу поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingSonarTaskDto"> ДТО задачи поиска. </param>
        public async Task UpdateAsync(int id, UpdatingSonarTaskDto updatingSonarTaskDto)
        {
            var sonarTask = await _sonarTaskRepository.GetAsync(id, CancellationToken.None);
            if (sonarTask == null)
            {
                throw new Exception($"Задача поиска с id = {id} не найден");
            }

            sonarTask.Subject = updatingSonarTaskDto.Subject;
            _sonarTaskRepository.Update(sonarTask);
            await _sonarTaskRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить задачу поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var sonarTask = await _sonarTaskRepository.GetAsync(id, CancellationToken.None);
            sonarTask.Deleted = true; 
            await _sonarTaskRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Получить постраничный список задач поиска.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница задач поиска. </returns>
        public async Task<ICollection<SonarTaskDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<SonarTask> entities = await _sonarTaskRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<SonarTask>, ICollection<SonarTaskDto>>(entities);
        }
    }
}