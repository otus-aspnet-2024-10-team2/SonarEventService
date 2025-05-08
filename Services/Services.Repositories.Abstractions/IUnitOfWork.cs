using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// UOW.
    /// </summary>
    public interface IUnitOfWork
    {
        ISearchTaskRepository LessonRepository { get; }

        ISonarProcessRepository CourseRepository { get; }

        Task SaveChangesAsync();
    }
}
