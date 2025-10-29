namespace ResumeProfile.Infrastructure.Persistence
{
    public class LogDbContext : DbContext, ILogDbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ErrorHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new SmsHistoryConfiguration());
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ErrorHistory> ErrorHistories { get; set; }
        public DbSet<EmailHistory> SmsHistories { get; set; }

    }
}