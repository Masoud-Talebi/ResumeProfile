using MediatR;
using System.ComponentModel.DataAnnotations;
using ResumeProfile.Application.Dtos.ProjectDtos;
using ResumeProfile.Application.Service;

namespace ResumeProfile.Application.CQRS.Projects.Queries
{
    [Display(Name = "دریافت جزئیات پروژه")]
    public class GetProjectDetailQuery : IRequest<ProjectDetailDto>
    {
        [Display(Name = "شناسه پروژه")]
        public long Id { get; set; }

        public GetProjectDetailQuery(long id)
        {
            Id = id;
        }
    }

    public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, ProjectDetailDto>
    {
        private readonly IProjectService _projectService;

        public GetProjectDetailQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<ProjectDetailDto> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
        {
            return await _projectService.GetProjectDetailById(request.Id);
        }
    }
}
