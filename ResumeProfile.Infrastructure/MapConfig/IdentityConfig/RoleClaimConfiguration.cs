namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("AppRoleClaims");
          
            builder.HasOne(rc => rc.Role)
                   .WithMany(r => r.RoleClaims)
                   .HasForeignKey(rc => rc.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
        }

    }
}