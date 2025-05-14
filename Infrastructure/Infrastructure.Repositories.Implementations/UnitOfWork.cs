using System.Threading.Tasks;
using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

/// <summary>
/// UOW.
/// </summary>
public class UnitOfWork: IUnitOfWork
{
    private ISearchEventRepository _courseRepository;
    private ISearchTaskRepository _lessonRepository;
    private DatabaseContext _context;

    public ISearchEventRepository SearchEventRepository => _courseRepository;
    public ISearchTaskRepository SearchTaskRepository => _lessonRepository;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        _lessonRepository = new SearchTaskRepository(context);
        _courseRepository = new SearchEventRepository(context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}