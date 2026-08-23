using DastYarHub.DTOs.Categories;
using DastYarHub.DTOs.ToolUsages;

namespace DastYarHub.ViewModel
{
    public class HomeViewModel
    {
        public List<CategoryResponseDto> Categories { get; set; } = new();

        public List<PopularToolDto> PopularTools { get; set; } = new();
    }
}
