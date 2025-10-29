namespace ResumeProfile.Infrastructure.Persistence;

public interface ILogDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    int SaveChanges();

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<ErrorHistory> ErrorHistories { get; set; }
    DbSet<EmailHistory> SmsHistories { get; set; }
}