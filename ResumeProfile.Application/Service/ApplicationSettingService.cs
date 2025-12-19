namespace ResumeProfile.Application.Service
{
    public class ApplicationSettingService : Repository<ApplicationSetting>, IApplicationSettingService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationSettingService(IApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApplicationSettingDto?> GetApplicationSetting()
        {
            var setting = await base.EntitiesAsNoTracking.FirstOrDefaultAsync();
            return _mapper.Map<ApplicationSettingDto>(setting);
        }

        public async Task<long> UpdateApplicationSetting(UpdateApplicationSettingDto updateSetting)
        {
            updateSetting.Id = 1;
            var setting = _mapper.Map<ApplicationSetting>(updateSetting);
            await base.UpdateAsync(setting);
            return setting.Id;
        }
    }
}
