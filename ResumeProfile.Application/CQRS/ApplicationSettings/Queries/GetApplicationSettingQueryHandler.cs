namespace ResumeProfile.Application.CQRS.ApplicationSettings.Queries
{
    public class GetApplicationSettingQuery : IRequest<ApplicationSettingDto?>
    {
    }

    public class GetApplicationSettingQueryHandler : IRequestHandler<GetApplicationSettingQuery, ApplicationSettingDto?>
    {
        private readonly IApplicationSettingService _applicationSettingService;

        public GetApplicationSettingQueryHandler(IApplicationSettingService applicationSettingService)
        {
            _applicationSettingService = applicationSettingService;
        }

        public async Task<ApplicationSettingDto?> Handle(GetApplicationSettingQuery request, CancellationToken cancellationToken)
        {
            return await _applicationSettingService.GetApplicationSetting();
        }
    }
}
