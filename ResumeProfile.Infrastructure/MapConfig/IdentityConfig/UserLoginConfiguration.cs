namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AppUserLogins");
            //builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
        }

    }
}