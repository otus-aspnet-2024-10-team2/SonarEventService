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
        public int Id { get; set; }

        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }
    }
}