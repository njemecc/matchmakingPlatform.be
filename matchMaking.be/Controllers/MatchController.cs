using matchMaking.be.Dtos.Match;
using matchMaking.be.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace matchMaking.be.Controllers;

[ApiController]
[Route("matches")]
public class MatchesController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchesController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpPost]
    public async Task<IActionResult> AddMatch([FromBody] CreateMatchRequestDto createMatchRequestDto)
    {
        try
        {
            var match = await _matchService.AddMatch(createMatchRequestDto);
            return Ok(match);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
