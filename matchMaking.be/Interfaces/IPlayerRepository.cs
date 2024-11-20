using matchMaking.be.Dto.Player;
using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface IPlayerRepository
{
    Task<Player?> CreatePlayer(Player player);
    Task<Player?> GetPlayerById(Guid playerId);
    
    Task<Player?> PlayerExists(string nickname);
    Task UpdatePlayer(Player player);
}