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
            Id = Guid.NewGuid(),
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
            Id = player.Id,
            Nickname = player.Nickname,
            Wins = player.Wins,
            Losses = player.Losses,
            Elo = player.Elo,
            HoursPlayed = player.HoursPlayed
        };
    }

    public static GetPlayerByIdResponse FromModelToGetPlayerByIdResponse(this Player player)
    {
        return new GetPlayerByIdResponse()
        {
            Id = player.Id,
            Nickname = player.Nickname,
            Wins = player.Wins,
            Losses = player.Losses,
            Elo = player.Elo,
            HoursPlayed = player.HoursPlayed,
            RatingAdjustment = player.RatingAdjustment,
            TeamId = player.TeamId

        };
    }
}