namespace ResumeProfile.Domain.Entities.Common
{
    public class ApplicationSetting : BaseEntity
    {
        /// <summary>
        /// نام
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public required string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName ?? ""} {LastName ?? ""}";
        /// <summary>
        /// درباره ی من
        /// </summary>
        public required string AboutMe { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// حرفه
        /// </summary>
        public required string Profession { get; set; }
        /// <summary>
        /// تصویر پروفایل
        /// </summary>
        public byte[]? Profile { get; set; }
        /// <summary>
        /// لایسنس برنامه
        ///  </summary>
        public required string License { get; set; }
        /// <summary>
        ///  راست آزمایی لایسنس
        ///  </summary>
        public bool LicenseValid { get; set; }
    }
}