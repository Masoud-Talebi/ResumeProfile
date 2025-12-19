namespace ResumeProfile.Application.CQRS.Accounts.Queries.GetCurrentUser
{
    [Display(Name = "دریافت اطلاعات کاربر فعلی")]
    public class GetCurrentUserQuery : IRequest<CurrentUserInfoDto>
    {
    }

    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, CurrentUserInfoDto>
    {
        private readonly IAccountService _accountService;

        public GetCurrentUserQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<CurrentUserInfoDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            // استفاده از AccountService برای گرفتن اطلاعات کاربر
            var userInfo = await _accountService.GetCurrentUserInformation();

            if (userInfo == null)
                throw new Exception("کاربر یافت نشد.");

            return userInfo;
        }
    }
}
