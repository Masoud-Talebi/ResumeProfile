using IdentityModel;
using System.Security.Claims;

namespace ResumeProfile.Application.Common.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DbInitializer(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            // اول نقش‌ها رو بساز اگه وجود ندارن
            if (!await _roleManager.RoleExistsAsync(SD.Admin))
                await _roleManager.CreateAsync(new Role() { Name = SD.Admin });

            // بعد بررسی کن اگه ادمین وجود نداره، بسازش
            var adminUser = await _userManager.FindByNameAsync("admin");

            if (adminUser == null)
            {
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@site.com",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, "Admin@123");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, SD.Admin);

                    await _userManager.AddClaimsAsync(user, new Claim[]
                    {
                        new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(JwtClaimTypes.Name, user.UserName),
                        new Claim(JwtClaimTypes.Email, user.Email ?? "")
                    });
                }
            }
        }
    }

    public interface IDbInitializer
    {
        Task Initialize();
    }
}
