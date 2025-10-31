namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AppUserClaims");


            // builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
        }

    }
}