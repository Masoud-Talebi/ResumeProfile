namespace ResumeProfile.Application.Dtos.AccountDtos
{
    public class LoginAccountDto
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است")]
        [Display(Name = "کلمه عبور")]
        public required string Password { get; set; }

    }
}
