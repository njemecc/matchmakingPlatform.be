using matchMaking.be.Dtos.Team;
using matchMaking.be.Interfaces;
using matchMaking.be.Models;
using Microsoft.AspNetCore.Mvc;

namespace matchMaking.be.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController:ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }
    [HttpPost]

    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequestDto createTeamRequestDto)
    {
        try
        {
            var createdTem = await _teamService.CreateTeam(createTeamRequestDto);
            return Ok(createdTem);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTeamById([FromRoute] Guid id)
    {
        try
        {
            var team = await _teamService.GetTeamById(id);
            return Ok(team);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
    
    
}