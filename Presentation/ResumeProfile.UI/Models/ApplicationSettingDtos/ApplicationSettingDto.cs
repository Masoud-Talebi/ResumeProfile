using System.ComponentModel;

namespace ResumeProfile.UI.Models.ApplicationSettingDtos
{
    public class ApplicationSettingDto
    {
        [DisplayName("شناسه")]
        public long Id { get; set; }

        [DisplayName("نام کامل")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("نام")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; } = string.Empty;

        [DisplayName("درباره من")]
        public string AboutMe { get; set; } = string.Empty;

        [DisplayName("ایمیل")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("حرفه")]
        public string Profession { get; set; } = string.Empty;

        [DisplayName("تصویر پروفایل")]
        public string? ProfileImageBase64 { get; set; }

        [DisplayName("لایسنس")]
        public string License { get; set; } = string.Empty;

        [DisplayName("وضعیت لایسنس")]
        public bool LicenseValid { get; set; }
    }
}
