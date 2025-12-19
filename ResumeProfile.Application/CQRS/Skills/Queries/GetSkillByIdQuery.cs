namespace ResumeProfile.Application.CQRS.Skills.Queries;

[Display(Name = "دریافت جزئیات مهارت")]
public class GetSkillByIdQuery : IRequest<SkillDto>
{
    [Display(Name = "شناسه مهارت")]
    public long Id { get; set; }
}

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillDto>
{
    private readonly ISkillService _skillService;

    public GetSkillByIdQueryHandler(ISkillService skillService)
    {
        _skillService = skillService;
    }

    public async Task<SkillDto> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        return await _skillService.GetSkillById(request.Id);
    }
}