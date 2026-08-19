using DastYarHub.API.Data;
using DastYarHub.API.DTOs.Tools;
using DastYarHub.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DastYarHub.API.Services;

public class ToolService : IToolService
{
    private readonly AppDbContext _context;

    public ToolService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ToolResponseDto>> GetAllAsync()
    {
        return await _context.Tools
            .AsNoTracking()
            .Select(tool => new ToolResponseDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Slug = tool.Slug,
                CategoryId = tool.CategoryId,
                IsActive = tool.IsActive,
                CreatedAt = tool.CreatedAt,
                IconUrl = tool.IconUrl
            })
            .ToListAsync();
    }

    public async Task<ToolResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Tools
            .AsNoTracking()
            .Where(tool => tool.Id == id)
            .Select(tool => new ToolResponseDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Slug = tool.Slug,
                CategoryId = tool.CategoryId,
                IsActive = tool.IsActive,
                CreatedAt = tool.CreatedAt,
                IconUrl = tool.IconUrl
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ToolResponseDto> CreateAsync(CreateToolDto dto)
    {
        var categoryExists = await _context.Categories
            .AnyAsync(category => category.Id == dto.CategoryId);

        if (!categoryExists)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        var tool = new Tool
        {
            Name = dto.Name,
            Slug = dto.Slug,
            CategoryId = dto.CategoryId,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            IconUrl = dto.IconUrl
        };

        _context.Tools.Add(tool);

        await _context.SaveChangesAsync();

        return new ToolResponseDto
        {
            Id = tool.Id,
            Name = tool.Name,
            Slug = tool.Slug,
            CategoryId = tool.CategoryId,
            IsActive = tool.IsActive,
            CreatedAt = tool.CreatedAt,
            IconUrl = tool.IconUrl
        };
    }

    public async Task<ToolResponseDto?> UpdateAsync(int id, UpdateToolDto dto)
    {
        var tool = await _context.Tools
            .FirstOrDefaultAsync(tool => tool.Id == id);

        if (tool is null)
        {
            return null;
        }

        var categoryExists = await _context.Categories
            .AnyAsync(category => category.Id == dto.CategoryId);

        if (!categoryExists)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        tool.Name = dto.Name;
        tool.Slug = dto.Slug;
        tool.CategoryId = dto.CategoryId;
        tool.IsActive = dto.IsActive;
        tool.IconUrl = dto.IconUrl;

        await _context.SaveChangesAsync();

        return new ToolResponseDto
        {
            Id = tool.Id,
            Name = tool.Name,
            Slug = tool.Slug,
            CategoryId = tool.CategoryId,
            IsActive = tool.IsActive,
            CreatedAt = tool.CreatedAt,
            IconUrl = tool.IconUrl
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tool = await _context.Tools
            .FirstOrDefaultAsync(tool => tool.Id == id);

        if (tool is null)
        {
            return false;
        }

        _context.Tools.Remove(tool);
        
        await _context.SaveChangesAsync();

        return true;
    }
}