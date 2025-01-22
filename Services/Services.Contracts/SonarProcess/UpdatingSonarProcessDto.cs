namespace Services.Contracts.SonarProcess
{
    /// <summary>
    /// ДТО редактируемого процесса поиска.
    /// </summary>
    public class UpdatingSonarProcessDto
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