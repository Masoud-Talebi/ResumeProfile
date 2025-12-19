namespace ResumeProfile.Application.CQRS.Certificates.Queries
{
    [Display(Name = "دریافت تمام گواهی‌ها")]
    public class GetAllCertificateQuery : IRequest<IEnumerable<CertificateDto>> { }
    public class GetAllCertificateQueryHandler : IRequestHandler<GetAllCertificateQuery, IEnumerable<CertificateDto>>
    {
        private readonly ICertificateService _certificateService;
        public GetAllCertificateQueryHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public async Task<IEnumerable<CertificateDto>> Handle(GetAllCertificateQuery request, CancellationToken cancellationToken)
        {
            return await _certificateService.GetAllCertificate();
        }
    }
}
