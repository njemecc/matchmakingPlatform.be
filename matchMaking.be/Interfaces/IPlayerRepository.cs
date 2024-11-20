using matchMaking.be.Dto.Player;
using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface IPlayerRepository
{
    Task<Player?> CreatePlayer(CreatePlayerRequestDto createPlayerRequestDto);
    Task<Player?> GetPlayerById(Guid playerId);
}