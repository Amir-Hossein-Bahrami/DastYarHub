namespace DastYarHub.API.DTOs.Tools
{
    public class ToolResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string IconUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
