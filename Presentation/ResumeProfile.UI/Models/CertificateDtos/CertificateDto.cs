namespace ResumeProfile.UI.Models.CertificateDtos
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
    public enum SVGType
    {
        award,
        amazon,
        mobile_alt,
        shield_alt,
        microsoft,
        docker,
        linux,
        windows,
        linkedin,
        stack_overflow
    }
}
