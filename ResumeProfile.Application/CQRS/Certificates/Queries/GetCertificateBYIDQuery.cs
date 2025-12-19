namespace ResumeProfile.Application.CQRS.Certificates.Queries
{
    public class GetCertificateBYIDQuery : IRequest<CertificateDto>
    {
        [Display(Name = "شناسه گواهی")]
        public long Id { get; set; }
    }
    public class GetCertificateBYIDQueryHandler : IRequestHandler<GetCertificateBYIDQuery, CertificateDto>
    {
        private readonly ICertificateService _certificateService;
        public GetCertificateBYIDQueryHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public async Task<CertificateDto> Handle(GetCertificateBYIDQuery request, CancellationToken cancellationToken)
        {
            return await _certificateService.GetCertificateById(request.Id);
        }
    }
}
