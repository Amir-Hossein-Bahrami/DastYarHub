using DastYarHub.API.Data;
using DastYarHub.API.DTOs.Categories;
using DastYarHub.API.Models;
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
                    IconUrl = category.IconUrl
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
                    IconUrl = category.IconUrl
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Slug = dto.Slug,
                IconUrl = dto.IconUrl
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                IconUrl = category.IconUrl
            };
        }
    }
}