using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ResumeProfile.FrameWork.Common;
using Serilog.Core;
using Serilog.Events;

namespace ResumeProfile.Application.Common
{
    public class ShadowPropertyEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;
        public ShadowPropertyEnricher(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _accessor = accessor;
        }
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Properties.ContainsKey("UserId"))
            {

            }
            else
            {
                long userId = 0;
                try
                {
                    userId = _accessor.HttpContext.GetUserId();

                }
                catch (Exception)
                {
                }
                logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("userId", userId));

            }



            var UserAgent = _accessor.HttpContext?.Request?.Headers["User-Agent"].ToString();
            var UserAgentSpecific = _accessor.HttpContext?.Request?.Headers["sec-ch-ua"].ToString();

            var createdByIP = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var now = DateTimeOffset.UtcNow;


            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CreatedDateTime", now));
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CreatedByIP", createdByIP));
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CreatedByBrowserName", UserAgent));
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CreatedByBrowserNameSpecific", UserAgentSpecific));

            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("SystemName", "DoctorAppointment"));

        }
    }
}