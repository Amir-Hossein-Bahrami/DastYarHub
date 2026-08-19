namespace DastYarHub.API.DTOs.Markets
{
    public class MarketResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? IconUrl { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}