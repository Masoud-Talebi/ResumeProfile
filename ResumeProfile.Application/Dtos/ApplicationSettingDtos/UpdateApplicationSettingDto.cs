
namespace ResumeProfile.Application.Dtos.ApplicationSettingDtos
{
    public class UpdateApplicationSettingDto
    {
        [DisplayName("شناسه")]
        public long Id { get; set; }

        [DisplayName("نام")]
        public required string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        public required string LastName { get; set; }

        [DisplayName("درباره من")]
        public required string AboutMe { get; set; }

        [DisplayName("ایمیل")]
        public required string Email { get; set; }

        [DisplayName("حرفه")]
        public required string Profession { get; set; }

        [DisplayName("تصویر پروفایل")]
        public IFormFile? Images { get; set; }

        [DisplayName("لایسنس")]
        public required string License { get; set; }
    }
}
