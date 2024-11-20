using matchMaking.be.Dtos.Team;
using matchMaking.be.Interfaces;
using matchMaking.be.Models;

namespace matchMaking.be.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;

    public TeamService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
    }

    public async Task<Team> CreateTeam(CreateTeamRequestDto createTeamRequestDto)
    {
   
        if (createTeamRequestDto.Players.Count != 5)
        {
            throw new InvalidOperationException("Team must have 5 players");
        }

        
        var existingTeam = await _teamRepository.GetTeamByName(createTeamRequestDto.TeamName);
        if (existingTeam != null)
        {
            throw new InvalidOperationException("Team name alredy exists");
        }

       
        var players = new List<Player>();
        foreach (var playerId in createTeamRequestDto.Players)
        {
            var player = await _playerRepository.GetPlayerById(playerId);
            if (player == null)
            {
                throw new KeyNotFoundException($"Player with Id {playerId} not found.");
            }

            if (player.TeamId != null)
            {
                throw new InvalidOperationException($"Players {player.Nickname} is already in a team");
            }

            players.Add(player);
        }

     
        var team = new Team
        {
            Id = Guid.NewGuid(),
            TeamName = createTeamRequestDto.TeamName,
            Players = players
        };

        
        await _teamRepository.CreateTeam(team);
        
        foreach (var player in players)
        {
            player.TeamId = team.Id;
            await _playerRepository.UpdatePlayer(player);
        }

        //mapirati u dto ako treba
        return team;
    }

    public async Task<Team?> GetTeamById(Guid teamId)
    {
        var team = await _teamRepository.GetTeamById(teamId);
        
        if (team == null)
        {
            throw new KeyNotFoundException($"Team with ID {teamId} was not found.");
        }

        //pretvoriti u dto ukoliko je potrebno
        return team;
    }
}
