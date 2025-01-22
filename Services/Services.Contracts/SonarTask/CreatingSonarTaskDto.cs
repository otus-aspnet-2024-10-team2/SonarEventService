namespace Services.Contracts.SonarTask
{
    /// <summary>
    /// ДТО задачи поиска.
    /// </summary>
    public class CreatingSonarTaskDto
    {
        /// <summary>
        /// Идентификатор процесса поиска.
        /// </summary>
        public int SonarProcessId { get; set; }

        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
    }
}