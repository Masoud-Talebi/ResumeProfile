namespace ResumeProfile.Domain.Entities
{
    public class Certificate : BaseEntity
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// سازمان صادرکننده
        /// </summary>
        public string certificate_org { get; set; }
        /// <summary>
        /// سال
        /// </summary>
        public DateTime certificate_year { get; set; }
        /// <summary>
        /// SVG (Style Css)
        /// </summary>
        public SVGType SVG { get; set; }
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
