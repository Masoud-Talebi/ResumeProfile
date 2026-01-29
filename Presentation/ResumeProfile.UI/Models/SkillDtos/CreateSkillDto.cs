using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ResumeProfile.UI.Models.SkillDtos
{
    public class CreateSkillDto
    {
        [Required(ErrorMessage = "نام مهارت الزامی است")]
        [DisplayName("نام مهارت")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "سطح مهارت باید بین 1 تا 100 باشد")]
        [DisplayName("سطح مهارت")]
        public int Level { get; set; }
    }
}
