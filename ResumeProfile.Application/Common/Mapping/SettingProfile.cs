using AutoMapper;
using ResumeProfile.Application.Dtos.ApplicationSettingDtos;
using ResumeProfile.Domain.Entities.Common;

namespace ResumeProfile.Application.Common.Mapping
{
    public class SettingProfile : Profile
    {
        public SettingProfile()
        {
            // Map از Entity به DTO
            CreateMap<ApplicationSetting, ApplicationSettingDto>().ReverseMap();

            // Map برای ویرایش تنظیمات
            CreateMap<UpdateApplicationSettingDto, ApplicationSetting>().ReverseMap();
        }
    }
}
