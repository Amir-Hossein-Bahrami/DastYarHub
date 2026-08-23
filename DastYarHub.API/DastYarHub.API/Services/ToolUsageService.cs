using DastYarHub.API.Data;
using DastYarHub.API.DTOs.ToolUsages;
using DastYarHub.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DastYarHub.API.Services
{
    public class ToolUsageService : IToolUsageService
    {
        private readonly AppDbContext _context;

        public ToolUsageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToolUsageResponseDto>> GetAllAsync()
        {
            return await _context.ToolUsages
                .AsNoTracking()
                .OrderByDescending(toolUsage => toolUsage.CreatedAt)
                .Select(toolUsage => new ToolUsageResponseDto
                {
                    Id = toolUsage.Id,
                    ToolId = toolUsage.ToolId,
                    ToolName = toolUsage.Tool.Name,
                    Success = toolUsage.Success,
                    DurationMs = toolUsage.DurationMs,
                    CreatedAt = toolUsage.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ToolUsageResponseDto?> GetByIdAsync(long id)
        {
            return await _context.ToolUsages
                .AsNoTracking()
                .Where(toolUsage => toolUsage.Id == id)
                .Select(toolUsage => new ToolUsageResponseDto
                {
                    Id = toolUsage.Id,
                    ToolId = toolUsage.ToolId,
                    ToolName = toolUsage.Tool.Name,
                    Success = toolUsage.Success,
                    DurationMs = toolUsage.DurationMs,
                    CreatedAt = toolUsage.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ToolUsageResponseDto>> GetByToolIdAsync(
            int toolId)
        {
            var toolExists = await _context.Tools
                .AnyAsync(tool => tool.Id == toolId);

            if (!toolExists)
            {
                throw new KeyNotFoundException("Tool not found.");
            }

            return await _context.ToolUsages
                .AsNoTracking()
                .Where(toolUsage => toolUsage.ToolId == toolId)
                .OrderByDescending(toolUsage => toolUsage.CreatedAt)
                .Select(toolUsage => new ToolUsageResponseDto
                {
                    Id = toolUsage.Id,
                    ToolId = toolUsage.ToolId,
                    ToolName = toolUsage.Tool.Name,
                    Success = toolUsage.Success,
                    DurationMs = toolUsage.DurationMs,
                    CreatedAt = toolUsage.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ToolUsageResponseDto> CreateAsync(
            CreateToolUsageDto dto)
        {
            var tool = await _context.Tools
                .AsNoTracking()
                .FirstOrDefaultAsync(tool => tool.Id == dto.ToolId);

            if (tool is null)
            {
                throw new KeyNotFoundException("Tool not found.");
            }

            var toolUsage = new ToolUsage
            {
                ToolId = dto.ToolId,
                Success = dto.Success,
                DurationMs = dto.DurationMs,
                CreatedAt = DateTime.UtcNow
            };

            _context.ToolUsages.Add(toolUsage);

            await _context.SaveChangesAsync();

            return new ToolUsageResponseDto
            {
                Id = toolUsage.Id,
                ToolId = toolUsage.ToolId,
                ToolName = tool.Name,
                Success = toolUsage.Success,
                DurationMs = toolUsage.DurationMs,
                CreatedAt = toolUsage.CreatedAt
            };
        }

        public async Task<List<PopularToolResponseDto>> GetPopularToolsAsync()
        {
            return await _context.ToolUsages
                .AsNoTracking()
                .Where(toolUsage => toolUsage.Tool.IsActive)
                .GroupBy(toolUsage => new
                {
                    toolUsage.ToolId,
                    toolUsage.Tool.Name,
                    toolUsage.Tool.Slug,
                    toolUsage.Tool.IconUrl
                })
                .Select(group => new PopularToolResponseDto
                {
                    ToolId = group.Key.ToolId,
                    ToolName = group.Key.Name,
                    ToolSlug = group.Key.Slug,
                    IconUrl = group.Key.IconUrl,
                    UsageCount = group.Count()
                })
                .OrderByDescending(tool => tool.UsageCount)
                .Take(5)
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var toolUsage = await _context.ToolUsages
                .FirstOrDefaultAsync(toolUsage => toolUsage.Id == id);

            if (toolUsage is null)
            {
                return false;
            }

            _context.ToolUsages.Remove(toolUsage);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}