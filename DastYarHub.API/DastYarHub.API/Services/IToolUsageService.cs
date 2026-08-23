using DastYarHub.API.DTOs.ToolUsages;
using DastYarHub.API.Models;

namespace DastYarHub.API.Services
{
    public interface IToolUsageService
    {
        Task<List<ToolUsageResponseDto>> GetAllAsync();

        Task<ToolUsageResponseDto?> GetByIdAsync(long id);

        Task<List<ToolUsageResponseDto>> GetByToolIdAsync(int toolId);

        Task<ToolUsageResponseDto> CreateAsync(CreateToolUsageDto dto);

        Task<List<PopularToolResponseDto>> GetPopularToolsAsync();

        Task<bool> DeleteAsync(long id);
    }
}