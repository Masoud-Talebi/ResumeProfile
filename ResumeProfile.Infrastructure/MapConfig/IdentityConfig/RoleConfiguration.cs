namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("AppRoles");

            builder.HasKey(x => x.Id);

            builder.HasIndex(r => r.Name).IsUnique();

            // Relation: Role -> UserRoles
            builder.HasMany(e => e.UserRoles)
                   .WithOne(e => e.Role)
                   .HasForeignKey(ur => ur.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relation: Role -> RoleClaims
            builder.HasMany(e => e.RoleClaims)
                   .WithOne(e => e.Role)
                   .HasForeignKey(rc => rc.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(SeedData.DefaultRoles);

            // builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
        }

    }
}
