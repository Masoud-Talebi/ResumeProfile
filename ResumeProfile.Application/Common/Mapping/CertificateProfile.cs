namespace ResumeProfile.Application.Common.Mapping
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            // Certificate → CertificateDto و بالعکس
            CreateMap<Certificate, CertificateDto>().ReverseMap();

            // Certificate → CreateCertificateDto و بالعکس
            CreateMap<CreateCertificateDto, Certificate>().ReverseMap();

            // Certificate → UpdateCertificateDto و بالعکس
            CreateMap<UpdateCertificateDto, Certificate>().ReverseMap();
        }
    }
}
