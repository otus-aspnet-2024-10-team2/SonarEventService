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
    public class SonarProcessService : ISonarProcessService
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
        public async Task<SonarProcessDto> GetByIdAsync(int id)
        {
            var course = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<SonarProcess, SonarProcessDto>(course);
        }

        /// <summary>
        /// Создать процесс поиска животного
        /// </summary>
        /// <param name="creatingSonarProcessDto"> ДТО создаваемого процесса. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingSonarProcessDto creatingSonarProcessDto)
        {
            var course = _mapper.Map<CreatingSonarProcessDto, SonarProcess>(creatingSonarProcessDto);
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
        public async Task UpdatingWithSonarTasksAsync(int id, UpdatingSonarProcessWithLSonarTasksDto updatingSonarProcessWithLSonarTasksDto)
        {
            //var course = await _unitOfWork.CourseRepository.GetAsync(id, CancellationToken.None);
            var sonarProcess = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            if (sonarProcess == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            sonarProcess.Name = updatingSonarProcessWithLSonarTasksDto.Name;
            sonarProcess.Price = updatingSonarProcessWithLSonarTasksDto.Price;
            _sonarProcessRepository.Update(sonarProcess);
            await _sonarProcessRepository.SaveChangesAsync();
            //_unitOfWork.CourseRepository.Update(course);
            var sonarTasks = _mapper.Map<IEnumerable<AttachingSonarTasksDto>, IEnumerable<SearchTask>>(updatingSonarProcessWithLSonarTasksDto.SonarTasks);
            foreach (var lesson in sonarTasks)
            {
                lesson.SonarProcessId = 100; //Не существует
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
        public async Task UpdateAsync(int id, UpdatingSonarProcessDto updatingCourseDto)
        {
            var sonarProcess = await _sonarProcessRepository.GetAsync(id, CancellationToken.None);
            if (sonarProcess == null)
            {
                throw new Exception($"Процесс поиска с идентфикатором {id} не найден");
            }

            sonarProcess.Name = updatingCourseDto.Name;
            sonarProcess.Price = updatingCourseDto.Price;
            _sonarProcessRepository.Update(sonarProcess);
            await _sonarProcessRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить процесс поиска.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
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
        public async Task<ICollection<SonarProcessDto>> GetPagedAsync(SonarProcessFilterDto filterDto)
        {
            ICollection<SonarProcess> entities = await _sonarProcessRepository.GetPagedAsync(filterDto);
            return _mapper.Map<ICollection<SonarProcess>, ICollection<SonarProcessDto>>(entities);
        }
    }
}