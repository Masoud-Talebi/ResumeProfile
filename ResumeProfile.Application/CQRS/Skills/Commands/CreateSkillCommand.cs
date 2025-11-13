using MediatR;
using ResumeProfile.Application.Dtos.SkillDtos;
using System.ComponentModel.DataAnnotations;

namespace ResumeProfile.Application.CQRS.Skills.Commands
{
    [Display(Name = "ایجاد مهارت جدید")]
    public class CreateSkillCommand : CreateSkillDto, IRequest<long>
    {
    }

    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, long>
    {
        private readonly ISkillService _skillService;

        public CreateSkillCommandHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<long> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            return await _skillService.CreateSkill(request);
        }
    }
}
