using System;

namespace Domain.Entities
{
    /// <summary>
    /// Задача.
    /// </summary>
    public class SonarTask: IEntity<int>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// процесс поиска.
        /// </summary>
        public virtual SonarProcess SonarProcess { get; set; }
        
        /// <summary>
        /// Id процесса поиска.
        /// </summary>
        public int SonarProcessId { get; set; }
        
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }
        
        //public DateTime DateTime { get; set; }
    }
}