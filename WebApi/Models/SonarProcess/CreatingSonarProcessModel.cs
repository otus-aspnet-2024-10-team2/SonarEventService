﻿namespace WebApi.Models.SonarProcess
{
    /// <summary>
    /// Модель создаваемого процесса поиска.
    /// </summary>
    public class CreatingSonarProcessModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }
    }
}