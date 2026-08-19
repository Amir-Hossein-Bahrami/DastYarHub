namespace DastYarHub.API.DTOs.MarketTools
{
    public class MarketToolResponseDto
    {
        public int MarketId { get; set; }

        public int ToolId { get; set; }

        public string ToolName { get; set; } = string.Empty;

        public string ToolSlug { get; set; } = string.Empty;

        public string ToolIconUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public int DisplayOrder { get; set; }
    }
}
