using DastYarHub.API.DTOs.ToolUsages;

namespace DastYarHub.API.Services
{
    public interface IToolUsageService
    {
        Task<List<ToolUsageResponseDto>> GetAllAsync();

        Task<ToolUsageResponseDto?> GetByIdAsync(long id);

        Task<List<ToolUsageResponseDto>> GetByToolIdAsync(int toolId);

        Task<ToolUsageResponseDto> CreateAsync(CreateToolUsageDto dto);

        Task<bool> DeleteAsync(long id);
    }
}