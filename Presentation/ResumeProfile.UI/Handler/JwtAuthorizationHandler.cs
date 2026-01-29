using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace ResumeProfile.UI.Handler
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly IJSRuntime _js;
        private readonly NavigationManager _navigationManager;

        public JwtAuthorizationHandler(IJSRuntime js, NavigationManager navigationManager)
        {
            _js = js;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // اضافه کردن توکن به header
            try
            {
                var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch
            {
                // اگر JSRuntime آماده نبود، ادامه بده بدون توکن
            }

            // ارسال درخواست
            var response = await base.SendAsync(request, cancellationToken);

            // اگر توکن منقضی یا کاربر لاگین نکرده → ریدایرکت
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                // پاک کردن توکن محلی
                await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");

                // ریدایرکت به صفحه login
                _navigationManager.NavigateTo("/login", forceLoad: true);
            }

            return response;
        }
    }
}
