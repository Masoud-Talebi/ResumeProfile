using ResumeProfile.UI.Models.ApplicationSettingDtos;
using ResumeProfile.UI.Models.ProjectDtos;
using System.Net.Http.Json;

namespace ResumeProfile.UI.Services
{
    public class AppSettingService
    {
        private readonly HttpClient _http;

        public AppSettingService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ApplicationSettingDto?> GetAsync()
        {
            return await _http.GetFromJsonAsync<ApplicationSettingDto>("Setting/Get");
        }

        public async Task<bool> UpdateAsync(MultipartFormDataContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "Setting/Update")
            {
                Content = content
            };

            request.Headers.ExpectContinue = false;

            var response = await _http.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }

}
