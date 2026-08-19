using System.ComponentModel.DataAnnotations;

namespace DastYarHub.API.DTOs.MarketTools;

public class AddToolToMarketDto
{
    [Required]
    public int ToolId { get; set; }

    [Range(0, int.MaxValue)]
    public int DisplayOrder { get; set; }
}