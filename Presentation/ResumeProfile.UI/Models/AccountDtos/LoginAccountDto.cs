namespace ResumeProfile.UI.Models.AccountDtos
{
    public class LoginAccountDto
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است")]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

    }
}
