﻿using System.Collections.Generic;
using WebApi.Models.SonarTask;

namespace WebApi.Models.SonarProcess
{
    /// <summary>
    /// Модель обновления процесса поиска с изменением состава задач.
    /// </summary>
    public class UpdatingSonarProcessWithSonarTasksModel
    {
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
        public IEnumerable<AttachingSonarTaskModel> SonarTasks { get; set; }
    }
}