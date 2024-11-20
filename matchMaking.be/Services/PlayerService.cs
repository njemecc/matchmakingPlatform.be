using matchMaking.be.Dto.Player;
using matchMaking.be.Exceptions;
using matchMaking.be.Interfaces;
using matchMaking.be.Mappers;
using matchMaking.be.Models;
using matchMaking.be.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace matchMaking.be.Services;

public class PlayerService:IPlayerService


{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public async Task<CreatePlayerResponseDto?> CreatePlayer(CreatePlayerRequestDto createPlayerRequestDto)
    {
        var playerExists = await _playerRepository.PlayerExists(createPlayerRequestDto.Nickname);
        
        if (playerExists != null)
        {
            throw new PlayerAlredyExistsException("Player with that nickname alredy exists");
        }
        var playerModel = createPlayerRequestDto.FromCreateRequestDtoToModel();
        
        await _playerRepository.CreatePlayer(playerModel);

        return playerModel.FromModelToCreateResponse();

    }

    public async Task<GetPlayerByIdResponse?> GetPlayerById(Guid playerId)
    {
        var player = await _playerRepository.GetPlayerById(playerId);

        if (player == null)
        {
            throw new PlayerNotFoundException("Player with that Id does not exist");
        }
        
        return player.FromModelToGetPlayerByIdResponse();
    }
}