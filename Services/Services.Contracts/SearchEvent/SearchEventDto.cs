using System;
using System.Collections.Generic;
using Services.Contracts.SonarTask;

namespace Services.Contracts.SonarProcess
{
    /// <summary>
    /// DTO для представления мероприятия по поиску животного на уровне сервиса
    /// </summary>
    public class SearchEventDto
    {
        /// <summary>
        /// Уникальный идентификатор мероприятия
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор заявки, к которой относится это мероприятие
        /// </summary>
        public long RequestId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего мероприятие
        /// </summary>
        public long CreatedById { get; set; }

        /// <summary>
        /// Описание мероприятия
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Место проведения мероприятия
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
        /// Дата создания записи о мероприятии
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления записи о мероприятии
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Список задач, связанных с этим мероприятием
        /// </summary>
        public List<SearchTaskDto> Tasks { get; set; } = new List<SearchTaskDto>();
    }

}