using System.Collections.Generic;
using Services.Contracts.SonarTask;

namespace Services.Contracts.SonarProcess
{
    /// <summary>
    /// ДТО обновления процесса поиска с изменением состава задач.
    /// </summary>
    public class UpdatingSonarProcessWithLSonarTasksDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// Стоимость.
        ///// </summary>
        //public decimal Price { get; set; }

        /// <summary>
        /// Уроки
        /// </summary>
        public IEnumerable<AttachingSonarTasksDto> SonarTasks { get; set; }
    }
}