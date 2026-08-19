using DastYarHub.API.Data;
using DastYarHub.API.DTOs.MarketTools;
using DastYarHub.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DastYarHub.API.Services
{
    public class MarketToolService : IMarketToolService
    {
        private readonly AppDbContext _context;

        public MarketToolService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarketToolResponseDto>> GetByMarketIdAsync(int marketId)
        {
            var marketExists = await _context.Markets
                .AnyAsync(market => market.Id == marketId);

            if (!marketExists)
            {
                throw new KeyNotFoundException("Market not found.");
            }

            return await _context.MarketTools
                .AsNoTracking()
                .Where(marketTool => marketTool.MarketId == marketId)
                .OrderBy(marketTool => marketTool.DisplayOrder)
                .Select(marketTool => new MarketToolResponseDto
                {
                    MarketId = marketTool.MarketId,
                    ToolId = marketTool.ToolId,
                    ToolName = marketTool.Tool.Name,
                    ToolSlug = marketTool.Tool.Slug,
                    ToolIconUrl = marketTool.Tool.IconUrl,
                    CategoryId = marketTool.Tool.CategoryId,
                    IsActive = marketTool.Tool.IsActive,
                    CreatedAt = marketTool.Tool.CreatedAt,
                    DisplayOrder = marketTool.DisplayOrder
                })
                .ToListAsync();
        }

        public async Task<MarketToolResponseDto> AddAsync(int marketId, AddToolToMarketDto dto)
        {
            var marketExists = await _context.Markets
                .AnyAsync(market => market.Id == marketId);

            if (!marketExists)
            {
                throw new KeyNotFoundException("Market not found.");
            }

            var tool = await _context.Tools
                .AsNoTracking()
                .FirstOrDefaultAsync(tool => tool.Id == dto.ToolId);

            if (tool is null)
            {
                throw new KeyNotFoundException("Tool not found.");
            }

            var relationExists = await _context.MarketTools
                .AnyAsync(marketTool =>
                    marketTool.MarketId == marketId &&
                    marketTool.ToolId == dto.ToolId);

            if (relationExists)
            {
                throw new InvalidOperationException(
                    "This tool already exists in this market.");
            }

            var marketTool = new MarketTool
            {
                MarketId = marketId,
                ToolId = dto.ToolId,
                DisplayOrder = dto.DisplayOrder
            };

            _context.MarketTools.Add(marketTool);

            await _context.SaveChangesAsync();

            return new MarketToolResponseDto
            {
                MarketId = marketTool.MarketId,
                ToolId = tool.Id,
                ToolName = tool.Name,
                ToolSlug = tool.Slug,
                ToolIconUrl = tool.IconUrl,
                CategoryId = tool.CategoryId,
                IsActive = tool.IsActive,
                CreatedAt = tool.CreatedAt,
                DisplayOrder = marketTool.DisplayOrder
            };
        }

        public async Task<MarketToolResponseDto?> UpdateAsync(int marketId, int toolId, UpdateMarketToolDto dto)
        {
            var marketTool = await _context.MarketTools
                .Include(marketTool => marketTool.Tool)
                .FirstOrDefaultAsync(marketTool =>
                    marketTool.MarketId == marketId &&
                    marketTool.ToolId == toolId);

            if (marketTool is null)
            {
                return null;
            }

            marketTool.DisplayOrder = dto.DisplayOrder;

            await _context.SaveChangesAsync();

            return new MarketToolResponseDto
            {
                MarketId = marketTool.MarketId,
                ToolId = marketTool.ToolId,
                ToolName = marketTool.Tool.Name,
                ToolSlug = marketTool.Tool.Slug,
                ToolIconUrl = marketTool.Tool.IconUrl,
                CategoryId = marketTool.Tool.CategoryId,
                IsActive = marketTool.Tool.IsActive,
                CreatedAt = marketTool.Tool.CreatedAt,
                DisplayOrder = marketTool.DisplayOrder
            };
        }

        public async Task<bool> DeleteAsync(int marketId, int toolId)
        {
            var marketTool = await _context.MarketTools
                .FirstOrDefaultAsync(marketTool =>
                    marketTool.MarketId == marketId &&
                    marketTool.ToolId == toolId);

            if (marketTool is null)
            {
                return false;
            }

            _context.MarketTools.Remove(marketTool);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}