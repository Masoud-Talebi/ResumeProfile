namespace ResumeProfile.Application.CQRS.Skills.Commands
{
    [Display(Name = "ویرایش مهارت")]
    public class UpdateSkillCommand : UpdateSkillDto, IRequest<long>
    {
    }

    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, long>
    {
        private readonly ISkillService _skillService;

        public UpdateSkillCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<long> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            return await _skillService.UpdateSkill(request);
        }
    }
}
