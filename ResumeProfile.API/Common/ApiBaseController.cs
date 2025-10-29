using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProfile.API.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}