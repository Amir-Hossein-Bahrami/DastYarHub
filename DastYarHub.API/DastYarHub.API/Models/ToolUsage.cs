namespace DastYarHub.API.Models
{
    public class ToolUsage
    {
        public long Id { get; set; }

        public int ToolId { get; set; }

        public bool Success { get; set; }

        public int DurationMs { get; set; }

        public DateTime CreatedAt { get; set; }

        public Tool Tool { get; set; } = null!;
    }
}
