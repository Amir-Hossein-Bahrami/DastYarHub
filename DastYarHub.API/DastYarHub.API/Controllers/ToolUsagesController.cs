using DastYarHub.API.DTOs.ToolUsages;
using DastYarHub.API.Models;
using DastYarHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DastYarHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToolUsagesController : ControllerBase
{
    private readonly IToolUsageService _toolUsageService;

    public ToolUsagesController(IToolUsageService toolUsageService)
    {
        _toolUsageService = toolUsageService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ToolUsageResponseDto>>> GetToolUsages()
    {
        var toolUsages = await _toolUsageService.GetAllAsync();

        return Ok(toolUsages);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ToolUsageResponseDto>> GetToolUsage(
        long id)
    {
        var toolUsage = await _toolUsageService.GetByIdAsync(id);

        if (toolUsage is null)
        {
            return NotFound();
        }

        return Ok(toolUsage);
    }

    [HttpGet("tool/{toolId:int}")]
    public async Task<ActionResult<List<ToolUsageResponseDto>>> GetByToolId(
        int toolId)
    {
        var toolUsages = await _toolUsageService
            .GetByToolIdAsync(toolId);

        return Ok(toolUsages);
    }

    [HttpPost]
    public async Task<ActionResult<ToolUsageResponseDto>> CreateToolUsage(
        [FromBody] CreateToolUsageDto dto)
    {
        var toolUsage = await _toolUsageService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetToolUsage),
            new { id = toolUsage.Id },
            toolUsage);
    }

    [HttpGet("popular")]
    public async Task<ActionResult<List<PopularToolResponseDto>>> GetPopularTools()
    {
        var popularTools = await _toolUsageService.GetPopularToolsAsync();

        return Ok(popularTools);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteToolUsage(long id)
    {
        var deleted = await _toolUsageService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}