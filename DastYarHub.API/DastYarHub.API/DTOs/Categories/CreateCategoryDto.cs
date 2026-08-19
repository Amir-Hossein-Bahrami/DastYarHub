using System.ComponentModel.DataAnnotations;

namespace DastYarHub.API.DTOs.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

        [MaxLength(500)]
        public string IconUrl { get; set; } = string.Empty;
    }
}
