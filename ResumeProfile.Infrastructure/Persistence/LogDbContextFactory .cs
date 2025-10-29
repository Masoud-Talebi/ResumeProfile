namespace ResumeProfile.Infrastructure.Persistence
{
    public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
    {
        public LogDbContext CreateDbContext(string[] args)
        {
            var connStr = AESService.Decrypt("QJFKs4mKwknekuN98COOwZd3eJRw2CNeaPhpyEsqErrEAK4XExQHbxGN18T6JhrGUjFUA6Buk/Q54+yUCMiuop0eBLZ8jCrCz0j6JOFPsI0phxPo6/hl0+uEBZcuiA8Df+s4ndXeMwHMuxO/hVLERtL8Mdy0oU65vPfYWR5J0LL73Vf7WidBiB6/XLnoaNG2Kd2uJkWYPofjv4WApA7TdvR4Zqb3LY/XcxWRb8uo9E8=");

            var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();
            optionsBuilder.UseSqlServer(connStr);

            return new LogDbContext(optionsBuilder.Options);
        }

    }
}