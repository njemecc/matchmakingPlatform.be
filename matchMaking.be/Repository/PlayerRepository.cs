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

    public async Task<Player?> CreatePlayer(Player player)
    {

        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        
        return player;
        
    }

    public async Task<Player?> GetPlayerById(Guid playerId)
    {
        return  await _context.Players.FindAsync(playerId);
        
    }

    public async Task<Player?> PlayerExists(string nickname)
    {
        return  await _context.Players.FirstOrDefaultAsync(p => p.Nickname.Equals(nickname));
    }
}