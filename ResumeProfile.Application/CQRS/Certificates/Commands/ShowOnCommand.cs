namespace ResumeProfile.Application.CQRS.Certificates.Commands
{
    public class ShowOnCommandCommand : IRequest<bool>
    {
        [Display(Name = "شناسه ")]
        public long Id { get; set; }
        public bool show { get; set; }

    }
    public class ShowOnCommandCommandHandler : IRequestHandler<ShowOnCommandCommand, bool>
    {
        private readonly ICertificateService _certificateService;
        public ShowOnCommandCommandHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public async Task<bool> Handle(ShowOnCommandCommand request, CancellationToken cancellationToken)
        {
            return await _certificateService.ShowOn(request.Id, request.show);
        }
    }
}


