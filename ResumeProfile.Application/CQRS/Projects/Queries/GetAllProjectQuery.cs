using MediatR;
using System.ComponentModel.DataAnnotations;
using ResumeProfile.Application.Dtos.ProjectDtos;
using ResumeProfile.Application.Service;

namespace ResumeProfile.Application.CQRS.Projects.Queries
{
    [Display(Name = "دریافت تمام پروژه‌ها")]
    public class GetAllProjectsQuery : IRequest<IEnumerable<ProjectDto>>
    {
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly IProjectService _projectService;

        public GetAllProjectsQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectService.GetAllProjects();
        }
    }
}
