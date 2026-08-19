using DastYarHub.API.DTOs.Categories;

namespace DastYarHub.API.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();

        Task<CategoryResponseDto?> GetByIdAsync(int id);

        Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto);
    }
}
