using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ResumeProfile.UI;
using ResumeProfile.UI.Handler;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<JwtAuthorizationHandler>();
builder.Services.AddHttpClient("ApiClient")
       .AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ✅ آدرس پایه API (تغییر بده به آدرس سرور واقعی)
string apiBaseUrl = "https://localhost:7086/api/";



// ✅ HttpClient با Jwt Handler
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<JwtAuthorizationHandler>();
    handler.InnerHandler = new HttpClientHandler(); // بسیار مهم!

    return new HttpClient(handler)
    {
        BaseAddress = new Uri(apiBaseUrl)
    };
});

// ✅ AuthService (برای لاگین و ذخیره توکن)
builder.Services.AddScoped<AuthService>();

// ✅ AuthenticationStateProvider برای Blazor
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<AppSettingService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<CertificateService>();

// ✅ ساخت و اجرای اپ
await builder.Build().RunAsync();
