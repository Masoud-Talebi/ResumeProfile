using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProfile.UI.Models.AccountDtos
{
    // DTO پاسخ
    public class UpdateAccountResponseDto
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public string? NewUserName { get; set; }
    }
}
