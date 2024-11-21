using matchMaking.be.Dtos.Match;
using matchMaking.be.Helpers;
using matchMaking.be.Interfaces;
using matchMaking.be.Models;

namespace matchMaking.be.Services;

public class MatchService : IMatchService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMatchRepository _matchRepository;

    public MatchService(ITeamRepository teamRepository, IMatchRepository matchRepository)
    {
        _teamRepository = teamRepository;
        _matchRepository = matchRepository;
    }

    public async Task<Match> AddMatch(CreateMatchRequestDto createMatchRequestDto)
    {
        
        var team1 = await _teamRepository.GetTeamById(createMatchRequestDto.Team1Id);
        if (team1 == null)
        {
            throw new KeyNotFoundException("Team1 not found");
        }

       
        var team2 = await _teamRepository.GetTeamById(createMatchRequestDto.Team2Id);
        if (team2 == null)
        {
            throw new KeyNotFoundException("Team2 not found");
        }

        
        if (createMatchRequestDto.Duration < 1)
        {
            throw new InvalidOperationException("Match duration must be at least 1 hour Time");
        }
        
        if (createMatchRequestDto.WinningTeamId.HasValue &&
            createMatchRequestDto.WinningTeamId != team1.Id &&
            createMatchRequestDto.WinningTeamId != team2.Id)
        {
            throw new InvalidOperationException("Winning team must be team1 or team2");
        }

     
        var team1Players = team1.Players;
        var team2Players = team2.Players;

        foreach (var player in team1Players.Concat(team2Players))
        {
            
            player.HoursPlayed += createMatchRequestDto.Duration;

            
            double r1 = player.Elo;
            double r2 = team2Players.Average(p => p.Elo); 
            double e = 1 / (1 + Math.Pow(10, (r2 - r1) / 400)); 
            int k = Helper.KCalculaiton(player.HoursPlayed);

            double s = 0.5; 
            if (createMatchRequestDto.WinningTeamId == team1.Id)
            {
                s = team1Players.Contains(player) ? 1 : 0; 
            }
            else if (createMatchRequestDto.WinningTeamId == team2.Id)
            {
                s = team2Players.Contains(player) ? 1 : 0;
            }

            player.Elo = (int)Math.Round(r1 + k * (s - e));

       
            if (createMatchRequestDto.WinningTeamId.HasValue)
            {
                if (s == 1)
                {
                    player.Wins++;
                }
                else if (s == 0)
                {
                    player.Losses++;
                }
            }
        }

        
        var match = new Match
        {
            Id = Guid.NewGuid(),
            Team1Id = team1.Id,
            Team2Id = team2.Id,
            WinningTeamId = createMatchRequestDto.WinningTeamId,
            Duration = createMatchRequestDto.Duration,
        };

        await _matchRepository.AddMatchAsync(match);

        return match;
    }

    
}
