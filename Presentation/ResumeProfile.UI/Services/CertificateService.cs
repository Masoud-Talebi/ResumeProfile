using ResumeProfile.UI.Models.CertificateDtos;
using System.Net.Http.Json;

namespace ResumeProfile.UI.Services
{
    public class CertificateService
    {
        private readonly HttpClient _http;

        public CertificateService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// دریافت همه گواهی‌ها
        /// </summary>
        public async Task<List<CertificateDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<CertificateDto>>("Certificate/GetAll") ?? new List<CertificateDto>();
        }

        /// <summary>
        /// دریافت جزئیات یک گواهی
        /// </summary>
        public async Task<CertificateDto?> GetByIdAsync(long id)
        {
            return await _http.GetFromJsonAsync<CertificateDto>($"Certificate/GetById/{id}");
        }

        /// <summary>
        /// ایجاد گواهی جدید
        /// </summary>
        public async Task<bool> CreateAsync(CreateCertificateDto dto)
        {
            var response = await _http.PostAsJsonAsync("Certificate/Create", dto);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// ویرایش گواهی موجود
        /// </summary>
        public async Task<bool> UpdateAsync(UpdateCertificateDto dto)
        {
            var response = await _http.PutAsJsonAsync("Certificate/Update", dto);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// حذف گواهی
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            var response = await _http.DeleteAsync($"Certificate/Delete/{id}");
            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// نمایش در صفحه اصلی
        /// </summary>
        public async Task<bool> ShowOn(long id, bool show)
        {
            var response = await _http.PostAsync($"Certificate/Showon/{id}?show={show}", null);
            return response.IsSuccessStatusCode;

        }
    }
}
