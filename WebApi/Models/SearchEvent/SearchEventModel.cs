using Domain.Entities;
using System;
using System.Collections.Generic;
using WebApi.Models.SearchTask;

namespace WebApi.Models.SearchEvent
{
    /// <summary>
    /// DTO-модель для представления мероприятия по поиску животного (для передачи данных через API)
    /// </summary>
    public class SearchEventModel
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
        public List<SearchTaskModel> Tasks { get; set; } = new List<SearchTaskModel>();
    }

}