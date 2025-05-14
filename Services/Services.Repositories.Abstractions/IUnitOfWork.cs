using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// UOW.
    /// </summary>
    public interface IUnitOfWork
    {
        ISearchTaskRepository LessonRepository { get; }

        ISearchEventRepository CourseRepository { get; }

        Task SaveChangesAsync();
    }
}
