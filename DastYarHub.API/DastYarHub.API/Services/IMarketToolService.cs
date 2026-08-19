using DastYarHub.API.DTOs.MarketTools;

namespace DastYarHub.API.Services
{
    public interface IMarketToolService
    {
        Task<List<MarketToolResponseDto>> GetByMarketIdAsync(int marketId);

        Task<MarketToolResponseDto> AddAsync(int marketId, AddToolToMarketDto dto);

        Task<MarketToolResponseDto?> UpdateAsync(int marketId, int toolId, UpdateMarketToolDto dto);

        Task<bool> DeleteAsync(int marketId, int toolId);
    }
}