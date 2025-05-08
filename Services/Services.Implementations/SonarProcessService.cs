using System;
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
    public class SonarProcessService : ISearchEventService
    {
        private readonly IMapper _mapper;
        private readonly ISonarProcessRepository _sonarProcessRepository;
        private readonly ISearchTaskRepository _sonarTaskRepository;
        private readonly IBusControl _busControl;
        private readonly IUnitOfWork _unitOfWork;

        public SonarProcessService(
            IMapper mapper,
            ISonarProcessRepository sonarProcessRepository,
            ISearchTaskRepository sonarTaskRepository,
            IUnitOfWork unitOfWork,
            IBusControl busControl)
        {
            _mapper = mapper;
            _sonarProcessRepository = sonarProcessRepository;
            _sonarTaskRepository = sonarTaskRepository;
            _busControl = busControl;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить процесс поиска животного
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО курса. </returns>
        public async Task<SearchEventDto> GetByIdAsync(long id)
        {
            var course = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<SearchEvent, SearchEventDto>(course);
        }

        /// <summary>
        /// Создать процесс поиска животного
        /// </summary>
        /// <param name="creatingSonarProcessDto"> ДТО создаваемого процесса. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<long> CreateAsync(CreatingSearchEventDto creatingSonarProcessDto)
        {
            var course = _mapper.Map<CreatingSearchEventDto, SearchEvent>(creatingSonarProcessDto);
            var createdSonarProcess = await _sonarProcessRepository.AddAsync(course);
            await _sonarProcessRepository.SaveChangesAsync();
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
        /// Для показа unit of work.
        /// </summary>
        /// <param name="updatingSonarProcessWithLSonarTasksDto"> ДТО редактируемого процесса. </param>
        /// <param name="id"> Id </param>
        public async Task UpdatingWithSonarTasksAsync(long id, UpdatingSearchEventWithSeacrchTasksDto updatingSonarProcessWithLSonarTasksDto)
        {
            //var course = await _unitOfWork.CourseRepository.GetAsync(id, CancellationToken.None);
            var sonarProcess = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            if (sonarProcess == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            sonarProcess.Name = updatingSonarProcessWithLSonarTasksDto.Name;
            //sonarProcess.Price = updatingSonarProcessWithLSonarTasksDto.Price;
            _sonarProcessRepository.Update(sonarProcess);
            await _sonarProcessRepository.SaveChangesAsync();
            //_unitOfWork.CourseRepository.Update(course);
            var sonarTasks = _mapper.Map<IEnumerable<AttachingSearchTasksDto>, IEnumerable<SearchTask>>(updatingSonarProcessWithLSonarTasksDto.SonarTasks);
            foreach (var lesson in sonarTasks)
            {
                lesson.SearchEventId = 100; //Не существует
                await _sonarTaskRepository.AddAsync(lesson);
                //await _unitOfWork.LessonRepository.AddAsync(lesson);
            }
            
            await _sonarTaskRepository.SaveChangesAsync();
            //await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Изменить процесс поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingCourseDto"> ДТО редактируемого процесса поиска. </param>
        public async Task UpdateAsync(long id, UpdatingSearchEventDto updatingCourseDto)
        {
            var sonarProcess = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            if (sonarProcess == null)
            {
                throw new Exception($"Процесс поиска с идентфикатором {id} не найден");
            }

            sonarProcess.Name = updatingCourseDto.Name;
            //sonarProcess.Price = updatingCourseDto.Price;
            _sonarProcessRepository.Update(sonarProcess);
            await _sonarProcessRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить процесс поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(long id)
        {
            var sonarProcess = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            sonarProcess.Deleted = true; 
            await _sonarProcessRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список поисков. </returns>
        public async Task<ICollection<SearchEventDto>> GetPagedAsync(SearchEventFilterDto filterDto)
        {
            ICollection<SearchEvent> entities = await _sonarProcessRepository.GetPagedAsync(filterDto);
            return _mapper.Map<ICollection<SearchEvent>, ICollection<SearchEventDto>>(entities);
        }
    }
}