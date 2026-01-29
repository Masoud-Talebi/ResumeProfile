namespace ResumeProfile.UI.Models.ProjectDtos
{
    public class ProjectDetailDto
    {
        [DisplayName("شناسه پروژه")]
        public long Id { get; set; }

        [DisplayName("تصویر پروژه")]
        public string? ImageBase64 { get; set; }

        [DisplayName("عنوان")]
        public required string Title { get; set; }

        [DisplayName("ویژگی ها")]
        public List<string>? Tags { get; set; }

        [DisplayName("توضیح کوتاه")]
        public required string Decription { get; set; }

        [DisplayName("جزیات")]
        public string? Body { get; set; }

        [DisplayName("وضعیت پروژه")]
        public ProjectState ProjectState { get; set; }

        [DisplayName("تاریخ تکمیل")]
        public DateTime? CompletionDate { get; set; }
    }
}
