namespace ResumeProfile.Application.CQRS.Accounts.Commands.Login
{
    [Display(Name = "ورود کاربر")]
    public class LoginAccountCommand : LoginAccountDto, IRequest<LoginResponseDto>
    {
    }    // Handler مربوط به LoginAccountCommand
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, LoginResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings jwtSettings;
        private readonly SignInManager<User> _signInManager;
        public LoginAccountCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.jwtSettings = jwtSettings.Value;
        }
        public async Task<LoginResponseDto> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName,
                    cancellationToken);

            if (user == null)
                return new LoginResponseDto { Success = false, ErrorMessage = "کاربری با این مشخصات یافت نشد." };

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                return new LoginResponseDto { Success = false, ErrorMessage = "نام کاربری یا رمز عبور اشتباه است." };

            var roles = await _userManager.GetRolesAsync(user);

            // مثال: توکن JWT بسازید
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new LoginResponseDto()
            {
                UserId = user.Id,
                UserName = user.UserName ?? "",
                Token = token,
                Success = true
            };
             
        }
        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, user.UserName),
                new Claim(JwtClaimTypes.Email, user.Email ?? "")
            };

            foreach (var role in roles)
                claims.Add(new Claim(JwtClaimTypes.Role, role));

            int expireTime = int.Parse(AESService.Decrypt(jwtSettings.DurationInMinutes));

            var _key = AESService.Decrypt(jwtSettings.Key);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                issuer: AESService.Decrypt(jwtSettings.Issuer),
                audience: AESService.Decrypt(jwtSettings.Audience),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireTime),
                signingCredentials: signingCredentials);

            return jwtToken;
        }
    }
}
