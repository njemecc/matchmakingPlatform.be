using matchMaking.be.Context;
using matchMaking.be.Dto.Player;
using matchMaking.be.Interfaces;
using matchMaking.be.Mappers;
using matchMaking.be.Models;
using Microsoft.EntityFrameworkCore;

namespace matchMaking.be.Repository;

public class PlayerRepository : IPlayerRepository

{
    private readonly MatchmakingContext _context;

    public PlayerRepository(MatchmakingContext context)
    {
        _context = context;
    }

    public async Task<Player?> CreatePlayer(CreatePlayerRequestDto createPlayerRequestDto)
    {
        
        var playerExists = await _context.Players.AnyAsync(p => p.Nickname.Equals(createPlayerRequestDto.Nickname));

        if (playerExists)
        {
            return null;
        }


        var playerModel = createPlayerRequestDto.FromCreateRequestDtoToModel();

        await _context.Players.AddAsync(playerModel);
        await _context.SaveChangesAsync();
        
        return playerModel;
        
    }
}