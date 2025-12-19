namespace ResumeProfile.Application.Service
{
    public class ProjectService : Repository<Project>, IProjectService
    {
        public IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectService(IApplicationDbContext context, IMapper mapper) : base(context)
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

        public async Task<IEnumerable<ProjectDto>> GetAllProjects()
        {
            var project = await base.EntitiesAsNoTracking.ToListAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(project);
        }

        public async Task<ProjectDetailDto> GetProjectDetailById(long projectId)
        {
            var project = await base.GetByIdAsync(projectId);
            return _mapper.Map<ProjectDetailDto>(project);
        }

        public async Task<long> UpdateProject(UpdateProjectDto updateProject)
        {
            var project = _mapper.Map<Project>(updateProject);
            await base.UpdateAsync(project);
            return project.Id;
        }

        public async Task<IEnumerable<ProjectAdminDto>> GetAllProjectsAdmin()
        {
            var project = await base.EntitiesAsNoTracking.ToListAsync();
            return _mapper.Map<IEnumerable<ProjectAdminDto>>(project);
        }
        public async Task RemoveProject(long projectId)
        {
            var project = await base.GetByIdAsync(projectId);
            if (project != null)
                await base.DeleteAsync(project);
        }
        public async Task<bool> ShowOn(long id, bool show)
        {
            var skill = await base.GetByIdAsync(id);
            if (skill == null)
                return false;
            skill.ShowOnSite = show;
            await base.SaveChangesAsync();
            return true;
        }
    }
}
