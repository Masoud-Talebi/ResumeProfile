namespace ResumeProfile.Infrastructure.MapConfig
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasQueryFilter(x => !EF.Property<bool>(x, "IsDeleted"));
            builder.HasData(new Project()
            {
                Id = 1,
                Title = "Asp.net Project",
                Decription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Dolor sit amet consectetur adipiscing elit quisque faucibus.",
                ShowOnSite = true,
                CompletionDate = DateTime.Now,
                ProjectState = ProjectState.Completed,
            }, new Project()
            {
                Id = 2,
                Title = "Windows Form Project",
                Decription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Dolor sit amet consectetur adipiscing elit quisque faucibus.",
                ShowOnSite = true,
                CompletionDate = DateTime.Now,
                ProjectState = ProjectState.Completed,
            });
        }
    }
}
