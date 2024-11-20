using matchMaking.be.Dto.Player;
using matchMaking.be.Interfaces;
using matchMaking.be.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace matchMaking.be.Controllers;


[ApiController]
[Route("[controller]")]
public class PlayersController: ControllerBase
{
    
    private readonly IPlayerRepository _playerRepository;

    public PlayersController(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }


    [HttpPost]
    [Route("/create")]

    public async Task<IActionResult> Create([FromBody] CreatePlayerRequestDto player)
    {
        var playerCreated = await _playerRepository.CreatePlayer(player);

        if (playerCreated == null)
        {
            return BadRequest();
        }
        
        return Ok(playerCreated.FromModelToCreateResponse());
    }
    
    
    
}