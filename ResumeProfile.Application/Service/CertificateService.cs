
namespace ResumeProfile.Application.Service
{
    public class CertificateService : Repository<Certificate>, ICertificateService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CertificateService(IApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> CreateCertificate(CreateCertificateDto createCertificate)
        {
            var Certificate = _mapper.Map<Certificate>(createCertificate);
            await base.CreateAsync(Certificate);
            return Certificate.Id;
        }

        public async Task<bool> DeleteCertificate(long CertificateId)
        {
            var Certificate = await base.GetByIdAsync(CertificateId);
            if (Certificate == null)
                return false;

            await base.DeleteAsync(Certificate);
            return true;
        }

        public async Task<IEnumerable<CertificateDto>> GetAllCertificate()
        {
            var certificates = await base.EntitiesAsNoTracking.ToListAsync();
            return _mapper.Map<IEnumerable<CertificateDto>>(certificates);
        }

        public async Task<CertificateDto> GetCertificateById(long certificateId)
        {
            var certificate = await base.GetByIdAsync(certificateId);
            return _mapper.Map<CertificateDto>(certificate);
        }

        public async Task<long> UpdateCertificate(UpdateCertificateDto updateCertificate)
        {
            var Certificate = _mapper.Map<Certificate>(updateCertificate);
            await base.UpdateAsync(Certificate);
            return Certificate.Id;
        }
        public async Task<bool> ShowOn(long id, bool show)
        {
            var skill = await base.GetByIdAsync(id);
            if (skill == null)
                return false;
            skill.ShowOnSite = show;
            await base.SaveChangesAsync();
            return true;
        }
    }
}
