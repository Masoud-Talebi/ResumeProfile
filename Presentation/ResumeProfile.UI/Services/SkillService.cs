using ResumeProfile.UI.Models.SkillDtos;
using System.Net.Http.Json;

namespace ResumeProfile.UI.Services
{
    public class SkillService
    {
        private readonly HttpClient _http;

        public SkillService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// دریافت همه مهارت‌ها
        /// </summary>
        public async Task<List<SkillDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<SkillDto>>("Skill/GetAll") ?? new List<SkillDto>();
        }

        /// <summary>
        /// دریافت جزئیات یک مهارت
        /// </summary>
        public async Task<SkillDto?> GetByIdAsync(long id)
        {
            return await _http.GetFromJsonAsync<SkillDto>($"Skill/GetById/{id}");
        }

        /// <summary>
        /// نمایش در صفحه اصلی
        /// </summary>
        public async Task<bool> ShowOn(long id, bool show)
        {
            var response = await _http.PostAsync($"Skill/Showon/{id}?show={show}",null);
            return response.IsSuccessStatusCode;

        }

        /// <summary>
        /// ایجاد مهارت جدید
        /// </summary>
        public async Task<long?> CreateAsync(CreateSkillDto dto)
        {
            var response = await _http.PostAsJsonAsync("Skill/Create", dto);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Dictionary<string, long>>();
                if (data != null && data.TryGetValue("SkillId", out var id))
                    return id;
            }
            return null;
        }

        /// <summary>
        /// ویرایش مهارت موجود
        /// </summary>
        public async Task<bool> UpdateAsync(UpdateSkillDto dto)
        {
            var response = await _http.PutAsJsonAsync($"Skill/Update/{dto.Id}", dto);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// حذف مهارت
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            var response = await _http.DeleteAsync($"Skill/Delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
