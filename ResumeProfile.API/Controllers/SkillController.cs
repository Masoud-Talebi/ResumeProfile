using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProfile.API.Common;
using ResumeProfile.Application.CQRS.Skills.Commands;
using ResumeProfile.Application.CQRS.Skills.Queries;
using ResumeProfile.Infrastructure.Common;

namespace ResumeProfile.API.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class SkillController : ApiBaseController
    {
        /// <summary>
        /// دریافت همه مهارت‌ها (برای نمایش در سایت عمومی)
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSkillQuery());
            return Ok(result);
        }

        /// <summary>
        /// دریافت جزئیات یک مهارت بر اساس شناسه
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetSkillByIdQuery() { Id = id});

            if (result == null)
                return NotFound(new { Message = "مهارتی با این شناسه یافت نشد." });

            return Ok(result);
        }

        /// <summary>
        /// ایجاد مهارت جدید
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSkillCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, new { SkillId = id });
        }

        /// <summary>
        /// ویرایش مهارت موجود
        /// </summary>
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSkillCommand command)
        {
            if (id != command.Id)
                return BadRequest(new { Message = "شناسه مهارت با داده‌ی ارسالی مطابقت ندارد." });

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// حذف مهارت
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteSkillCommand { Id = id });

            if (!result)
                return BadRequest(new { Message = "حذف مهارت انجام نشد." });

            return Ok(new { Message = "مهارت با موفقیت حذف شد." });
        }
    }
}
