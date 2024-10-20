using Microsoft.EntityFrameworkCore.Diagnostics;
using WorldLeague.Domain.Constants;
using WorldLeague.SharedKernel.Entities;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL.Interceptors
{
    public sealed class SaveChangesInterceptor : Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            var entries = context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                switch (entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        if (entity.GetType().BaseType!.IsGenericType && entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(CreationAuditedEntity<>))
                        {
                            //TODO:Constants
                            entity.GetType().GetProperty(DomainConstants.CreationTime)!.SetValue(entity, DateTime.UtcNow);
                        }
                        break;
                }

            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
