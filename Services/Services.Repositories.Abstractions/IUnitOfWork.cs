using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// UOW.
    /// </summary>
    public interface IUnitOfWork
    {
        ISearchTaskRepository SearchTaskRepository { get; }

        ISearchEventRepository SearchEventRepository { get; }

        Task SaveChangesAsync();
    }
}
