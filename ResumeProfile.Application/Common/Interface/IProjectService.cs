namespace ResumeProfile.Application.Common.Interface
{
    public interface IProjectService : IRepository<Project>
    {
        Task<IEnumerable<ProjectDto>> GetAllProjects();
        Task<IEnumerable<ProjectAdminDto>> GetAllProjectsAdmin();
        Task<ProjectDetailDto> GetProjectDetailById(long projectId);
        Task<long> CreateProject(CreateProjectDto createProject);
        Task<long> UpdateProject(UpdateProjectDto updateProject);
        Task RemoveProject(long projectId);
        Task<bool> ShowOn(long id, bool show);
    }
}
