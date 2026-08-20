using DastYarHub.API.Data;
using DastYarHub.API.DTOs.Categories;
using DastYarHub.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DastYarHub.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(category => new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Slug = category.Slug,
                    IconUrl = category.IconUrl,
                    IsActive = category.IsActive,
                    DisplayOrder = category.DisplayOrder
                })
                .ToListAsync();
        }

        public async Task<List<CategoryResponseDto>> GetActiveAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(category => category.IsActive)
                .OrderBy(category => category.DisplayOrder)
                .Select(category => new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Slug = category.Slug,
                    IconUrl = category.IconUrl,
                    IsActive = category.IsActive,
                    DisplayOrder = category.DisplayOrder
                })
                .ToListAsync();
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(category => category.Id == id)
                .Select(category => new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Slug = category.Slug,
                    IconUrl = category.IconUrl,
                    IsActive = category.IsActive,
                    DisplayOrder = category.DisplayOrder
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Slug = dto.Slug,
                IconUrl = dto.IconUrl,
                IsActive = dto.IsActive,
                DisplayOrder = dto.DisplayOrder
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                IconUrl = category.IconUrl,
                IsActive = category.IsActive,
                DisplayOrder = category.DisplayOrder
            };
        }

        public async Task<CategoryResponseDto?> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(category => category.Id == id);

            if (category is null)
            {
                return null;
            }

            category.Name = dto.Name;
            category.Slug = dto.Slug;
            category.IconUrl = dto.IconUrl;
            category.IsActive = dto.IsActive;
            category.DisplayOrder = dto.DisplayOrder;

            await _context.SaveChangesAsync();

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                IconUrl = category.IconUrl,
                IsActive = category.IsActive,
                DisplayOrder = category.DisplayOrder
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync (category => category.Id == id);

            if (category is null)
            {
                return false;
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}