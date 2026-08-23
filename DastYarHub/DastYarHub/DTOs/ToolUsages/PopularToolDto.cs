namespace DastYarHub.DTOs.ToolUsages
{
    public class PopularToolDto
    {
        public int ToolId { get; set; }

        public string ToolName { get; set; } = string.Empty;

        public string ToolSlug { get; set; } = string.Empty;

        public string? IconUrl { get; set; }

        public int UsageCount { get; set; }
    }
}
