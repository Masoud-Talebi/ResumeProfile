using System.ComponentModel;

namespace ResumeProfile.Application.Dtos.SkillDtos
{
    public class SkillDto
    {
        [DisplayName("شناسه مهارت")]
        public long Id { get; set; }

        [DisplayName("نام مهارت")]
        public required string Name { get; set; }

        [DisplayName("سطح مهارت")]
        public int Level { get; set; }
    }
}
