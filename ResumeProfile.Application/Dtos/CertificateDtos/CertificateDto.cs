
namespace ResumeProfile.Application.Dtos.CertificateDtos
{
    public class CertificateDto
    {
        [DisplayName("شناسه")]
        public long Id { get; set; }
        [DisplayName("عنوان")]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("سازمان صادرکننده")]
        public string certificate_org { get; set; }

        [DisplayName("سال")]
        public DateTime certificate_year { get; set; }
        public SVGType SVG { get; set; }

        [DisplayName("نمایش در صفحه اصلی")]
        public bool ShowOnSite { get; set; }

    }
}
