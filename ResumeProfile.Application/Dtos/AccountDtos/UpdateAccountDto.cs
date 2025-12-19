namespace ResumeProfile.Application.Dtos.AccountDtos
{
    public class UpdateAccountDto
    {
        [Required]
        public long UserId { get; set; }

        [Required(ErrorMessage = "رمز عبور فعلی الزامی است.")]
        public string CurrentPassword { get; set; } = string.Empty;

        public string? NewUserName { get; set; }
        public string? NewPassword { get; set; }
    }
}
