﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Domain.Entities;
using MassTransit;
using Services.Contracts.SonarProcess;
using Services.Contracts.SonarTask;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с процессами поиска.
    /// </summary>
    public class SearchEventService : ISearchEventService
    {
        private readonly IMapper _mapper;
        private readonly ISearchEventRepository _searchEventRepository;
        private readonly ISearchTaskRepository _searchTaskRepository;
        private readonly IBusControl _busControl;
        private readonly IUnitOfWork _unitOfWork;

        public SearchEventService(
            IMapper mapper,
            ISearchEventRepository searchEventRepository,
            ISearchTaskRepository searchTaskRepository,
            IUnitOfWork unitOfWork,
            IBusControl busControl)
        {
            _mapper = mapper;
            _searchEventRepository = searchEventRepository;
            _searchTaskRepository = searchTaskRepository;
            _busControl = busControl;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить мероприятие поиска питомца
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns>ДТО меропирятия</returns>
        public async Task<SearchEventDto> GetByIdAsync(long id)
        {
            var searchEventDto = await _searchEventRepository.GetAsync(id, CancellationToken.None);
            var res = _mapper.Map<SearchEvent, SearchEventDto>(searchEventDto);
            return res;
        }

        /// <summary>
        /// Создать процесс поиска животного
        /// </summary>
        /// <param name="creatingSonarProcessDto"> ДТО создаваемого процесса. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<long> CreateAsync(CreatingSearchEventDto creatingSonarProcessDto)
        {
            var course = _mapper.Map<CreatingSearchEventDto, SearchEvent>(creatingSonarProcessDto);
            var createdSonarProcess = await _searchEventRepository.AddAsync(course);
            await _searchEventRepository.SaveChangesAsync();
            /*
            await _busControl.Publish(new MessageDto
            {
                Content = $"Course {createdCourse.Id} with name {createdCourse.Name} is added"
            });
            */
            return createdSonarProcess.Id;
        }
        
        /// <summary>
        /// Обновить процесс и состав задач.
        /// </summary>
        /// <param name="updatingSearchEventWithSeacrchTasksDto"> ДТО редактируемого мероприятия. </param>
        /// <param name="id"> Id </param>
        public async Task UpdatingWithSonarTasksAsync(long id, UpdatingSearchEventWithSeacrchTasksDto updatingSearchEventWithSeacrchTasksDto)
        {
            var searchEvent = await _searchEventRepository.GetAsync(id, CancellationToken.None);
            if (searchEvent == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            searchEvent.RequestId = updatingSearchEventWithSeacrchTasksDto.RequestId;
            searchEvent.CreatedById = updatingSearchEventWithSeacrchTasksDto.CreatedById;
            searchEvent.Description = updatingSearchEventWithSeacrchTasksDto.Description;
            searchEvent.Location = updatingSearchEventWithSeacrchTasksDto.Location;
            searchEvent.Status = updatingSearchEventWithSeacrchTasksDto.Status;
            searchEvent.StartTime = updatingSearchEventWithSeacrchTasksDto.StartTime;
            searchEvent.EndTime = updatingSearchEventWithSeacrchTasksDto.EndTime;

            _searchEventRepository.Update(searchEvent);
            await _searchEventRepository.SaveChangesAsync();
            var sonarTasks = _mapper.Map<IEnumerable<AttachingSearchTasksDto>, IEnumerable<SearchTask>>(updatingSearchEventWithSeacrchTasksDto.SearchTasks);
            foreach (var lesson in sonarTasks)
            {
                lesson.EventId = searchEvent.Id;
                await _searchTaskRepository.AddAsync(lesson);
            }
            
            await _searchTaskRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Изменить процесс поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого процесса поиска. </param>
        public async Task UpdateAsync(long id, UpdatingSearchEventDto updatingCourseDto)
        {
            var searchEvent = await _searchEventRepository.GetAsync(id, CancellationToken.None);
            if (searchEvent == null)
            {
                throw new Exception($"Мероприятие поиска с идентфикатором {id} не найден");
            }

            searchEvent.RequestId = updatingCourseDto.RequestId;
            searchEvent.CreatedById = updatingCourseDto.CreatedById;
            searchEvent.Description = updatingCourseDto.Description;
            searchEvent.Location = updatingCourseDto.Location;
            searchEvent.Status = updatingCourseDto.Status;
            searchEvent.StartTime = updatingCourseDto.StartTime;
            searchEvent.EndTime = updatingCourseDto.EndTime;

            _searchEventRepository.Update(searchEvent);
            await _searchEventRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить мероприятие поиска
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(long id)
        {
            var searchEvent = await _searchEventRepository.GetAsync(id, CancellationToken.None);
            var deleted = _searchEventRepository.Delete(id);
            if (!deleted)
            {
                throw new Exception($"Мероприятие поиска с идентфикатором {id} не удалена!");
            }
            await _searchEventRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список поисков. </returns>
        public async Task<ICollection<SearchEventDto>> GetPagedAsync(SearchEventFilterDto filterDto)
        {
            ICollection<SearchEvent> entities = await _searchEventRepository.GetPagedAsync(filterDto);
            return _mapper.Map<ICollection<SearchEvent>, ICollection<SearchEventDto>>(entities);
        }
    }
}