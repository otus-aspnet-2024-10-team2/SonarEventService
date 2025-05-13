using System;
using System.Collections.Generic;

namespace Domain.Entities
{


    /// <summary>
    /// Сущность мероприятия по поиску животного (для хранения в БД)
    /// </summary>
    public class SearchEvent : IEntity<long>
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
        public long CreatedBy { get; set; }

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

        // Навигационные свойства

        /// <summary>
        /// Заявка, к которой относится это мероприятие
        /// </summary>
        public virtual SearchRequest Request { get; set; }

        /// <summary>
        /// Пользователь, создавший мероприятие
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// Список задач, связанных с этим мероприятием
        /// </summary>
        public virtual List<SearchTask> Tasks { get; set; } = new List<SearchTask>();
    }



    ///// <summary>
    ///// Мероприятие поиска животного
    ///// </summary>
    //public class SearchEvent: IEntity<long>
    //{
    //    /// <summary>
    //    /// Идентификатор
    //    /// </summary>
    //    public long Id { get; set; }

    //    /// <summary>
    //    /// Наименование мероприятия
    //    /// </summary>
    //    public string Name { get; set; }

    //    ///// <summary>
    //    ///// Стоимость.
    //    ///// </summary>
    //    //public decimal Price { get; set; }

    //    /// <summary>
    //    /// Задачи поиска 
    //    /// </summary>
    //    public virtual List<SearchTask> SearchTasks { get; set; }

    //    /// <summary>
    //    /// Удалено
    //    /// </summary>
    //    public bool Deleted { get; set; }
    //}
}