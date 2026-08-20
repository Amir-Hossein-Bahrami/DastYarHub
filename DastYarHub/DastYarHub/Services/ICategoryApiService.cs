using DastYarHub.DTOs.Categories;

namespace DastYarHub.Services
{
    public interface ICategoryApiService
    {
        Task<List<CategoryResponseDto>> GetActiveCategoriesAsync();
    }
}
