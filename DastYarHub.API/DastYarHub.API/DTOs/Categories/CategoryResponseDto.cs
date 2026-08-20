namespace DastYarHub.API.DTOs.Categories
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? IconUrl { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}
