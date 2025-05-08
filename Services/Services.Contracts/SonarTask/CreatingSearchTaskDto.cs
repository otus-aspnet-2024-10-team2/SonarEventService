namespace Services.Contracts.SonarTask
{
    /// <summary>
    /// ДТО задачи поиска.
    /// </summary>
    public class CreatingSearchTaskDto
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