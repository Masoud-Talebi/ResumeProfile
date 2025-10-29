namespace ResumeProfile.Infrastructure.Common
{
    public static class DatabaseStartup
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {



            services.AddTransient<SaveChangesInterceptor>();
            services.AddDbContextPool<IApplicationDbContext, SqlServerApplicationDbContext>((sp, options) =>
            {

                var conStr = configuration.GetConnectionString("DefultConnection") ?? throw new Exception("connection database invalid");
                options.UseSqlServer(AESService.Decrypt(conStr)).AddInterceptors(sp.GetRequiredService<SaveChangesInterceptor>());
            }, poolSize: 16);

            services.AddDbContext<LogDbContext>(options =>
            {
                // می‌تونی مستقیم همون Decrypt رو بزنی
                var conStr = configuration.GetConnectionString("LogDbConnection");
                options.UseSqlServer(AESService.Decrypt(conStr));
            });
            services.AddScoped<ILogDbContext, LogDbContext>();





        }
    }
}