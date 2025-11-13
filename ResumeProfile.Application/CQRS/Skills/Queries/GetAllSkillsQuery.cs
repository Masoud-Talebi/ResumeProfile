using MediatR;
using ResumeProfile.Application.Dtos.SkillDtos;
using System.ComponentModel.DataAnnotations;

namespace ResumeProfile.Application.CQRS.Skills.Queries
{
    [Display(Name = "دریافت تمام مهارت‌ها")]
    public class GetAllSkillQuery : IRequest<IEnumerable<SkillDto>> { }

    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, IEnumerable<SkillDto>>
    {
        private readonly ISkillService _skillService;

        public GetAllSkillQueryHandler(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IEnumerable<SkillDto>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            return await _skillService.GetAllSkills();
        }
    }
}
