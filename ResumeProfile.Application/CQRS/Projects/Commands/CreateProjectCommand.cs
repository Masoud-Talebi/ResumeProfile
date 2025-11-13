using MediatR;
using System.ComponentModel.DataAnnotations;
using ResumeProfile.Application.Dtos.ProjectDtos;
using ResumeProfile.Application.Service;

namespace ResumeProfile.Application.CQRS.Projects.Commands
{
    [Display(Name = "ایجاد پروژه")]
    public class CreateProjectCommand : CreateProjectDto, IRequest<long>
    {
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, long>
    {
        private readonly IProjectService _projectService;

        public CreateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<long> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.CreateProject(request);
        }
    }
}
