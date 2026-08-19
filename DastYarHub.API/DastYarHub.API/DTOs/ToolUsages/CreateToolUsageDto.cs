using System.ComponentModel.DataAnnotations;

namespace DastYarHub.API.DTOs.ToolUsages
{
    public class CreateToolUsageDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ToolId { get; set; }

        public bool Success { get; set; }

        [Range(0, int.MaxValue)]
        public int DurationMs { get; set; }
    }
}