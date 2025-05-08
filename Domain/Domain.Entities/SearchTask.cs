namespace Domain.Entities
{
    /// <summary>
    /// Задача.
    /// </summary>
    public class SearchTask : IEntity<long>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

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
        public long SonarProcessId { get; set; }

        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }

        //public DateTime DateTime { get; set; }
    }
}