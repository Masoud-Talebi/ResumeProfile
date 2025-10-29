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
    }
    public enum ProjectState
    {

    }
}