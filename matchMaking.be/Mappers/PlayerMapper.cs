using System.Security.Cryptography.X509Certificates;
using matchMaking.be.Dto.Player;
using matchMaking.be.Models;

namespace matchMaking.be.Mappers;

public static class PlayerMapper
{
    public static Player FromCreateRequestDtoToModel(this CreatePlayerRequestDto playerRequestDto)
    {
        return new Player()
        {
            Nickname = playerRequestDto.Nickname,
            Wins = 0,
            Losses = 0,
            Elo = 0,
            HoursPlayed = 0,
            
        };
    }

    public static CreatePlayerResponseDto FromCreateRequestToCreateResponseDto(
        this CreatePlayerRequestDto playerRequestDto)
    {
        return new CreatePlayerResponseDto()
        {
            Nickname = playerRequestDto.Nickname,
            Wins = 0,
            Losses = 0,
            Elo = 0,
            HoursPlayed = 0,
        };
    }

    public static CreatePlayerResponseDto FromModelToCreateResponse(this Player player)
    {
        return new CreatePlayerResponseDto()
        {
            Nickname = player.Nickname,
            Wins = player.Wins,
            Losses = player.Losses,
            Elo = player.Elo,
            HoursPlayed = player.HoursPlayed
        };
    }
}