using ResumeProfile.Application.Dtos.ApplicationSettingDtos;
using ResumeProfile.Domain.Entities.Common;

namespace ResumeProfile.Application.Common.Interface
{
    public interface IApplicationSettingService : IRepository<ApplicationSetting>
    {
        Task<ApplicationSettingDto?> GetApplicationSetting();
        Task<long> UpdateApplicationSetting(UpdateApplicationSettingDto updateSetting);
    }
}
