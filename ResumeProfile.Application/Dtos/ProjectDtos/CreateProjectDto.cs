using ResumeProfile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProfile.Application.Dtos.ProjectDtos
{
    public class CreateProjectDto
    {

        [DisplayName("تصویر پروژه")]
        public byte[]? Image { get; set; }

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
    }
}
