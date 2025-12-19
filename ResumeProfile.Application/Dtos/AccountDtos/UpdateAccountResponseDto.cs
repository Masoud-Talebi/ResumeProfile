namespace ResumeProfile.Application.Dtos.AccountDtos
{
    // DTO پاسخ
    public class UpdateAccountResponseDto
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public string? NewUserName { get; set; }
    }
}
