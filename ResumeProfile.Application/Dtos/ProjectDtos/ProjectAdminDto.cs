namespace ResumeProfile.Application.Dtos.ProjectDtos
{
    public class ProjectAdminDto
    {
        [DisplayName("شناسه پروژه")]
        public long Id { get; set; }

        [DisplayName("تصویر پروژه")]
        public byte[]? Image { get; set; }

        [DisplayName("عنوان")]
        public required string Title { get; set; }

        [DisplayName("وضعیت پروژه")]
        public ProjectState ProjectState { get; set; }

        [DisplayName("تاریخ ایجاد")]
        public DateTime CreateAt { get; set; }
    }
}
