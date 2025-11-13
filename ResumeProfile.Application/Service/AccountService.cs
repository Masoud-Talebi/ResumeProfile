using System.Security.Claims;
using Microsoft.Extensions.Options;
using ResumeProfile.Application.Common;
using ResumeProfile.Application.Dtos.AccountDtos;

namespace ResumeProfile.Application.Service
{
    public class AccountService : IAccountService
    {
        public readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(IApplicationDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContext;
            _contextAccessor = contextAccessor;
        }
        public async Task<CurrentUserInfoDto> GetCurrentUserInformation()
        {
            var userId = _contextAccessor.HttpContext.GetUserId();
            if (userId == null)
                throw new Exception("کاربر در سیستم وارد نشده است.");

            long currentUserId = userId;
            var userInfo = await _dbContext.Set<User>()
            .Where(x => x.Id == currentUserId)
            .Select(x => new CurrentUserInfoDto
            {
                Id = x.Id,
                UserName = x.UserName,
                Password = x.PasswordHash,
            }).FirstOrDefaultAsync();

            return userInfo;
        }

    }
}