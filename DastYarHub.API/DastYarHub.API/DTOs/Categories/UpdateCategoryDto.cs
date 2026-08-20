namespace DastYarHub.API.DTOs.Categories;

public class UpdateCategoryDto
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? IconUrl { get; set; }

    public bool IsActive { get; set; }

    public int DisplayOrder { get; set; }
}