using ResumeProfile.Application.Dtos.SkillDtos;

namespace ResumeProfile.Application.Common.Mapping
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            // Skill → SkillDto و بالعکس
            CreateMap<Skill, SkillDto>().ReverseMap();

            // Skill → CreateSkillDto و بالعکس
            CreateMap<CreateSkillDto, Skill>().ReverseMap();

            // Skill → UpdateSkillDto و بالعکس
            CreateMap<UpdateSkillDto, Skill>().ReverseMap();
        }
    }
}
