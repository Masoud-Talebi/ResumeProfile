namespace ResumeProfile.Domain.Entities
{
    public class Project : BaseEntity
    {
        /// <summary>
        /// تصویر
        /// </summary>
        public byte[]? Image { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// ویژگی ها
        /// </summary>
        public List<string>? Tags { get; set; }
        /// <summary>
        /// توضیح کوتاه
        /// </summary>
        public required string Decription { get; set; }
        /// <summary>
        /// جزیات
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// وضعیت پروژه
        /// </summary>
        public ProjectState ProjectState { get; set; }

        /// <summary>
        /// تاریخ تکمیل
        /// </summary>
        public DateTime? CompletionDate { get; set; }
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