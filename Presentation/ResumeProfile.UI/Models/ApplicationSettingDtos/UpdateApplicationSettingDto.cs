using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace ResumeProfile.UI.Models.ApplicationSettingDtos
{
    public class UpdateApplicationSettingDto
    {
        [DisplayName("شناسه")]
        public long Id { get; set; }

        [DisplayName("نام")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }

        [DisplayName("درباره من")]
        public string AboutMe { get; set; }

        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [DisplayName("حرفه")]
        public string Profession { get; set; }

        [DisplayName("تصویر پروفایل")]
        public IFormFile? Images { get; set; }

        [DisplayName("لایسنس")]
        public string License { get; set; }
        public bool LicenseValid { get; set; }
    }
}
