using WorldLeague.SharedKernel.Entities;
using WorldLeague.SharedKernel.Repositories;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL.Repositories
{
    public class EfCoreRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        protected WorldLeagueDbContext Context { get; }

        public EfCoreRepositoryBase(WorldLeagueDbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var createdEntity = await Context.AddAsync(entity, cancellationToken);
            return createdEntity.Entity;
        }
    }
}
