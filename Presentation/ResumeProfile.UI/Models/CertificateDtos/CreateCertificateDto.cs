using Microsoft.AspNetCore.Http;

namespace ResumeProfile.UI.Models.CertificateDtos
{
    public class CreateCertificateDto
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "عنوان مدرک الزامی است")]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("سازمان صادرکننده")]
        [Required(ErrorMessage = "نام سازمان الزامی است")]
        public string certificate_org { get; set; }

        [DisplayName("سال")]
        [Required(ErrorMessage = "تاریخ الزامی است")]
        public DateTime certificate_year { get; set; }

        public SVGType SVG { get; set; }
    }
}
