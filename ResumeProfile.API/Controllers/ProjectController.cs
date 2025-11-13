using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProfile.API.Common;
using ResumeProfile.Application.CQRS.Projects.Commands;
using ResumeProfile.Application.CQRS.Projects.Queries;
using ResumeProfile.Infrastructure.Common;

namespace ResumeProfile.API.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class ProjectController : ApiBaseController
    {
        /// <summary>
        /// دریافت همه پروژه‌ها (برای کاربر عمومی)
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(result);
        }

        /// <summary>
        /// دریافت همه پروژه‌ها (برای پنل ادمین)
        /// </summary>
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllForAdmin()
        {
            var result = await _mediator.Send(new GetAllProjectsAdminQuery());
            return Ok(result);
        }

        /// <summary>
        /// دریافت جزئیات یک پروژه
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> Detail(long id)
        {
            var result = await _mediator.Send(new GetProjectDetailQuery(id));

            if (result == null)
                return NotFound(new { Message = "پروژه‌ای با این شناسه یافت نشد." });

            return Ok(result);
        }

        /// <summary>
        /// ایجاد پروژه جدید
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProjectCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Detail), new { id }, new { ProjectId = id });
        }


        /// <summary>
        /// ویرایش پروژه موجود
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProjectCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// حذف پروژه
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand { Id = id });

            if (!result)
                return BadRequest(new { Message = "حذف پروژه انجام نشد." });

            return Ok(new { Message = "پروژه با موفقیت حذف شد." });
        }
    }
}
