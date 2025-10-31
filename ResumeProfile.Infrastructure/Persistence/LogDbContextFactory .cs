namespace ResumeProfile.Infrastructure.Persistence
{
    public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
    {
        public LogDbContext CreateDbContext(string[] args)
        {
            var connStr = "Data Source=.;Initial Catalog=ResumeProfile.Log;Integrated Security = true;Encrypt=False;";

            var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();
            optionsBuilder.UseSqlServer(connStr);

            return new LogDbContext(optionsBuilder.Options);
        }

    }
}