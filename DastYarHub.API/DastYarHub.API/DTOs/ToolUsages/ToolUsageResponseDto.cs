namespace DastYarHub.API.DTOs.ToolUsages
{
    public class ToolUsageResponseDto
    {
        public long Id { get; set; }

        public int ToolId { get; set; }

        public string ToolName { get; set; } = string.Empty;

        public bool Success { get; set; }

        public int DurationMs { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}