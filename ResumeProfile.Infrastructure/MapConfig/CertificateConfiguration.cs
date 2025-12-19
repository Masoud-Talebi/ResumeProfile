namespace ResumeProfile.Infrastructure.MapConfig
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
            builder.HasData(new Certificate()
            {
                Id = 1,
                Title = "Advanced C# Programming",
                certificate_org = "Microsoft",
                SVG = SVGType.microsoft,
                ShowOnSite = true,
                certificate_year = DateTime.Now,
                Description = "Professional certification by Microsoft.",

            }, new Certificate()
            {
                Id = 2,
                Title = "Windows Server 2019",
                certificate_org = "Microsoft",
                SVG = SVGType.windows,
                ShowOnSite = true,
                certificate_year = DateTime.Now,
                Description = "Certified training in managing Windows Server & Active Directory.",

            }, new Certificate()
            {
                Id = 3,
                Title = "Linux Administration Basics",
                certificate_org = "Linux Foundation",
                SVG = SVGType.linux,
                ShowOnSite = true,
                certificate_year = DateTime.Now,
                Description = "Core Linux server management and command-line essentials.",

            },new Certificate()
            {
                Id = 4,
                Title = "Docker Containerization Expert",
                certificate_org = "Docker Inc",
                SVG = SVGType.docker,
                ShowOnSite = true,
                certificate_year = DateTime.Now,
                Description = "Mastery in creating and managing Docker containers.",

            });
        }
    }
}
