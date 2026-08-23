using DastYarHub.DTOs.ToolUsages;

namespace DastYarHub.Services
{
    public interface IToolUsageService
    {
        Task<List<PopularToolDto>> GetPopularToolsAsync();
    }
}
