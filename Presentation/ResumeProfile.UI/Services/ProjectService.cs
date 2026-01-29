using ResumeProfile.UI.Models.ProjectDtos;
using System.ComponentModel;
using System.Net.Http.Json;

namespace ResumeProfile.UI.Services
{
    public class ProjectService
    {
        private readonly HttpClient _http;

        public ProjectService(HttpClient http)
        {
            _http = http;
        }

        // 📌 افزودن پروژه جدید (نیاز به توکن دارد)
        public async Task<bool> AddProjectAsync(MultipartFormDataContent content)
        {
            var response = await _http.PostAsync("Project/Create", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProjectAsync(MultipartFormDataContent content)
        {
            // ایجاد یک درخواست PUT دستی برای حفظ multipart/form-data
            var request = new HttpRequestMessage(HttpMethod.Put, "Project/Update")
            {
                Content = content
            };

            // این خط کمک می‌کنه که .NET boundary رو درست بسازه
            request.Headers.ExpectContinue = false;

            // ارسال درخواست
            var response = await _http.SendAsync(request);

            // بررسی موفقیت پاسخ
            return response.IsSuccessStatusCode;
        }


        // 📌 دریافت لیست پروژه‌ها (عمومی یا محافظت‌شده)
        public async Task<List<ProjectDto>?> GetAllProjectsAsync()
        {
            return await _http.GetFromJsonAsync<List<ProjectDto>>("Project/GetAll");
        }

        public async Task<List<ProjectAdminDto>?> GetAllProjectsAdminAsync()
        {
            return await _http.GetFromJsonAsync<List<ProjectAdminDto>>("Project/GetAllForAdmin/admin");
        }
        public async Task<ProjectDetailDto?> GetProjectDetailAsync(long id)
        {
            return await _http.GetFromJsonAsync<ProjectDetailDto>($"Project/Detail/{id}");
        }

        // 📌 حذف پروژه (محافظت‌شده)
        public async Task<bool> DeleteProjectAsync(long id)
        {
            var response = await _http.DeleteAsync($"Project/Delete/{id}");
            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// نمایش در صفحه اصلی
        /// </summary>
        public async Task<bool> ShowOn(long id, bool show)
        {
            var response = await _http.PostAsync($"Project/Showon/{id}?show={show}", null);
            return response.IsSuccessStatusCode;

        }
    }
}
