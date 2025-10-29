namespace ResumeProfile.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        #region Structure

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion
        DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Skill> Skills { get; set; }

    }
}