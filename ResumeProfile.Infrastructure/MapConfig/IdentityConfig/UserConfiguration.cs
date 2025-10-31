namespace ResumeProfile.Infrastructure.MapConfig.IdentityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AppUsers");
            // builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));

            // Relations
            builder.HasMany(e => e.Claims)
                   .WithOne(e => e.User)
                   .HasForeignKey(uc => uc.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Logins)
                   .WithOne(e => e.User)
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Tokens)
                   .WithOne(e => e.User)
                   .HasForeignKey(ut => ut.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.UserRoles)
                   .WithOne(e => e.User)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
