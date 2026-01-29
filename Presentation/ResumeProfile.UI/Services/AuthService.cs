using ResumeProfile.UI.Helpers;
using System.Net.Http.Json;
using static ResumeProfile.UI.Pages.Login;

namespace ResumeProfile.UI.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Login(LoginAccountDto model)
        {
            var response = await _http.PostAsJsonAsync("Account/login", model);
            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (result?.Token == null)
                return false;

            await LocalStorage.SetItemAsync("authToken", result.Token);
            return true;
        }
        public async Task<UpdateAccountResponseDto> ChangePassword(UpdateAccountDto model)
        {
            var response = await _http.PutAsJsonAsync("Account/UpdateAccount/Update", model);
            return await response.Content.ReadFromJsonAsync<UpdateAccountResponseDto>() ?? null;
        }
        public async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
        }
    }
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
