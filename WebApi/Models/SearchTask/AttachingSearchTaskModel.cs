using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApi.Models.SearchTask
{
    /// <summary>
    /// Модель прикладываемой задачи поиска.
    /// </summary>
    public class AttachingSearchTaskModel
    {
        /// <summary>
        /// Идентификатор мероприятия, к которому относится задача
        /// </summary>
        [Column("EventId")]
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

     }
}