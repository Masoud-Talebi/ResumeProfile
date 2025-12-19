namespace ResumeProfile.Application.CQRS.Projects.Queries
{
    [Display(Name = "دریافت لیست پروژه‌ها برای ادمین")]
    public class GetAllProjectsAdminQuery : IRequest<IEnumerable<ProjectAdminDto>>
    {
    }

    public class GetAllProjectsAdminQueryHandler : IRequestHandler<GetAllProjectsAdminQuery, IEnumerable<ProjectAdminDto>>
    {
        private readonly IProjectService _projectService;

        public GetAllProjectsAdminQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IEnumerable<ProjectAdminDto>> Handle(GetAllProjectsAdminQuery request, CancellationToken cancellationToken)
        {
            return await _projectService.GetAllProjectsAdmin();
        }
    }
}
