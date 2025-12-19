
namespace ResumeProfile.Application.CQRS.Certificates.Commands
{
    [Display(Name = "حذف گواهی")]
    public class DeleteCertificateCommand : IRequest<bool>
    {
        [Display(Name = "شناسه گواهی")]
        public long Id { get; set; }
    }
    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, bool>
    {
        private readonly ICertificateService _certificateService;
        public DeleteCertificateCommandHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public async Task<bool> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            return await _certificateService.DeleteCertificate(request.Id);
        }
    }
}


