using DastYarHub.API.DTOs.Markets;

namespace DastYarHub.API.Services
{
    public interface IMarketService
    {
        Task<List<MarketResponseDto>> GetAllAsync();

        Task<MarketResponseDto?> GetByIdAsync(int id);

        Task<MarketResponseDto> CreateAsync(CreateMarketDto dto);

        Task<MarketResponseDto?> UpdateAsync(int id, UpdateMarketDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
