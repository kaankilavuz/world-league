using System.Threading;
using System.Threading.Tasks;
using WorldLeague.SharedKernel.Entities;

namespace WorldLeague.SharedKernel.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
