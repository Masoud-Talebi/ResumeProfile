using ResumeProfile.Infrastructure.MapConfig.IdentityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ResumeProfile.Infrastructure.Persistence;

public class SqlServerApplicationDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
{
    public SqlServerApplicationDbContext(DbContextOptions<SqlServerApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ResumeProfile");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.OnCreated();
        modelBuilder.OnModified();
        modelBuilder.OnDeleted();
    }

    //? Implementation DbSet...
    public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
}
