using DastYarHub.API.DTOs.Markets;
using DastYarHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DastYarHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarketsController : ControllerBase
{
    private readonly IMarketService _marketService;

    public MarketsController(IMarketService marketService)
    {
        _marketService = marketService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MarketResponseDto>>> GetMarkets()
    {
        var markets = await _marketService.GetAllAsync();

        return Ok(markets);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MarketResponseDto>> GetMarket(int id)
    {
        var market = await _marketService.GetByIdAsync(id);

        if (market == null)
        {
            return NotFound();
        }

        return Ok(market);
    }

    [HttpPost]
    public async Task<ActionResult<MarketResponseDto>> CreateMarket([FromBody] CreateMarketDto dto)
    {
        var market = await _marketService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetMarket), new { id = market.Id }, market);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MarketResponseDto>> UpdateMarket(int id, [FromBody] UpdateMarketDto dto)
    {
        var market = await _marketService.UpdateAsync(id, dto);

        if (market is null)
        {
            return NotFound();
        }

        return Ok(market);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMarket(int id)
    {
        var deleted = await _marketService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}