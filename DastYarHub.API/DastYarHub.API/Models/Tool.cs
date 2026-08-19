namespace DastYarHub.API.Models
{
    public class Tool
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; } = null!;

        public string IconUrl { get; set; } = string.Empty;

        public ICollection<MarketTool> MarketTools { get; set; } = new List<MarketTool>();
    }
}
