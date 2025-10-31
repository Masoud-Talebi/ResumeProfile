using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                AboutMe = "lorem",
                Email = "info@example.com",
                License = "...",
                Profession = "Asp.net core Programmer",
                LicenseValid = false,
                
            });
        }
    }
}
