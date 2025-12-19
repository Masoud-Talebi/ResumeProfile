using ResumeProfile.Domain.Entities;

namespace ResumeProfile.Application.Service
{
    public class SkillService : Repository<Skill>, ISkillService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SkillService(IApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> CreateSkill(CreateSkillDto createSkill)
        {
            var skill = _mapper.Map<Skill>(createSkill);
            await base.CreateAsync(skill);
            return skill.Id;
        }

        public async Task<long> UpdateSkill(UpdateSkillDto updateSkill)
        {
            var skill = _mapper.Map<Skill>(updateSkill);
            await base.UpdateAsync(skill);
            return skill.Id;
        }

        public async Task<bool> DeleteSkill(long skillId)
        {
            var skill = await base.GetByIdAsync(skillId);
            if (skill == null)
                return false;

            await base.DeleteAsync(skill);
            return true;
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkills()
        {
            var skills = await base.EntitiesAsNoTracking.ToListAsync();
            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public async Task<SkillDto> GetSkillById(long skillId)
        {
            var skill = await base.GetByIdAsync(skillId);
            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<bool> ShowOn(long id, bool show)
        {
            var skill = await base.GetByIdAsync(id);
            if (skill == null)
                return false;
            skill.ShowOnSite = show;
            await base.SaveChangesAsync();
            return true;
        }
    }
}
