using ResumeProfile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProfile.Application.Dtos.ProjectDtos
{
    public class ProjectDetailDto
    {
        [DisplayName("شناسه پروژه")]
        public long Id { get; set; }

        [DisplayName("تصویر پروژه")]
        public byte[]? Image { get; set; }

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

        [DisplayName("تاریخ ایجاد")]
        public DateTime CreateAt { get; set; }
    }
}
