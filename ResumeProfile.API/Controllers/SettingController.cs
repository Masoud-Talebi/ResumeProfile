using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProfile.API.Common;
using ResumeProfile.Application.CQRS.ApplicationSettings.Commands;
using ResumeProfile.Application.CQRS.ApplicationSettings.Queries;
using ResumeProfile.Infrastructure.Common;

namespace ResumeProfile.API.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class SettingController : ApiBaseController
    {
        /// <summary>
        /// دریافت اطلاعات تنظیمات (برای نمایش در سایت عمومی)
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetApplicationSettingQuery());

            if (result == null)
                return NotFound(new { Message = "تنظیمات یافت نشد." });

            return Ok(result);
        }

        /// <summary>
        /// ویرایش تنظیمات کلی سایت (نام، درباره من، ایمیل و ...)
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateApplicationSettingCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
