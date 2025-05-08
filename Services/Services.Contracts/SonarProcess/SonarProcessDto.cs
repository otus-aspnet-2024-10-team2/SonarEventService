using System.Collections.Generic;
using Services.Contracts.SonarTask;

namespace Services.Contracts.SonarProcess
{
    /// <summary>
    /// ДТО процесса поиска.
    /// </summary>
    public class SonarProcessDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// Стоимость.
        ///// </summary>
        //public decimal Price { get; set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public List<SearchTaskDto> SearchTasks { get; set; }
    }
}