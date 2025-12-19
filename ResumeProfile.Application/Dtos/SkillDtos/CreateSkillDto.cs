
namespace ResumeProfile.Application.Dtos.SkillDtos
{
    public class CreateSkillDto
    {
        [Required(ErrorMessage = "نام مهارت الزامی است")]
        [DisplayName("نام مهارت")]
        public required string Name { get; set; }

        [Range(1, 100, ErrorMessage = "سطح مهارت باید بین 1 تا 100 باشد")]
        [DisplayName("سطح مهارت")]
        public int Level { get; set; }
    }
}
