namespace ResumeProfile.Application.Dtos.AccountDtos
{
    public class LoginResponseDto
    {
        public long? UserId { get; set; }
        public string? Token { get; set; }
        public string? UserName { get; set; }
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }
    }
}
