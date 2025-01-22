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
        /// Уроки.
        /// </summary>
        public List<SonarTaskDto> SonarTasks { get; set; }
    }
}