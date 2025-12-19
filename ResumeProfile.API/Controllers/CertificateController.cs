using Microsoft.AspNetCore.Mvc;
using ResumeProfile.Application.CQRS.Certificates.Commands;
using ResumeProfile.Application.CQRS.Certificates.Queries;
using ResumeProfile.Application.CQRS.Skills.Commands;
using ResumeProfile.Application.CQRS.Skills.Queries;

namespace ResumeProfile.API.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class CertificateController : ApiBaseController
    {
        /// <summary>
        /// دریافت همه ‌گواهی ها)
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCertificateQuery());
            return Ok(result);
        }

        /// <summary>
        /// دریافت جزئیات یک گواهی بر اساس شناسه
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetCertificateBYIDQuery() { Id = id });

            if (result == null)
                return NotFound(new { Message = "گواهی با این شناسه یافت نشد." });

            return Ok(result);
        }

        /// <summary>
        /// ایجاد گواهی جدید
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCertificateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, new { CertificateId = id });
        }

        /// <summary>
        /// ویرایش گواهی موجود
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCertificateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// حذف گواهی
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteCertificateCommand { Id = id });

            if (!result)
                return BadRequest(new { Message = "حذف گواهی انجام نشد." });

            return Ok(new { Message = "گواهی با موفقیت حذف شد." });
        }
        /// <summary>
        /// نمایش گواهی
        /// </summary>
        [HttpPost("{id:long}")]
        public async Task<IActionResult> Showon(long id, bool show)
        {
            var result = await _mediator.Send(new Application.CQRS.Certificates.Commands.ShowOnCommandCommand { Id = id, show = show });

            if (!result)
                return BadRequest(new { Message = "نمایش گواهی انجام نشد." });

            return Ok(new { Message = "گواهی با موفقیت نمایش داده شد." });
        }
    }
}
