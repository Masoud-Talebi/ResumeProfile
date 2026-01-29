using Microsoft.JSInterop;

namespace ResumeProfile.UI.Helpers
{
    public static class LocalStorage
    {
        private static IJSRuntime? _js;

        public static void Init(IJSRuntime js) => _js = js;

        public static async Task SetItemAsync(string key, string value)
        {
            if (_js != null)
                await _js.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public static async Task<string?> GetItemAsync(string key)
        {
            if (_js != null)
                return await _js.InvokeAsync<string>("localStorage.getItem", key);
            return null;
        }

        public static async Task RemoveItemAsync(string key)
        {
            if (_js != null)
                await _js.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
