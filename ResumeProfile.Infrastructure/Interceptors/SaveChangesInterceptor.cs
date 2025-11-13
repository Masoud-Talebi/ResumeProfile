
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ResumeProfile.Infrastructure.Interceptors
{
    public class SaveChangesInterceptor : Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SaveChangesInterceptor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
                return base.SavingChanges(eventData, result);
            var entries = eventData.Context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity)
                .ToList();

            if (!entries.Any())
                return base.SavingChanges(eventData, result);

            var currentUserId = _contextAccessor.HttpContext.GetUserId();
            var currentUserIP = _contextAccessor.HttpContext.GetUserIP();

            foreach (var entry in entries.Where(x => x.State == EntityState.Added))
            {

                entry.Property("CreatedDateTime").CurrentValue = DateTime.UtcNow;
                entry.Property("CreatedByUserId").CurrentValue = currentUserId;
                entry.Property("CreatedByIP").CurrentValue = currentUserIP;
            }
            
            foreach (var entry in entries.Where(x => x.State == EntityState.Modified))
            {

                entry.Property("ModifiedDateTime").CurrentValue = DateTime.UtcNow;
                entry.Property("ModifiedByUserId").CurrentValue = currentUserId;
                entry.Property("ModifiedByIP").CurrentValue = currentUserIP;
            }

            foreach (var entry in entries.Where(p => p.State == EntityState.Deleted))
            {

                entry.State = EntityState.Modified;
                entry.Property("DeletedDateTime").CurrentValue = DateTime.UtcNow;
                entry.Property("DeletedByUserId").CurrentValue = currentUserId;
                entry.Property("DeletedByIP").CurrentValue = currentUserIP;
                entry.Property("IsDeleted").CurrentValue = true;
            }

            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
                return base.SavingChangesAsync(eventData, result);

            var entries = eventData.Context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity)
                .ToList();

            if (!entries.Any())
                return base.SavingChangesAsync(eventData, result);

            var currentUserId = _contextAccessor.HttpContext.GetUserId();
            var currentUserIP = _contextAccessor.HttpContext.GetUserIP();

            foreach (var entry in entries.Where(x => x.State == EntityState.Added))
            {

                entry.Property("CreatedDateTime").CurrentValue = DateTime.UtcNow;
                entry.Property("CreatedByUserId").CurrentValue = currentUserId;
                entry.Property("CreatedByIP").CurrentValue = currentUserIP;
            }

            foreach (var entry in entries.Where(x => x.State == EntityState.Modified))
            {

                entry.Property("ModifiedDateTime").CurrentValue = DateTime.UtcNow;
                entry.Property("ModifiedByUserId").CurrentValue = currentUserId;
                entry.Property("ModifiedByIP").CurrentValue = currentUserIP;
            }

            foreach (var entry in entries.Where(p => p.State == EntityState.Deleted))
            {

                entry.State = EntityState.Modified;
                entry.Property("DeletedDateTime").CurrentValue = DateTime.UtcNow;
                entry.Property("DeletedByUserId").CurrentValue = currentUserId;
                entry.Property("DeletedByIP").CurrentValue = currentUserIP;
                entry.Property("IsDeleted").CurrentValue = true;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
