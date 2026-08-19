using DastYarHub.API.Data;
using DastYarHub.API.DTOs.Markets;
using DastYarHub.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DastYarHub.API.Services
{
    public class MarketService : IMarketService
    {
        private readonly AppDbContext _context;
        
        public MarketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarketResponseDto>> GetAllAsync()
        {
            return await _context.Markets
                .AsNoTracking()
                .OrderBy(market => market.DisplayOrder)
                .Select(market => new MarketResponseDto
                {
                    Id = market.Id,
                    Name = market.Name,
                    Slug = market.Slug,
                    Description = market.Description,
                    DisplayOrder = market.DisplayOrder,
                    IconUrl = market.IconUrl,
                    IsActive = market.IsActive,
                })
                .ToListAsync();
        }

        public async Task<MarketResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Markets
                .AsNoTracking()
                .Where(market => market.Id == id)
                .Select(market => new MarketResponseDto
                {
                    Id = market.Id,
                    Name = market.Name,
                    Slug = market.Slug,
                    Description = market.Description,
                    DisplayOrder = market.DisplayOrder,
                    IconUrl = market.IconUrl,
                    IsActive = market.IsActive,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<MarketResponseDto> CreateAsync(CreateMarketDto dto)
        {
            var market = new Market
            {
                Name = dto.Name,
                Slug = dto.Slug,
                Description = dto.Description,
                IconUrl = dto.IconUrl ?? string.Empty,
                IsActive = dto.IsActive,
                DisplayOrder = dto.DisplayOrder
            };

            _context.Markets.Add(market);

            await _context.SaveChangesAsync();

            return new MarketResponseDto
            {
                Id = market.Id,
                Name = market.Name,
                Slug = market.Slug,
                Description = market.Description,
                IconUrl = market.IconUrl,
                IsActive = market.IsActive,
                DisplayOrder = market.DisplayOrder
            };
        }

        public async Task<MarketResponseDto?> UpdateAsync(int id, UpdateMarketDto dto)
        {
            var market = await _context.Markets
                           .FirstOrDefaultAsync(market => market.Id == id);

            if (market is null)
            {
                return null;
            }

            market.Name = dto.Name;
            market.Slug = dto.Slug;
            market.Description = dto.Description;
            market.IconUrl = dto.IconUrl ?? string.Empty;
            market.IsActive = dto.IsActive;
            market.DisplayOrder = dto.DisplayOrder;

            await _context.SaveChangesAsync();

            return new MarketResponseDto
            {
                Id = market.Id,
                Name = market.Name,
                Slug = market.Slug,
                Description = market.Description,
                IconUrl = market.IconUrl,
                IsActive = market.IsActive,
                DisplayOrder = market.DisplayOrder
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var market = await _context.Markets
                .FirstOrDefaultAsync(market => market.Id == id);

            if (market is null)
            {
                return false;
            }

            _context.Markets.Remove(market);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}