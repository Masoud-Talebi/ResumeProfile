namespace ResumeProfile.Application.CQRS.Projects.Commands
{
    public class ShowOnCommandCommand : IRequest<bool>
    {
        [Display(Name = "شناسه ")]
        public long Id { get; set; }
        public bool show { get; set; }

    }
    public class ShowOnCommandCommandHandler : IRequestHandler<ShowOnCommandCommand, bool>
    {
        private readonly IProjectService _projectService;
        public ShowOnCommandCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<bool> Handle(ShowOnCommandCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.ShowOn(request.Id, request.show);
        }
    }
}


