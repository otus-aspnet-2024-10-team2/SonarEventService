using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Мероприятие поиска животного
    /// </summary>
    public class SearchEvent: IEntity<long>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование мероприятия
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// Стоимость.
        ///// </summary>
        //public decimal Price { get; set; }

        /// <summary>
        /// Задачи поиска 
        /// </summary>
        public virtual List<SearchTask> SearchTasks { get; set; }
        
        /// <summary>
        /// Удалено
        /// </summary>
        public bool Deleted { get; set; }
    }
}