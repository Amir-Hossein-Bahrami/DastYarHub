using System.ComponentModel.DataAnnotations;

namespace DastYarHub.API.DTOs.Tools;

public class UpdateToolDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    public bool IsActive { get; set; }

    [MaxLength(500)]
    public string IconUrl { get; set; } = string.Empty;
}