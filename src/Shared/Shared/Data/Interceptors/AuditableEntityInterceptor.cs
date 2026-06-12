
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.DDD;

namespace Shared.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData, cancellationToken);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    private void UpdateEntities(DbContextEventData eventData, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context == null) return;
        var entries = context.ChangeTracker.Entries<IEntity>();
        var now = DateTime.UtcNow;
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.CreatedBy = "System";
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModified = now;
                entry.Entity.LastModifiedBy = "System";
            }
        }
        return;
    }
}
