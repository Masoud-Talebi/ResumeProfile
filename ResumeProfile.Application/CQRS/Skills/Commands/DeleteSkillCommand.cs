namespace ResumeProfile.Application.CQRS.Skills.Commands
{
    [Display(Name = "حذف مهارت")]
    public class DeleteSkillCommand : IRequest<bool>
    {
        [Display(Name = "شناسه مهارت")]
        public long Id { get; set; }
    }

    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, bool>
    {
        private readonly ISkillService _skillService;

        public DeleteSkillCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            return await _skillService.DeleteSkill(request.Id);
        }
    }
}
