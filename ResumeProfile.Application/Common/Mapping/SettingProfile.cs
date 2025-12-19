namespace ResumeProfile.Application.Common.Mapping
{
    public class SettingProfile : Profile
    {
        public SettingProfile()
        {
            CreateMap<ApplicationSetting, ApplicationSettingDto>()
               .ForMember(dest => dest.ProfileImageBase64,
                   opt => opt.MapFrom(src =>
                       src.Profile != null ? FrameWork.Common.Extensions.ConvertByteArrayToBase64string(src.Profile) : null))
               .ReverseMap()
               .ForMember(dest => dest.Profile,
                   opt => opt.MapFrom(src =>
                       src.ProfileImageBase64 != null ? Convert.FromBase64String(src.ProfileImageBase64) : null));
            // Map برای ویرایش تنظیمات
            CreateMap<UpdateApplicationSettingDto, ApplicationSetting>().ReverseMap();

            CreateMap<UpdateApplicationSettingDto, ApplicationSetting>()
                .ForMember(dest => dest.Profile,
                    opt => opt.MapFrom(src =>
                        src.Images != null ? FrameWork.Common.Extensions.ConvertIFormFileToByteforImage(src.Images) : null
                    ))
                .ReverseMap();
        }
    }
}
