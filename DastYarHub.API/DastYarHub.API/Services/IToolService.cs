using DastYarHub.API.DTOs.Tools;

namespace DastYarHub.API.Services;

public interface IToolService
{
    Task<List<ToolResponseDto>> GetAllAsync();

    Task<ToolResponseDto?> GetByIdAsync(int id);

    Task<ToolResponseDto> CreateAsync(CreateToolDto dto);

    Task<ToolResponseDto?> UpdateAsync(int id, UpdateToolDto dto);

    Task<bool> DeleteAsync(int id);
}