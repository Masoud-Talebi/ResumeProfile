namespace ResumeProfile.UI.Models.ProjectDtos
{
    public class ProjectAdminDto
    {
        [DisplayName("شناسه پروژه")]
        public long Id { get; set; }

        [DisplayName("تصویر پروژه")]
        public string? ImageBase64 { get; set; }

        [DisplayName("عنوان")]
        public required string Title { get; set; }

        [DisplayName("وضعیت پروژه")]
        public ProjectState ProjectState { get; set; }


        [DisplayName("تاریخ تکمیل")]
        public DateTime? CompletionDate { get; set; }

        [DisplayName("نمایش در صفحه اصلی")]
        public bool ShowOnSite { get; set; }
    }
    public enum ProjectState
    {
        /// <summary>
        /// در حال انجام
        /// </summary>
        InProgress = 0,

        /// <summary>
        /// تکمیل شده
        /// </summary>
        Completed = 1,

        /// <summary>
        /// منتشر شده
        /// </summary>
        Published = 2
    }

}
