using System.ComponentModel.DataAnnotations;

namespace DastYarHub.API.DTOs.MarketTools
{
    public class UpdateMarketToolDto
    {
        [Range(0, int.MaxValue)]
        public int DisplayOrder { get; set; }
    }
}
