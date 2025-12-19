namespace ResumeProfile.Application.CQRS.Accounts.Commands.ChangePasswordUserName
{
    [Display(Name = "ویرایش حساب کاربری")]
    public class UpdateAccountCommand : UpdateAccountDto,IRequest<UpdateAccountResponseDto>
    {
      
    }

    // 🧠 Handler
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UpdateAccountCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UpdateAccountResponseDto> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            // کاربر را بر اساس UserId پیدا کن
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return new UpdateAccountResponseDto { Success = false, ErrorMessage = "کاربر یافت نشد." };

            // بررسی صحت رمز عبور فعلی
            var checkPassword = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
            if (!checkPassword)
                return new UpdateAccountResponseDto { Success = false, ErrorMessage = "رمز عبور فعلی اشتباه است." };

            // تغییر نام کاربری (در صورت نیاز)
            if (!string.IsNullOrWhiteSpace(request.NewUserName) && request.NewUserName != user.UserName)
            {
                // بررسی تکراری نبودن نام کاربری
                var exists = await _userManager.FindByNameAsync(request.NewUserName);
                if (exists != null)
                    return new UpdateAccountResponseDto { Success = false, ErrorMessage = "این نام کاربری قبلاً انتخاب شده است." };

                user.UserName = request.NewUserName;
                user.NormalizedUserName = request.NewUserName.ToUpper();
            }

            // تغییر رمز عبور (در صورت نیاز)
            if (!string.IsNullOrWhiteSpace(request.NewPassword))
            {
                var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
                if (!result.Succeeded)
                    return new UpdateAccountResponseDto { Success = false, ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description)) };
            }
            else
            {
                // در صورتی که فقط نام کاربری تغییر کرده
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                    return new UpdateAccountResponseDto { Success = false, ErrorMessage = "خطا در به‌روزرسانی اطلاعات کاربر." };
            }

            return new UpdateAccountResponseDto
            {
                Success = true,
                NewUserName = user.UserName
            };
        }
    }
}
