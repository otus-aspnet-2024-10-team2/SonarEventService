using System.Threading.Tasks;
using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

/// <summary>
/// UOW.
/// </summary>
public class UnitOfWork: IUnitOfWork
{
    private ISonarProcessRepository _courseRepository;
    private ISonarTaskRepository _lessonRepository;
    private DatabaseContext _context;

    public ISonarProcessRepository CourseRepository => _courseRepository;
    public ISonarTaskRepository LessonRepository => _lessonRepository;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        _lessonRepository = new SonarTaskRepository(context);
        _courseRepository = new SonarProcessRepository(context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}