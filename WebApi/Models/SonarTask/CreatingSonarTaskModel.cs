namespace WebApi.Models.SonarTask
{
    public class CreatingSonarTaskModel
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