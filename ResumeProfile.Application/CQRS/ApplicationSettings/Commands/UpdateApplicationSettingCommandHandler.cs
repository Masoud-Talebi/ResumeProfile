namespace ResumeProfile.Application.CQRS.ApplicationSettings.Commands
{
    public class UpdateApplicationSettingCommand : IRequest<long>
    {
        public required UpdateApplicationSettingDto UpdateDto { get; set; }
    }

    public class UpdateApplicationSettingCommandHandler : IRequestHandler<UpdateApplicationSettingCommand, long>
    {
        private readonly IApplicationSettingService _applicationSettingService;

        public UpdateApplicationSettingCommandHandler(IApplicationSettingService applicationSettingService)
        {
            _applicationSettingService = applicationSettingService;
        }

        public async Task<long> Handle(UpdateApplicationSettingCommand request, CancellationToken cancellationToken)
        {
            return await _applicationSettingService.UpdateApplicationSetting(request.UpdateDto);
        }
    }
}
