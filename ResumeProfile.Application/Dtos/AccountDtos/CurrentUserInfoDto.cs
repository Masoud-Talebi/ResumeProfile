namespace ResumeProfile.Application.Dtos.AccountDtos
{
    public class CurrentUserInfoDto
    {
        [Display(Name = "شناسه کاربر")]
        public long Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }

        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }
    }
}