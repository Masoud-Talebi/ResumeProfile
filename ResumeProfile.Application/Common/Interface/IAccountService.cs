using ResumeProfile.Application.CQRS.Accounts.Queries.GetCurrentUser;
using ResumeProfile.Application.Dtos.AccountDtos;

namespace ResumeProfile.Application.Common.Interface;

public interface IAccountService
{
    Task<CurrentUserInfoDto> GetCurrentUserInformation();
}
