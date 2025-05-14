using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{


    /// <summary>
    /// Сущность задачи по поиску животного
    /// </summary>
    public class SearchTask : IEntity<long>
    {
        /// <summary>
        /// Уникальный идентификатор задачи
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор мероприятия, к которому относится задача
        /// </summary>
        //[Column("EventId")]
        public long EventId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому назначена задача
        /// </summary>
        //[Column("AssignedTo")]
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

        // Навигационные свойства

        /// <summary>
        /// Мероприятие, к которому относится задача
        /// </summary>
        public virtual SearchEvent Event { get; set; }

        /// <summary>
        /// Пользователь, которому назначена задача
        /// </summary>
        public virtual User AssignedTo { get; set; }
    }
}