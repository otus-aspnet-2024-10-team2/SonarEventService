using System.Collections.Generic;
using WebApi.Models.SearchTask;

namespace WebApi.Models.SonarProcess
{
    /// <summary>
    /// Модель курса.
    /// </summary>
    public class SonarProcessModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Задачи поиска.
        /// </summary>
        public List<SearchTaskModel> SonarTasks { get; set; }
    }
}