using DastYarHub.DTOs.ToolUsages;

namespace DastYarHub.Services
{
    public class ToolUsageService : IToolUsageService
    {
        private readonly HttpClient _httpClient;

        public ToolUsageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PopularToolDto>> GetPopularToolsAsync()
        {
            var popularTools = await _httpClient.GetFromJsonAsync<List<PopularToolDto>>("api/ToolUsages/popular");

            return popularTools ?? new List<PopularToolDto>();
        }
    }
}
