using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using WorldLeague.SharedKernel.Uow;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private WorldLeagueDbContext Context { get; }

        public UnitOfWork(WorldLeagueDbContext context)
        {
            Context = context;
        }

        public async Task<IDbTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            var transaction = await Context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return transaction.GetDbTransaction();
        }

        public ValueTask DisposeAsync()
        {
            return Context.DisposeAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
