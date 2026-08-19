namespace DastYarHub.API.Models
{
    public class MarketTool
    {
        public int MarketId { get; set; }

        public Market Market { get; set; } = null!;

        public int ToolId { get; set; }

        public Tool Tool { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
