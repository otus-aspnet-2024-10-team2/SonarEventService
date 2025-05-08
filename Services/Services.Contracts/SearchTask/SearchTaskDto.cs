namespace Services.Contracts.SonarTask
{
    /// <summary>
    /// ДТО задачи поиска.
    /// </summary>
    public class SearchTaskDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
    }
}