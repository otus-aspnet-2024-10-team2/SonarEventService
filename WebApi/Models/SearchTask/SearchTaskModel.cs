using System;

namespace WebApi.Models.SearchTask
{
    /// <summary>
    /// DTO-модель задачи, назначенной в рамках мероприятия
    /// </summary>
    public class SearchTaskModel
    {
        /// <summary>
        /// Уникальный идентификатор задачи
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор мероприятия, к которому относится задача
        /// </summary>
        public long EventId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому назначена задача
        /// </summary>
        public long AssignedToId { get; set; }

        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Статус задачи: назначена / в процессе / завершена / отменена
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления задачи
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

}