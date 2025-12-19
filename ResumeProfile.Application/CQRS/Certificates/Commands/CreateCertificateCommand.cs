
namespace ResumeProfile.Application.CQRS.Certificates.Commands
{
    [Display(Name = "افزودن گواهی")]
    public class CreateCertificateCommand : CreateCertificateDto, IRequest<long>
    {
    }
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, long>
    {
        private readonly ICertificateService _certificateService;
        public CreateCertificateCommandHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public async Task<long> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            return await _certificateService.CreateCertificate(request);
        }
    }
}
