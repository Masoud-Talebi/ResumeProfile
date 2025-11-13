using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProfile.API.Common;
using ResumeProfile.Application.CQRS.Accounts.Commands.ChangePasswordUserName;
using ResumeProfile.Application.CQRS.Accounts.Commands.Login;
using ResumeProfile.Application.CQRS.Accounts.Queries.GetCurrentUser;
using ResumeProfile.Infrastructure.Common;

namespace ResumeProfile.API.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class AccountController : ApiBaseController
    {
        /// <summary>
        /// ورود کاربر و تولید توکن JWT
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginAccountCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// دریافت اطلاعات کاربر جاری
        /// </summary>
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _mediator.Send(new GetCurrentUserQuery());
            return Ok(result);
        }

        /// <summary>
        /// ویرایش نام کاربری یا رمز عبور
        /// </summary>
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// خروج کاربر (اختیاری)
        /// </summary>
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            // چون JWT Stateless است، logout واقعی سمت کلاینت انجام می‌شود.
            return Ok(new { Message = "خروج با موفقیت انجام شد." });
        }
    }
}
