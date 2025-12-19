using ResumeProfile.Application.Dtos.SkillDtos;

namespace ResumeProfile.Application.Common.Interface
{
    public interface ISkillService
    {
        Task<long> CreateSkill(CreateSkillDto createSkill);
        Task<long> UpdateSkill(UpdateSkillDto updateSkill);
        Task<bool> DeleteSkill(long skillId);
        Task<IEnumerable<SkillDto>> GetAllSkills();
        Task<SkillDto> GetSkillById(long skillId);
        Task<bool> ShowOn(long id, bool show);
    }
}
