using matchMaking.be.Dto.Player;
using matchMaking.be.Exceptions;
using matchMaking.be.Interfaces;
using matchMaking.be.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace matchMaking.be.Controllers;


[ApiController]
[Route("[controller]")]
public class PlayersController: ControllerBase
{
    
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }


    [HttpPost("/players/create")]

    public async Task<IActionResult> Create([FromBody] CreatePlayerRequestDto player)
    {

        try
        {
            var createdPlayer = await _playerService.CreatePlayer(player);
            return Ok(createdPlayer);
        }
        catch (PlayerAlredyExistsException e)
        {
            return BadRequest(new { error = e.Message });
        }
        catch (Exception e)
        {
            
            return StatusCode(500, new { error = "An unexpected error occurred" });
        }
        
    }


    [HttpGet("{id:guid}")]

    public async Task<IActionResult> GetPlayerById([FromRoute] Guid id)
    {
        try
        {
            var player = await _playerService.GetPlayerById(id);

            return Ok(player);
        }
        catch (PlayerNotFoundException ex)
        {
            return NotFound(new { error = ex.Message }); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "An unexpected error occurred", details = ex.Message });
        }
     
    }
    
    
    
    
    
    
}