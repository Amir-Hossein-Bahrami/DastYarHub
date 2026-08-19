using DastYarHub.API.DTOs.Tools;
using DastYarHub.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DastYarHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToolsController : ControllerBase
{
    private readonly IToolService _toolService;

    public ToolsController(IToolService toolService)
    {
        _toolService = toolService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ToolResponseDto>>> GetTools()
    {
        var tools = await _toolService.GetAllAsync();

        return Ok(tools);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ToolResponseDto>> GetTool(int id)
    {
        var tool = await _toolService.GetByIdAsync(id);

        if (tool is null)
        {
            return NotFound();
        }

        return Ok(tool);
    }

    [HttpPost]
    public async Task<ActionResult<ToolResponseDto>> CreateTool([FromBody] CreateToolDto dto)
    {
        var tool = await _toolService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetTool), new { id = tool.Id }, tool);    
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ToolResponseDto>> UpdateTool(int id,  [FromBody] UpdateToolDto dto)
    {
        var tool = await _toolService.UpdateAsync(id, dto);

        if (tool is null)
        {
            return NotFound();
        }

        return Ok(tool);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTool(int id)
    {
        var deleted = await _toolService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}