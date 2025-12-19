namespace ResumeProfile.Application.CQRS.Skills.Commands
{
    public class ShowOnCommandCommand : IRequest<bool>
    {
        [Display(Name = "شناسه ")]
        public long Id { get; set; }
        public bool show { get; set; }

    }
    public class ShowOnCommandCommandHandler : IRequestHandler<ShowOnCommandCommand, bool>
    {
        private readonly ISkillService _skillService;
        public ShowOnCommandCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }
        public async Task<bool> Handle(ShowOnCommandCommand request, CancellationToken cancellationToken)
        {
            return await _skillService.ShowOn(request.Id, request.show);
        }
    }
}


