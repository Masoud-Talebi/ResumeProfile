using ResumeProfile.Application.Dtos.ProjectDtos;
using ResumeProfile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProfile.Application.Common.Interface
{
    public interface IProjectService : IRepository<Project>
    {
        Task<IEnumerable<ProjectDto>> GetAllProjects();
        Task<IEnumerable<ProjectAdminDto>> GetAllProjectsAdmin();
        Task<ProjectDetailDto> GetProjectDetailById(long projectId);
        Task<long> CreateProject(CreateProjectDto createProject);
        Task<long> UpdateProject(UpdateProjectDto updateProject);
    }
}
