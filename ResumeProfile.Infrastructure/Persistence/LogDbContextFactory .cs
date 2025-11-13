namespace ResumeProfile.Infrastructure.Persistence
{
    public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
    {
        public LogDbContext CreateDbContext(string[] args)
        {
            var connStr = "Data Source=tai.liara.cloud,31170;Initial Catalog=myDB;User Id=sa;Password=qOm7aAfcJerUTXo3F8py18Ph;Encrypt=False;";

            var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();
            optionsBuilder.UseSqlServer(connStr);

            return new LogDbContext(optionsBuilder.Options);
        }

    }
}