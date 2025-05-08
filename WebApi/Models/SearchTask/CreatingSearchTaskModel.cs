namespace WebApi.Models.SearchTask
{
    public class CreatingSearchTaskModel
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