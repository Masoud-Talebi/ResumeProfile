namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AppUserTokens");
           // builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
        }

    }
}