using System;
using System.Collections.Generic;
using Services.Contracts.SonarTask;

namespace Services.Contracts.SonarProcess
{
    /// <summary>
    /// ДТО обновления процесса поиска с изменением состава задач.
    /// </summary>
    public class UpdatingSearchEventWithSeacrchTasksDto
    {
        /// <summary>
        /// Идентификатор заявки, к которой относится это мероприятие
        /// </summary>
        public long RequestId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего мероприятие
        /// </summary>
        public long CreatedById { get; set; }

        /// <summary>
        /// Описание мероприятия (1024 знака)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Место проведения мероприятия (500 знаков)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Статус мероприятия: планируется / выполняется / завершено / остановлено
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Дата и время начала мероприятия
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Дата и время окончания мероприятия
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Уроки
        /// </summary>
        public IEnumerable<AttachingSearchTasksDto> SearchTasks { get; set; }
    }
}