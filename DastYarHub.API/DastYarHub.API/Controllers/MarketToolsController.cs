using DastYarHub.API.DTOs.MarketTools;
using DastYarHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DastYarHub.API.Controllers;

[ApiController]
[Route("api/markets/{marketId:int}/tools")]
public class MarketToolsController : ControllerBase
{
    private readonly IMarketToolService _marketToolService;

    public MarketToolsController(IMarketToolService marketToolService)
    {
        _marketToolService = marketToolService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MarketToolResponseDto>>> GetMarketTools(int marketId)
    {
        var tools = _marketToolService.GetByMarketIdAsync(marketId);

        return Ok(tools);
    }

    [HttpPost]
    public async Task<ActionResult<MarketToolResponseDto>> AddToolToMarketAsync(int marketId, [FromBody] AddToolToMarketDto dto)
    {
        var marketTool = await _marketToolService.AddAsync(marketId, dto);

        return CreatedAtAction(nameof(GetMarketTools), new { marketId }, marketTool);
    }

    [HttpPut("{toolId:int}")]
    public async Task<ActionResult<MarketToolResponseDto>> UpdateMarketTool(int marketId, int toolId, [FromBody] UpdateMarketToolDto dto)
    {
        var marketTool = await _marketToolService
            .UpdateAsync(marketId, toolId, dto);

        if (marketTool is null)
        {
            return NotFound();
        }

        return Ok(marketTool);
    }

    [HttpDelete("{toolId:int}")]
    public async Task<IActionResult> DeleteToolFromMarket(int marketId, int toolId)
    {
        var deleted = await _marketToolService
            .DeleteAsync(marketId, toolId);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}