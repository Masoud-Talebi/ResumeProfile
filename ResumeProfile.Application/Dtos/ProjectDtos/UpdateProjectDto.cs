namespace ResumeProfile.Application.Dtos.ProjectDtos
{
    public class UpdateProjectDto
    {
        [DisplayName("شناسه پروژه")]
        public long Id { get; set; }

        [DisplayName("تصویر پروژه")]
        public IFormFile? Images { get; set; }

        [Required(ErrorMessage = "عنوان پروژه الزامی است")]
        [DisplayName("عنوان")]
        public required string Title { get; set; }

        [DisplayName("ویژگی ها")]
        public List<string>? Tags { get; set; }

        [Required(ErrorMessage = "توضیح کوتاه الزامی است")]
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
