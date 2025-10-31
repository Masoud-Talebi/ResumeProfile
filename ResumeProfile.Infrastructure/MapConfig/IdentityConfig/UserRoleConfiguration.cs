namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
           // builder.HasKey(x => x.Id);
            builder.ToTable("AppUserRoles");
            // کلید اصلی مرکب
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}