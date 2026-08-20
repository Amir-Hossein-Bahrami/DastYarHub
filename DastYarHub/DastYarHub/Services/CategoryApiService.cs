using DastYarHub.DTOs.Categories;

namespace DastYarHub.Services
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryResponseDto>> GetActiveCategoriesAsync()
        {
            try
            {
                var categories = await _httpClient.GetFromJsonAsync<List<CategoryResponseDto>>("api/Categories/active");

                return categories ?? new List<CategoryResponseDto>();
            }
            catch (HttpRequestException)
            {
                return new List<CategoryResponseDto>();
            }
        }
    }
}
