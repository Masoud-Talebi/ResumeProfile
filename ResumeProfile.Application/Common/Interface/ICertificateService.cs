
namespace ResumeProfile.Application.Common.Interface
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateDto>> GetAllCertificate();
        Task<CertificateDto> GetCertificateById(long certificateId);
        Task<long> CreateCertificate(CreateCertificateDto createCertificate);
        Task<long> UpdateCertificate(UpdateCertificateDto updateCertificate);
        Task<bool> DeleteCertificate(long CertificateId);
        Task<bool> ShowOn(long id, bool show);
    }
}
