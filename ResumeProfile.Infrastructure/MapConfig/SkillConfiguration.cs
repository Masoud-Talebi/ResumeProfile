namespace ResumeProfile.Infrastructure.MapConfig
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
            builder.HasData(new Skill()
            {
                Id = 1,
                Name = "C#",
                Level = 80,
                ShowOnSite = true,

            }, new Skill()
            {
                Id = 2,
                Name = "React",
                Level = 50,
                ShowOnSite = true,
            }, new Skill()
            {
                Id = 3,
                Name = "Js",
                Level = 70,
                ShowOnSite = true,
            },new Skill()
            {
                Id = 4,
                Name = "Asp.net Core",
                Level = 90,
                ShowOnSite = true,
            });
        }
    }
}
