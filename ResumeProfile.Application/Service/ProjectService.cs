using AutoMapper;
using ResumeProfile.Application.Common.Interface;
using ResumeProfile.Application.Dtos.ProjectDtos;
using ResumeProfile.Domain.Entities;
using ResumeProfile.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProfile.Application.Service
{
    public class ProjectService : Repository<Project>, IProjectService
    {
        public IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectService(IApplicationDbContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<long> CreateProject(CreateProjectDto createProject)
        {
            var project = _mapper.Map<Project>(createProject);
            await base.CreateAsync(project);
            return project.Id;
        }

        public Task<IEnumerable<ProjectDto>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDetailDto> GetProjectDetailById(long projectId)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateProject(UpdateProjectDto updateProject)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProjectAdminDto>> IProjectService.GetAllProjectsAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
