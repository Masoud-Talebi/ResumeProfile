namespace ResumeProfile.Application.CQRS.Certificates.Commands
{
    [Display(Name = "ویرایش گواهی")]
    public class UpdateCertificateCommand : UpdateCertificateDto, IRequest<long>
    {
    }
    public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand, long>
    {
        private readonly ICertificateService _certificateService;
        public UpdateCertificateCommandHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public async Task<long> Handle(UpdateCertificateCommand request, CancellationToken cancellationToken)
        {
            return await _certificateService.UpdateCertificate(request);
        }
    }
}
