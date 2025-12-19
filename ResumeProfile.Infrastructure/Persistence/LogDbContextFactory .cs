namespace ResumeProfile.Infrastructure.Persistence
{
    public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
    {
        public LogDbContext CreateDbContext(string[] args)
        {
            var connStr = "Server=192.168.1.50;Database=ResumeProfile.Log;User Id=sa;password=Masoud@2023;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=True;";

            var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();
            optionsBuilder.UseSqlServer(connStr);

            return new LogDbContext(optionsBuilder.Options);
        }

    }
}