namespace ResumeProfile.Infrastructure.MapConfig
{
    public class ApplicationSettingConfiguration : IEntityTypeConfiguration<ApplicationSetting>
    {
        public void Configure(EntityTypeBuilder<ApplicationSetting> builder)
        {
            builder.HasData(new ApplicationSetting
            {
                Id = 1,
                FirstName = "Resume",
                LastName = "Profile",
                AboutMe = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Consectetur adipiscing elit quisque faucibus ex sapien vitae. Ex sapien vitae pellentesque sem placerat in id. Placerat in id cursus mi pretium tellus duis. Pretium tellus duis convallis tempus leo eu aenean.",
                Email = "info@example.com",
                License = "...",
                Profession = "Asp.net core Programmer",
                LicenseValid = false,
                
            });
        }
    }
}
