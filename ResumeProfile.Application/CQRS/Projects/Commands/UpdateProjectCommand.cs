using MediatR;
using System.ComponentModel.DataAnnotations;
using ResumeProfile.Application.Dtos.ProjectDtos;
using ResumeProfile.Application.Service;

namespace ResumeProfile.Application.CQRS.Projects.Commands
{
    [Display(Name = "ویرایش پروژه")]
    public class UpdateProjectCommand : UpdateProjectDto, IRequest<long>
    {
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, long>
    {
        private readonly IProjectService _projectService;

        public UpdateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<long> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            // ✅ چون UpdateProject انتظار UpdateProjectDto داره، نیازی به تبدیل نیست
            // ولی بهتره async/await به درستی استفاده بشه و ; اضافی حذف بشه
            return await _projectService.UpdateProject(request);
        }
    }
}
