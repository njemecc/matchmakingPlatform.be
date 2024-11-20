using matchMaking.be.Dtos.Team;
using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface ITeamService
{
    Task<Team> CreateTeam(CreateTeamRequestDto createTeamRequestDto);
    Task<Team?> GetTeamById(Guid teamId);
}