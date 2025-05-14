using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Contracts.SonarTask
{
    /// <summary>
    /// ДТО задачи поиска.
    /// </summary>
    public class CreatingSearchTaskDto
    {
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
    }
}