using MediatR;
using System.ComponentModel.DataAnnotations;
using ResumeProfile.Application.Service;

namespace ResumeProfile.Application.CQRS.Projects.Commands
{
    [Display(Name = "حذف پروژه")]
    public class DeleteProjectCommand : IRequest<bool>
    {
        [Display(Name = "شناسه پروژه")]
        public long Id { get; set; }
    }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IProjectService _projectService;

        public DeleteProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            // فرض می‌کنیم Repository یا Service شما متد DeleteAsync دارد
            await _projectService.DeleteAsync(request.Id);
            return true; // یا true/false بسته به پیاده‌سازی
        }
    }
}
