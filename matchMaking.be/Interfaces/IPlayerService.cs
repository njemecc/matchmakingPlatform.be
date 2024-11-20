using matchMaking.be.Dto.Player;
using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface IPlayerService
{
    Task<CreatePlayerResponseDto?> CreatePlayer(CreatePlayerRequestDto createPlayerRequestDto);
    Task<GetPlayerByIdResponse?> GetPlayerById(Guid playerId);
}